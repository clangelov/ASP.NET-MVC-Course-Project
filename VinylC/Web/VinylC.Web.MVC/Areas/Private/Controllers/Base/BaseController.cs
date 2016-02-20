namespace VinylC.Web.MVC.Areas.Private.Controllers.Base
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Data.Models;
    using Services.Data.Contracts;
    using Services.Web.Contracts;

    [HandleError]
    public class BaseController : Controller
    {
        protected IUserService usersService;
        protected ISanitizer sanitizeService;

        public BaseController(IUserService usersService)
        {
            this.usersService = usersService;
        }

        public BaseController(IUserService usersService, ISanitizer sanitizeService)
        {
            this.usersService = usersService;
            this.sanitizeService = sanitizeService;
        }

        public User CurrentUser { get; set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.CurrentUser = this.usersService
                .GetUser(requestContext.HttpContext.User.Identity.Name);

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}