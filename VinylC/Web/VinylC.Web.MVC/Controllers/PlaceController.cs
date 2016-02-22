namespace VinylC.Web.MVC.Controllers
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Common.Constants;
    using Data.Models;
    using Models.Places;
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
            var model = this.placeService
                .AllPlaces()
                .ProjectTo<PlacesListViewModel>();

            return View(model);
        }

        [HttpPost]
        public ActionResult SendOpinion(string placeId, string opinion)
        {
            int cuurentPlaceId = int.Parse(placeId);

            if (opinion.Length > ModelConstants.MinOpinionLenght || opinion.Length < ModelConstants.MessageMaxLenght)
            {
                var newOpinion = new Opinion
                {
                    Content = opinion,
                    PlaceId = cuurentPlaceId
                };

                this.placeService.AddNewOpinion(newOpinion);

                List<string> tags = ExtractTagsFromOpinion(opinion);

                this.placeService.AddTags(cuurentPlaceId, tags);
            }

            return this.RedirectToAction("Index");
        }

        private List<string> ExtractTagsFromOpinion(string opinion)
        {
            List<string> result = new List<string>();

            string regexCondition = @"#[A-Za-z0-9]{3,}";

            Regex myRegex = new Regex(regexCondition, RegexOptions.None);

            foreach (Match myMatch in myRegex.Matches(opinion))
            {
                if (myMatch.Success)
                {
                    result.Add(myMatch.ToString());
                }
            }

            return result;
        }
    }
}