namespace VinylC.Web.MVC.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Base;
    using Common.Constants;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models.Category;
    using Services.Data.Contracts;
    using VinylC.Data.Models;

    [Authorize(Roles = Roles.AdminRole)]
    public class CategoryController : BaseController
    {
        private IArticleCategoryService categoryService;

        public CategoryController(IUserService usersService, IArticleCategoryService categoryService)
            :base(usersService)
        {
            this.categoryService = categoryService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AtricleCategoriesRead([DataSourceRequest]DataSourceRequest request)
        {
            var input = this.categoryService
                .All()
                .ProjectTo<CategoryAdminViewModel>();

            DataSourceResult result = input.ToDataSourceResult(request);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AtricleCategoriesCreate([DataSourceRequest]DataSourceRequest request, CategoryAdminViewModel model)
        {
            if (ModelState.IsValid && model != null)
            {
                var newCategory = Mapper.Map<AtricleCategory>(model);

                var result = this.categoryService.CreateNewCategory(newCategory);

                Mapper.Map(result, model);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AtricleCategoriesUpdate([DataSourceRequest]DataSourceRequest request, CategoryAdminViewModel model)
        {
            if (ModelState.IsValid && model != null)
            {
                var updatedCategory = Mapper.Map<AtricleCategory>(model);

                var result = this.categoryService.UpdateCategory(updatedCategory);

                Mapper.Map(result, model);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}
