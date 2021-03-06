﻿namespace VinylC.Web.MVC.Areas.Private.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Base;
    using Data.Models;
    using Models.Articles;
    using Services.Data.Contracts;
    using Services.Web.Contracts;

    [Authorize]
    public class ArticleController : BaseController
    {
        private IArticleService articlesService;
        private IAtricleCategoriesService articleCategoriesService;

        public ArticleController(IUserService usersService, IArticleService articlesService, IAtricleCategoriesService articleCategoriesService, ISanitizer sanitizeService)
            :base(usersService, sanitizeService)
        {
            this.articlesService = articlesService;
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
                model.Title = this.sanitizeService.Sanitize(model.Title);
                model.Contetnt = this.sanitizeService.Sanitize(model.Contetnt);

                var newArticle = AutoMapper.Mapper.Map<Article>(model);

                newArticle.UserId = this.CurrentUser.Id;

                var result = this.articlesService.AddArticle(newArticle);

                return this.RedirectToAction("Details", "Articles", new { area = "", id = result.Id });
            }

            return this.View(model);
        }
    }
}