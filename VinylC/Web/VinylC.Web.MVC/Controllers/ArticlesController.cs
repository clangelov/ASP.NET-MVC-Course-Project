namespace VinylC.Web.MVC.Controllers
{
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Models.Articles;
    using Models.ArticlesCategories;
    using PagedList;
    using VinylC.Services.Data.Contracts;

    public class ArticlesController : Controller
    {
        private const int PageSize = 3;

        private IArticleService articles;
        private IAtricleCategoriesService categories;

        public ArticlesController(IArticleService articles, IAtricleCategoriesService categories)
        {
            this.articles = articles;
            this.categories = categories;
        }

        public ActionResult All(int? page)
        {
            var articles = this.articles
                .AllArticles()
                .ProjectTo<ArticlesListViewModel>();

            int pageNumber = page ?? 1;

            return this.View(articles.ToPagedList(pageNumber, PageSize));
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetCategoriesPartial()
        {
            var categories = this.categories
                .AllArticleCategories()
                .ProjectTo<ArticlesCategoriesViewModel>();

            return this.PartialView("_CategoriesPartial", categories);
        }
    }
}