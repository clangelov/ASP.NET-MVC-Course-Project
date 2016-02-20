namespace VinylC.Tests.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VinylC.Services.Data.Contracts;
    using VinylC.Web.MVC.Controllers;

    [TestClass]
    public class ArticlesControllerTests
    {
        private ArticlesController controller;
        private IArticleService articles;
        private IAtricleCategoriesService categories;

        [TestInitialize]
        public void Init()
        {
            this.articles = ObjectFactory.GetArticleService();
            this.controller = new ArticlesController(this.articles, null);
        }
    }
}
