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
    using VinylC.Web.MVC.Areas.Private.Models.Messages;

    [TestClass]
    public class MessageControllerTests
    {
        private MessageController controller;
        private IMessageService messageService;
        private ISanitizer sanitizeService;
        private IUserService userService;
        private MessageSaveViewModel model;

        [TestInitialize]
        public void Init()
        {
            this.sanitizeService = new HtmlSanitizerAdapter();
            this.messageService = ObjectFactory.GetMessageService();
            this.userService = ObjectFactory.GetUserService();
            this.controller = new MessageController(this.userService, this.messageService, this.sanitizeService);
            this.model = new MessageSaveViewModel
            {
                ToUserName = "Test",
                ToUserId = "123456"
            };
            this.controller.CurrentUser = this.userService.GetUser("test");
        }

        [TestMethod]
        public void TestIfMessageSendPageIsRendered()
        {
            this.controller
                .WithCallTo(c => c.Send(this.model))
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void TestIfMessageValidationByCreatingIsWorking()
        {
            var context = new ValidationContext(this.model, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(model, context, results, true);

            Assert.IsTrue(results.Count == 1);
        }

        [TestMethod]
        public void TestIfCreatePageRedirectsToCorrectActionWithValidModel()
        {
            this.controller
                .WithCallTo(c => c.Create(this.model))
                 .ShouldRedirectTo<UserController>(typeof(UserController).GetMethod("Index"));
        }        
    }
}
