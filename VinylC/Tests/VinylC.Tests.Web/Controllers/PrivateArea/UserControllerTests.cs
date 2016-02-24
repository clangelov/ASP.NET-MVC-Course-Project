namespace VinylC.Tests.Web.Controllers.PrivateArea
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestStack.FluentMVCTesting;
    using VinylC.Services.Data.Contracts;
    using VinylC.Services.Web;
    using VinylC.Services.Web.Contracts;
    using VinylC.Web.MVC.Areas.Private.Controllers;

    [TestClass]
    public class UserControllerTests
    {
        private UserController controller;
        private IMessageService messageService;
        private ICacheService cacheService;
        private IUserService userService;

        [TestInitialize]
        public void Init()
        {
            this.cacheService = new HttpCacheService();
            this.messageService = ObjectFactory.GetMessageService();
            this.userService = ObjectFactory.GetUserService();
            this.controller = new UserController(this.userService, this.messageService, this.cacheService);
            this.controller.CurrentUser = this.userService.GetUser("test");
        }

        [TestMethod]
        public void TestIfIndexPageIsRetuned()
        {
            this.controller
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }
    }
}
