namespace VinylC.Web.MVC.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models.Users;
    using VinylC.Data.Models;
    using VinylC.Services.Data.Contracts;
    using VinylC.Web.MVC.Areas.Administration.Controllers.Base;

    public class UserController : BaseController
    {
        public UserController(IUserService usersService)
            : base(usersService)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UsersRead([DataSourceRequest]DataSourceRequest request)
        {
            var input = this.usersService
                .All()
                .ProjectTo<UserAdminViewModel>();

            DataSourceResult result = input.ToDataSourceResult(request);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UsersUpdate([DataSourceRequest]DataSourceRequest request, UserAdminViewModel model)
        {
            if (ModelState.IsValid && model != null)
            {
                var currentData = this.usersService.GetUser(model.UserName);
                currentData.Avatar = model.Avatar;
                currentData.Email = model.Email;               

                var result = this.usersService.UpdateUser(currentData, model.Role);

                Mapper.Map(result, model);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UsersDestroy([DataSourceRequest]DataSourceRequest request, UserAdminViewModel model)
        {
            if (ModelState.IsValid && model != null)
            {
                this.usersService.DeleteUser(model.Id);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}
