namespace VinylC.Web.MVC.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Areas.Private.Models.Articles;
    using AutoMapper.QueryableExtensions;
    using Models.Articles;
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

        public ActionResult All(string sortOrder, int? page)
        {
            var articles = this.articles
                .AllArticles()
                .ProjectTo<ArticlesListViewModel>();

            int pageNumber = page ?? 1;

            var sorted = this.GetSorted(articles, sortOrder);

            return this.View(sorted.ToPagedList(pageNumber, PageSize));
        }

        public ActionResult Category(string sortOrder, string id, int? page)
        {
            var articles = this.articles
                .AllByCategory(id)
                .ProjectTo<ArticlesListViewModel>();

            int pageNumber = page ?? 1;

            var sorted = this.GetSorted(articles, sortOrder);

            return this.View(sorted.ToPagedList(pageNumber, PageSize));
        }

        public ActionResult Details(int id)
        {
            var article = this.articles
                .ArticleById(id)
                .ProjectTo<ArticlesDetailsViewModel>()
                .FirstOrDefault();

            if (article == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Item not Found");
            }

            return this.View(article);
        }

        [HttpGet]
        [ChildActionOnly]
        [OutputCache (Duration = 5 * 60)]
        public ActionResult GetCategoriesPartial()
        {
            var categories = this.categories
                .AllArticleCategories()
                .ProjectTo<ArticlesCategoriesViewModel>();

            return this.PartialView("_CategoriesPartial", categories);
        }

        private IQueryable<ArticlesListViewModel> GetSorted(IQueryable<ArticlesListViewModel> allArticles, string sortOrder)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "Date" : "";
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";

            switch (sortOrder)
            {
                case "Name":
                    allArticles = allArticles.OrderBy(a => a.Title);
                    break;
                case "name_desc":
                    allArticles = allArticles.OrderByDescending(a => a.Title);
                    break;
                case "Date":
                    allArticles = allArticles.OrderBy(a => a.PostedOn);
                    break;
                default:  
                    allArticles = allArticles.OrderByDescending(a => a.PostedOn);
                    break;
            }

            return allArticles;
        }
    }
}