namespace VinylC.Tests.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using PagedList;
    using TestStack.FluentMVCTesting;
    using VinylC.Services.Data.Contracts;
    using VinylC.Web.MVC.Areas.Private.Models.Articles;
    using VinylC.Web.MVC.Controllers;
    using VinylC.Web.MVC.Models.Articles;

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
            this.categories = ObjectFactory.GetAtricleCategoriesService();
            this.controller = new ArticlesController(this.articles, this.categories);
        }

        [TestMethod]
        public void TestIfArticleAllPageIsRetuned()
        {
            this.controller
                .WithCallTo(c => c.All(string.Empty, null))
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void TestIfArticleAllSortsByDateAscending()
        {
            this.controller
                .WithCallTo(c => c.All("Date", null))
                .ShouldRenderDefaultView()
                .WithModel<IPagedList<ArticlesListViewModel>>(m => m[0].Title == "Kendrick Lamar smashing new Album");
        }

        [TestMethod]
        public void TestIfArticleAllSortsByTitleAscending()
        {
            this.controller
                .WithCallTo(c => c.All("Name", null))
                .ShouldRenderDefaultView()
                .WithModel<IPagedList<ArticlesListViewModel>>(m => m[0].Title == "Kendrick Lamar smashing new Album");
        }

        [TestMethod]
        public void TestIfArticleAllSortsByTitleDescending()
        {
            this.controller
                .WithCallTo(c => c.All("name_desc", null))
                .ShouldRenderDefaultView()
                .WithModel<IPagedList<ArticlesListViewModel>>(m => m[0].Title == "Nas, 'Illmatic' At 20");
        }

        [TestMethod]
        public void TestIfArticleDetailsReturn404WithInvalidIdRequest()
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
                .WithModel<ArticlesDetailsViewModel>(m => m.Title == "Nas, 'Illmatic' At 20");
        }

        [TestMethod]
        public void TestIfArticlesCategoriesPartialPageIsRetuned()
        {
            this.controller
                .WithCallTo(c => c.GetCategoriesPartial())
                .ShouldRenderPartialView("_CategoriesPartial")
                .WithModel<IEnumerable<ArticlesCategoriesViewModel>>();
        }

        [TestMethod]
        public void TestIfArticlesSearchPartialPageIsRetuned()
        {
            this.controller
                .WithCallTo(c => c.GetSearchProductsPartial())
                .ShouldRenderPartialView("_SearchViewPartial");
        }

        [TestMethod]
        public void TestIfArticlesSearchReturnsEmptyJSONWithInvalidSearch()
        {
            this.controller
                .WithCallTo(c => c.GetSearchResults("Invalid"))
                .ShouldReturnJson(data =>
                {
                    Assert.IsTrue(((List<ArticlesListViewModel>)data).Count == 0);  
                });
        }

        [TestMethod]
        public void TestIfArticlesSearchReturnsCorrectJSON()
        {
            this.controller
                .WithCallTo(c => c.GetSearchResults("Lamar"))
                .ShouldReturnJson(data =>
                {
                    Assert.IsTrue(((List<ArticlesListViewModel>)data).Count == 1);
                    Assert.IsTrue(((List<ArticlesListViewModel>)data)[0].Title == "Kendrick Lamar smashing new Album");
                });
        }

        [TestMethod]
        public void TestIfArticleBYCategoryReturnsCorrectView()
        {
            this.controller
                .WithCallTo(c => c.Category(null, "Valid Category", null))
                .ShouldRenderDefaultView()
                .WithModel<IPagedList<ArticlesListViewModel>>();
        }
    }
}
