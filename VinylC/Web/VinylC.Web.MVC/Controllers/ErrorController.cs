namespace VinylC.Web.MVC.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        public ActionResult My404()
        {
            return View();
        }

        public ActionResult My500()
        {
            return View();
        }

        public ActionResult My400()
        {
            return View();
        }
    }
}