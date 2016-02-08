namespace VinylC.Web.MVC.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        public ActionResult My404()
        {
            return View();
        }
    }
}