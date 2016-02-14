namespace VinylC.Web.MVC.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    [Authorize]
    public class ChatController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}