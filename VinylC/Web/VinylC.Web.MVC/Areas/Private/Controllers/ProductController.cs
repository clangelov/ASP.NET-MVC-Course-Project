namespace VinylC.Web.MVC.Areas.Private.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using VinylC.Services.Data.Contracts;
    using VinylC.Web.MVC.Areas.Private.Controllers.Base;

    [Authorize]
    public class ProductController : BaseController
    {
        private IProductService productsService;

        public ProductController(IUserService usersService, IProductService productsService)
            :base(usersService)
        {
            this.productsService = productsService;
        }

        // GET: Private/Product
        public ActionResult Index()
        {
            return View();
        }
    }
}