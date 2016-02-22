namespace VinylC.Web.MVC.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Services.Data.Contracts;

    public class PlaceController : Controller
    {
        private IPlaceService placeService;

        public PlaceController(IPlaceService placeService)
        {
            this.placeService = placeService;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}