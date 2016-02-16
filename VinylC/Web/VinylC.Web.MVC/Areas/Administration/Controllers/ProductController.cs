namespace VinylC.Web.MVC.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Base;
    using Data.Models;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data.Contracts;
    using VinylC.Web.MVC.Areas.Administration.Models.Products;

    // [Authorize(Roles = Roles.AdminRole)]
    public class ProductController : BaseController
    {
        private IProductService productsService;

        public ProductController(IUserService usersService, IProductService productsService)
            :base(usersService)
        {
            this.productsService = productsService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductAdminViewModels_Read([DataSourceRequest]DataSourceRequest request)
        {
            var input = this.productsService
                .AllProducts()
                .ProjectTo<ProductAdminViewModel>();

            DataSourceResult result = input.ToDataSourceResult(request);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProductAdminViewModels_Create([DataSourceRequest]DataSourceRequest request, ProductAdminViewModel model)
        {
            if (ModelState.IsValid && model != null)
            {
                var newProduct = AutoMapper.Mapper.Map<Product>(model);

                newProduct.UserId = this.CurrentUser.Id;

                var result = this.productsService.AddProduct(newProduct);

                Mapper.Map(result, model);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProductAdminViewModels_Update([DataSourceRequest]DataSourceRequest request, ProductAdminViewModel model)
        {
            if (ModelState.IsValid && model != null)
            {
                var updated = AutoMapper.Mapper.Map<Product>(model);          

                updated.UserId = this.CurrentUser.Id;
                var updatedmodel = this.productsService
                    .UpdateProduct(updated)
                    .ProjectTo<ProductAdminViewModel>()
                    .FirstOrDefault();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProductAdminViewModels_Destroy([DataSourceRequest]DataSourceRequest request, ProductAdminViewModel model)
        {
            if (ModelState.IsValid && model != null)
            {
                this.productsService.DeleteProduct(model.Id);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}
