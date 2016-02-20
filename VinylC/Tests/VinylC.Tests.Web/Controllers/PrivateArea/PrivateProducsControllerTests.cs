namespace VinylC.Tests.Web.Controllers.PrivateArea
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Net;
    using System.Web;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestStack.FluentMVCTesting;
    using VinylC.Services.Data.Contracts;
    using VinylC.Services.Web;
    using VinylC.Services.Web.Contracts;
    using VinylC.Web.MVC.Areas.Private.Controllers;
    using VinylC.Web.MVC.Areas.Private.Models.Products;
    using VinylC.Web.MVC.Areas.Private.Models.Ratings;

    [TestClass]
    public class PrivateProducsControllerTests
    {
        private ProductController controller;
        private IProductService productsService;
        private ISanitizer sanitizeService;
        private IUserService userService;

        [TestInitialize]
        public void Init()
        {
            this.sanitizeService = new HtmlSanitizerAdapter();
            this.productsService = ObjectFactory.GetProductService();
            this.userService = ObjectFactory.GetUserService();
            this.controller = new ProductController(this.userService, this.productsService, this.sanitizeService);
            this.controller.CurrentUser = this.userService.GetUser("test");
        }

        [TestMethod]
        public void TestIfProductsDetailsReturn404WithInvalidIdRequest()
        {
            this.controller
                .WithCallTo(c => c.Details(5))
                .ShouldGiveHttpStatus(HttpStatusCode.NotFound);
        }

        [TestMethod]
        public void TestIfArticleDetailsReturnCorectItem()
        {
            this.controller
                .WithCallTo(c => c.Details(1))
                .ShouldRenderDefaultView()
                .WithModel<ProductDetailsViewModel>(m => m.Title == "New iPhone 7");
        }

        [TestMethod]
        [ExpectedException(typeof(HttpException), "Invalid Rating")]
        public void TestIfProductsAddRatingReturn400WithInvalidModel()
        {
            this.controller
                .WithCallTo(c => c.AddRating(null));
        }

        [TestMethod]
        public void TestIfProductsAddVallidRatingWorks()
        {
            var newRating = new AddRatingVewModel
            {
                ProductId = 1,
                Value = 4
            };

            this.controller
                .WithCallTo(c => c.AddRating(newRating))
                .ShouldReturnJson(data =>
                {
                    Assert.IsNotNull(data);
                    Assert.IsTrue((float)data == 3.5f);
                });
        }

        [TestMethod]
        public void TestIfCreatePageIsRetuned()
        {
            this.controller
                .WithCallTo(c => c.Create())
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void TestIfProductValidationByCreatingIsWorking()
        {
            var model = new ProductSaveViewModel
            {
                Description = "Some Desc",
                Title = "Inv",
                File = null,
                Price = -100,
                ReleaseDate = DateTime.UtcNow.AddDays(-5)
            };

            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(model, context, results, true);

            Assert.IsTrue(results.Count == 5);
        }

        [TestMethod]
        public void TestIfCreatePageIsRetunningCorrectErrorsWithNullAsModel()
        {
            this.controller
                .WithCallTo(c => c.Create(null))
                .ShouldRenderDefaultView();
        }
    }
}
