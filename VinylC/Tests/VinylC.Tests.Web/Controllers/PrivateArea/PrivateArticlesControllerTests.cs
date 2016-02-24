namespace VinylC.Tests.Web.Controllers.PrivateArea
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestStack.FluentMVCTesting;
    using VinylC.Services.Data.Contracts;
    using VinylC.Services.Web;
    using VinylC.Services.Web.Contracts;
    using VinylC.Web.MVC.Areas.Private.Controllers;
    using VinylC.Web.MVC.Areas.Private.Models.Articles;
    using VinylC.Web.MVC.Controllers;

    [TestClass]
    public class PrivateArticlesControllerTests
    {
        private ArticleController controller;
        private IArticleService articlesService;
        private ISanitizer sanitizeService;
        private IUserService userService;
        private IAtricleCategoriesService categories;

        [TestInitialize]
        public void Init()
        {
            this.sanitizeService = new HtmlSanitizerAdapter();
            this.articlesService = ObjectFactory.GetArticleService();
            this.userService = ObjectFactory.GetUserService();
            this.categories = ObjectFactory.GetAtricleCategoriesService();
            this.controller = new ArticleController(this.userService, this.articlesService, this.categories, this.sanitizeService);
            this.controller.CurrentUser = this.userService.GetUser("test");
        }

        [TestMethod]
        public void TestIfCreatePageIsRetunedWithCorrectData()
        {
            this.controller
                .WithCallTo(c => c.Create())
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void TestIfrticleValidationByCreatingIsWorking()
        {
            var model = new ArticlesSaveViewModel
            {
                Contetnt = "Invalid",
                Title = "Inv",
                ImageUrl = "invalid"
            };

            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(model, context, results, true);

            Assert.IsTrue(results.Count == 3);
        }

        [TestMethod]
        public void TestIfCreatePageIsRetunningCorrectErrorsWithNullAsModel()
        {
            this.controller
                .WithCallTo(c => c.Create(null))
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void TestIfCreatePageRedirectsToCorrectActionWithValidModel()
        {
            var articleToAdd = new ArticlesSaveViewModel()
            {
                Contetnt = "There are few artists in hip-hop who have ever truly matched their hype.",
                Title = "Nas, 'Illmatic' At 20",
                ImageUrl = "http://ebid.s3.amazonaws.com/upload_big/1/2/3/1405024178-12177-9126.jpg"
            };

            this.controller
                .WithCallTo(c => c.Create(articleToAdd))
                 .ShouldRedirectTo<ArticlesController>(typeof(ArticlesController).GetMethod("Details"));
        }
    }
}
