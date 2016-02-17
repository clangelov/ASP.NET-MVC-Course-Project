namespace VinylC.Web.MVC.Areas.Private.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Data.Models;
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
                var result = this.productsService.AddRating(model.ProductId, (int)model.Value, this.CurrentUser.Id);

                return Json(result);               
            }

            throw new HttpException(400, "Invalid Rating");
        }

        public ActionResult GetProductRating(float rating)
        {
            return this.PartialView("~/Areas/Private/Views/Product/_ProductCurrentRatingPartial.cshtml", rating);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductSaveViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var newProduct = AutoMapper.Mapper.Map<Product>(model);

                if (model.File != null && model.File.ContentType == "image/jpeg" && model.File.ContentLength < 1048576)
                {
                    string filename = Path.GetFileName(model.File.FileName);
                    string folderPath = Server.MapPath("~/Content/Images/" + this.CurrentUser.Id);
                    string imagePath = folderPath + "/" + filename;
                    string imageUrl = "/Content/Images/" + this.CurrentUser.Id + "/" + filename;

                    if (!Directory.Exists(folderPath))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(folderPath);
                    }

                    model.File.SaveAs(imagePath);
                    newProduct.Picture = imageUrl;
                }
                else
                {
                    return this.View(model);
                }                

                newProduct.UserId = this.CurrentUser.Id;

                var result = this.productsService.AddProduct(newProduct);

                return this.RedirectToAction("Details", "Product", new { area = "Private", id = result.Id });
            }

            return this.View(model);
        }
    }
}