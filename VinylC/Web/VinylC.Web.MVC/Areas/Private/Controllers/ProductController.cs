namespace VinylC.Web.MVC.Areas.Private.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Models.Products;
    using Models.Ratings;
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

        public ActionResult Details(int id)
        {
            var product = this.productsService
                .ProductById(id)
                .ProjectTo<ProductDetailsViewModel>()
                .FirstOrDefault();

            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Item not Found");
            }

            return this.View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRating(AddRatingVewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var result = this.productsService.AddRating(model.ProductId, (int)model.Value, model.UserId);

                return Json(result);               
            }

            throw new HttpException(400, "Invalid Rating");
        }

        public ActionResult GetProductRating(float rating)
        {
            return this.PartialView("~/Areas/Private/Views/Product/_ProductCurrentRatingPartial.cshtml", rating);
        }
    }
}