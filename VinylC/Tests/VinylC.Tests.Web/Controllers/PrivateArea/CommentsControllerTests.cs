using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace VinylC.Tests.Web.Controllers.PrivateArea
{
    using System.Web;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestStack.FluentMVCTesting;
    using VinylC.Services.Data.Contracts;
    using VinylC.Services.Web;
    using VinylC.Services.Web.Contracts;
    using VinylC.Web.MVC.Areas.Private.Controllers;
    using VinylC.Web.MVC.Areas.Private.Models.Articles;

    [TestClass]
    public class CommentsControllerTests
    {
        private CommentController controller;
        private ICommentService commentsService;
        private ISanitizer sanitizeService;
        private IUserService userService;
        private AddCommentViewModel model;

        [TestInitialize]
        public void Init()
        {
            this.sanitizeService = new HtmlSanitizerAdapter();
            this.commentsService = ObjectFactory.GetCommentService();
            this.userService = ObjectFactory.GetUserService();
            this.model = new AddCommentViewModel();
            this.controller = new CommentController(this.userService, this.commentsService, this.sanitizeService);
            this.controller.CurrentUser = this.userService.GetUser("test");
        }

        [TestMethod]
        public void TestIfCommentsPartialPageIsRendered()
        {
            this.controller
                .WithCallTo(c => c.GetPageCommentsPartial(2))
                .ShouldRenderPartialView("_ArticleCommentsPartial");
        }

        [TestMethod]
        [ExpectedException(typeof(HttpException), "Invalid Comment")]
        public void TestIfProductsAddCommnetReturn400WithNullAsModel()
        {
            this.controller
                .WithCallTo(c => c.AddComment(null));
        }

        [TestMethod]
        public void TestIfCommentValidationByCreatingIsWorking()
        {
            var context = new ValidationContext(this.model, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(model, context, results, true);

            Assert.IsTrue(results.Count == 1);
        }

        [TestMethod]
        public void TestIfAddCommentRedirectsToCorrectActionWithValidModel()
        {
            this.controller
                .WithCallTo(c => c.AddComment(this.model))
                .ShouldRenderPartialView("~/Areas/Private/Views/Comment/_SingleCommentPartial.cshtml");
        }
    }
}
