namespace VinylC.Web.MVC.Areas.Private.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Models;
    using Services.Data.Contracts;

    [Authorize]
    public class ArticleController : Controller
    {
        private IArticleService articlesService;
        private IUserService userService;
        private IAtricleCategoriesService articleCategoriesService;

        public ArticleController(IUserService userService, IArticleService articlesService, IAtricleCategoriesService articleCategoriesService)
        {
            this.articlesService = articlesService;
            this.userService = userService;
            this.articleCategoriesService = articleCategoriesService;
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            var model = new ArticlesSaveViewModel
            {
                AtricleCategory = this.articleCategoriesService
                    .AllArticleCategories()
                    .Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name
                    })
            };

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticlesSaveViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var newArticle = AutoMapper.Mapper.Map<Article>(model);

                newArticle.UserId = this.userService.GetUser(this.User.Identity.Name).Id;

                var result = this.articlesService.AddArticle(newArticle);

                return this.RedirectToAction("Details", "Articles", new { area = "", id = result.Id });
            }

            return this.View(model);
        }
    }
}