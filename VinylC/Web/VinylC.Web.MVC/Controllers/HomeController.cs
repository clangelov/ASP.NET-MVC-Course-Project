namespace VinylC.Web.MVC.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Models.Articles;
    using Models.Products;
    using Services.Data.Contracts;
    using Services.Web.Contracts;

    public class HomeController : Controller
    {
        private const int ProductsCount = 5;
        private const int TimeForCache = (5 * 60);

        private ICacheService cacheService;
        private IProductService productsService;
        private IArticleService articlesService;

        public HomeController(ICacheService cacheService, IProductService productsService, IArticleService articlesService)
        {
            this.cacheService = cacheService;
            this.productsService = productsService;
            this.articlesService = articlesService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetArticlesPartial()
        {
            var articlesData =
                this.cacheService.Get(
                    "Articles",
                    () => this.articlesService
                        .MostCommented(ProductsCount)
                        .ProjectTo<ArticleSimpleViewModel>(),
                    TimeForCache);

            return this.PartialView("_SimpleArticlesPartial", articlesData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetProductsPartial()
        {
            var productsData =
                this.cacheService.Get(
                    "Products",
                    () => this.productsService
                        .GetHighestRated(ProductsCount)
                        .ProjectTo<ProductSimpleListViewModel>(),
                    TimeForCache);

            return this.PartialView("_SimpleProductsPartial", productsData);
        }
    }
}