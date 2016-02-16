namespace VinylC.Web.MVC.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models.Articles;
    using VinylC.Data.Models;
    using VinylC.Services.Data.Contracts;
    using VinylC.Web.MVC.Areas.Administration.Controllers.Base;

    // [Authorize(Roles = Roles.AdminRole)]
    public class ArticleController : BaseController
    {
        private IArticleService articlesService;
        private IAtricleCategoriesService articleCategoriesService;

        public ArticleController(IUserService usersService, IArticleService articlesService, IAtricleCategoriesService articleCategoriesService)
            :base(usersService)
        {
            this.articlesService = articlesService;
            this.articleCategoriesService = articleCategoriesService;
        }

        public ActionResult Index()
        {
            var categories = this.articleCategoriesService
                    .AllArticleCategories()
                    .Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name
                    });

            ViewBag.AtricleCategory = categories;

            return View();
        }

        public ActionResult ArticlesRead([DataSourceRequest]DataSourceRequest request)
        {
            var input = this.articlesService
                .AllArticles()
                .ProjectTo<ArticleAdminViewModel>();

            DataSourceResult result = input.ToDataSourceResult(request);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ArticlesCreate([DataSourceRequest]DataSourceRequest request, ArticleAdminViewModel article)
        {
            if (ModelState.IsValid && article != null)
            {
                var newArticle = Mapper.Map<Article>(article);

                newArticle.UserId = this.CurrentUser.Id;

                var result = this.articlesService.AddArticle(newArticle);

                Mapper.Map(result, article);
            }

            return Json(new[] { article }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ArticlesUpdate([DataSourceRequest]DataSourceRequest request, ArticleAdminViewModel article)
        {
            if (ModelState.IsValid && article != null)
            {
                var updated = AutoMapper.Mapper.Map<Article>(article);

                updated.UserId = this.CurrentUser.Id;
                var updatedmodel = this.articlesService
                    .UpdateArticle(updated)
                    .ProjectTo<ArticleAdminViewModel>()
                    .FirstOrDefault();
            }

            return Json(new[] { article }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ArticlesDestroy([DataSourceRequest]DataSourceRequest request, ArticleAdminViewModel article)
        {
            if (ModelState.IsValid && article != null)
            {
                this.articlesService.DeleteArticle(article.Id);
            }

            return Json(new[] { article }.ToDataSourceResult(request, ModelState));
        }
    }
}
