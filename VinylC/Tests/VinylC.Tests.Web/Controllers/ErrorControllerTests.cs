namespace VinylC.Tests.Web.Controllers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestStack.FluentMVCTesting;
    using VinylC.Web.MVC.Controllers;

    [TestClass]
    public class ErrorControllerTests
    {
        private ErrorController controller;

        [TestInitialize]
        public void Init()
        {
            this.controller = new ErrorController();
        }

        [TestMethod]
        public void TestIfError400PageIsRetuned()
        {
            this.controller
                .WithCallTo(c => c.My400())
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void TestIfError404PageIsRetuned()
        {
            this.controller
                .WithCallTo(c => c.My404())
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void TestIfError500PageIsRetuned()
        {
            this.controller
                .WithCallTo(c => c.My500())
                .ShouldRenderDefaultView();
        }
    }
}
