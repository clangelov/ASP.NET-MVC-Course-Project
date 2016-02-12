namespace VinylC.Web.MVC.Controllers
{
    using System;
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

        public ActionResult All(string sortOrder, int? page)
        {
            var products = this.productsService
                .AllProducts()
                .ProjectTo<ProductsListViewModel>();

            int pageNumber = page ?? 1;

            var sorted = this.GetSorted(products, sortOrder);

            return this.View(sorted.ToPagedList(pageNumber, PageSize));
        }

        private IQueryable<ProductsListViewModel> GetSorted(IQueryable<ProductsListViewModel> allProducts, string sortOrder)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "Date" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            ViewBag.RatingSortParm = sortOrder == "Rating" ? "rating_desc" : "Rating";

            switch (sortOrder)
            {
                case "Rating":
                    allProducts = allProducts.OrderBy(p => p.Rating);
                    break;
                case "rating_desc":
                    allProducts = allProducts.OrderByDescending(p => p.Rating);
                    break;
                case "Price":
                    allProducts = allProducts.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    allProducts = allProducts.OrderByDescending(p => p.Price);
                    break;
                case "Date":
                    allProducts = allProducts.OrderByDescending(p => p.ReleaseDate);
                    break;
                default:
                    allProducts = allProducts.OrderBy(p => p.ReleaseDate);
                    break;
            }

            return allProducts;
        }
    }
}