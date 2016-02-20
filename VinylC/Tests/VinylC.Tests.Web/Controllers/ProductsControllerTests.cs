namespace VinylC.Tests.Web.Controllers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PagedList;
    using TestStack.FluentMVCTesting;
    using VinylC.Services.Data.Contracts;
    using VinylC.Web.MVC.Controllers;
    using VinylC.Web.MVC.Models.Products;

    [TestClass]
    public class ProductsControllerTests
    {
        private ProductsController controller;
        private IProductService productsService;

        [TestInitialize]
        public void Init()
        {
            this.productsService = ObjectFactory.GetProductService();
            this.controller = new ProductsController(this.productsService);
        }

        [TestMethod]
        public void TestIfAllPageIsRetuned()
        {
            this.controller
                .WithCallTo(c => c.All(string.Empty, string.Empty, null))
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void TestIfAllSortsByDate()
        {
            this.controller
                .WithCallTo(c => c.All(string.Empty, "Date", null))
                .ShouldRenderDefaultView()
                .WithModel<IPagedList<ProductsListViewModel>>(m => m[0].Title == "New iPhone 7");
        }

        [TestMethod]
        public void TestIfProductAllSortsByPriceAscending()
        {
            this.controller
                .WithCallTo(c => c.All(string.Empty, "Price", null))
                .ShouldRenderDefaultView()
                .WithModel<IPagedList<ProductsListViewModel>>(m => m[0].Title == "Audio-Technica Wireless");
        }

        [TestMethod]
        public void TestIfProductAllSortsByPriceDescending()
        {
            this.controller
                .WithCallTo(c => c.All(string.Empty, "price_desc", null))
                .ShouldRenderDefaultView()
                .WithModel<IPagedList<ProductsListViewModel>>(m => m[0].Title == "New iPhone 7");
        }

        [TestMethod]
        public void TestIfProductAllSortsByRatingAscending()
        {
            this.controller
                .WithCallTo(c => c.All(string.Empty, "Rating", null))
                .ShouldRenderDefaultView()
                .WithModel<IPagedList<ProductsListViewModel>>(m => m[0].Title == "Audio-Technica Wireless");
        }

        [TestMethod]
        public void TestIfProductAllSortsByRatingDescending()
        {
            this.controller
                .WithCallTo(c => c.All(string.Empty, "rating_desc", null))
                .ShouldRenderDefaultView()
                .WithModel<IPagedList<ProductsListViewModel>>(m => m[0].Title == "New iPhone 7");
        }

        [TestMethod]
        public void TestIfProductSearchPageReturnsNoResultsWithEmptyString()
        {
            this.controller
                .WithCallTo(c => c.Search("Invalid Search"))
                .ShouldReturnContent("<h1 class=\"text-danger text-center\">No results found</h1>");
        }

        [TestMethod]
        public void TestIfProductSearchPageReturnsCorrectView()
        {
            this.controller
                .WithCallTo(c => c.Search("iPhone"))
                .ShouldRenderPartialView("_ProductsListPartial")
                .WithModel<IPagedList<ProductsListViewModel>>();
        }
    }
}
