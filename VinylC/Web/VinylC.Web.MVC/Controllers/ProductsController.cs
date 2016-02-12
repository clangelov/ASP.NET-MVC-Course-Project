namespace VinylC.Web.MVC.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Models.Products;
    using PagedList;
    using Services.Data.Contracts;

    public class ProductsController : Controller
    {
        private const int PageSize = 6;

        private IProductService productsService;

        public ProductsController(IProductService productsService)
        {
            this.productsService = productsService;
        }

        public ActionResult All(int? page)
        {
            var products = this.productsService
                .AllProducts()
                .ProjectTo<ProductsListViewModel>();

            int pageNumber = page ?? 1;

            return this.View(products.ToPagedList(pageNumber, PageSize));
        }
    }
}