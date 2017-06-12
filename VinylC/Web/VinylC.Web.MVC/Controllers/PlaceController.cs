namespace VinylC.Web.MVC.Controllers
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Common.Constants;
    using Data.Models;
    using Models.Places;
    using Models.Tags;
    using Services.Data.Contracts;
    using VinylC.Common.Regex;
    using System.Linq;

    public class PlaceController : Controller
    {
        private const int MostPopularTagsCount = 12;

        private IPlaceService placeService;
        private ITagService tagsService;

        public PlaceController(IPlaceService placeService, ITagService tagsService)
        {
            this.placeService = placeService;
            this.tagsService = tagsService;
        }

        public ActionResult Index(int? id)
        {
            IEnumerable<PlacesListViewModel> model;

            if (id == null)
            {
                model = this.placeService
                .AllPlaces()
                .ProjectTo<PlacesListViewModel>();
            }
            else
            {
                int searchId = id ?? default(int);
                model = this.placeService
                .AllByTag(searchId)
                .ProjectTo<PlacesListViewModel>();
            }

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

        public ActionResult GetPopularTags()
        {
            var result = this.tagsService
                .MostPopular(MostPopularTagsCount)
                .ProjectTo<TagsListViewModel>();

            return this.PartialView("_PopularTags", result);
        }

        private List<string> ExtractTagsFromOpinion(string opinion)
        {
            List<string> result = new List<string>();

            Regex myRegex = new HashTagPattern();

            foreach (Match myMatch in myRegex.Matches(opinion))
            {
                if (myMatch.Success)
                {
                    result.Add(myMatch.ToString());
                }
            }

            return result.Distinct().ToList();
        }
    }
}