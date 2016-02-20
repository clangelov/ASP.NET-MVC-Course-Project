namespace VinylC.Tests.Web.Controllers
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Services.Data.Contracts;
    using Services.Web;
    using Services.Web.Contracts;
    using TestStack.FluentMVCTesting;
    using VinylC.Web.MVC.Controllers;
    using VinylC.Web.MVC.Models.Articles;
    using VinylC.Web.MVC.Models.Products;

    [TestClass]
    public class HomeControllerTests
    {
        private HomeController controller;
        private ICacheService cacheService;
        private IProductService productsService;
        private IArticleService articlesService;

        [TestInitialize]
        public void Init()
        {
            this.cacheService = new HttpCacheService();
            this.productsService = ObjectFactory.GetProductService();
            this.articlesService = ObjectFactory.GetArticleService();
            this.controller = new HomeController(this.cacheService, this.productsService, this.articlesService);
        }

        [TestMethod]
        public void TestIfIndexPageIsRetuned()
        {
            this.controller
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void TestIfArticlesPartialPageIsRetuned()
        {
            this.controller
                .WithCallTo(c => c.GetArticlesPartial())
                .ShouldRenderPartialView("_SimpleArticlesPartial")
                .WithModel<IEnumerable<ArticleSimpleViewModel>>();
        }

        [TestMethod]
        public void TestIfProductsPartialPageIsRetuned()
        {
            this.controller
                .WithCallTo(c => c.GetProductsPartial())
                .ShouldRenderPartialView("_SimpleProductsPartial")
                .WithModel<IEnumerable<ProductSimpleListViewModel>>();
        }
    }
}
