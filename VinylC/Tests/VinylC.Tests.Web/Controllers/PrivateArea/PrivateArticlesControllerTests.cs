namespace VinylC.Tests.Web.Controllers.PrivateArea
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VinylC.Services.Data.Contracts;
    using VinylC.Services.Web;
    using VinylC.Services.Web.Contracts;
    using VinylC.Web.MVC.Areas.Private.Controllers;

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
    }
}
