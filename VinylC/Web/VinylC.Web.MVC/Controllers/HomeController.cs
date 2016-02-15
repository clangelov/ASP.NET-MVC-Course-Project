namespace VinylC.Web.MVC.Controllers
{
    using System.Web.Mvc;
    using Services.Data.Contracts;
    using Services.Web.Contracts;

    public class HomeController : Controller
    {
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
            return null;
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetProductsPartial()
        {
            return null;
        }
    }
}