namespace VinylC.Web.MVC.Areas.Private.Controllers.Base
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Data.Models;
    using Services.Data.Contracts;

    [HandleError]
    public class BaseController : Controller
    {
        protected IUserService usersService;

        public BaseController(IUserService usersService)
        {
            this.usersService = usersService;
        }

        protected User CurrentUser { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.CurrentUser = this.usersService
                .GetUser(requestContext.HttpContext.User.Identity.Name);

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}