namespace VinylC.Web.MVC.Controllers
{
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Models.Articles;
    using PagedList;
    using VinylC.Services.Data.Contracts;

    public class ArticlesController : Controller
    {
        private const int PageSize = 3;

        private IArticleService articles;

        public ArticlesController(IArticleService articles)
        {
            this.articles = articles;
        }

        public ActionResult All(int? page)
        {
            var articles = this.articles
                .AllArticles()
                .ProjectTo<ArticlesListViewModel>();

            int pageNumber = page ?? 1;

            return this.View(articles.ToPagedList(pageNumber, PageSize));
        }
    }
}