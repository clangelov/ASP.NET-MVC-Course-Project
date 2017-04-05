namespace VinylC.Web.MVC.Infrastructure.ViewEngines
{
    using System.Web.Mvc;

    public class CSharpRazorViewEngine : RazorViewEngine
    {
        public CSharpRazorViewEngine()
        {
            this.AreaViewLocationFormats = new[]
            {
            "~/Areas/{2}/Views/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };
            this.AreaMasterLocationFormats = new[]
            {
            "~/Areas/{2}/Views/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };
            this.AreaPartialViewLocationFormats = new[]
            {
            "~/Areas/{2}/Views/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };
            this.ViewLocationFormats = new[]
            {
            "~/Views/{1}/{0}.cshtml",
            "~/Views/Shared/{0}.cshtml"
            };
            this.MasterLocationFormats = new[]
            {
            "~/Views/{1}/{0}.cshtml",
            "~/Views/Shared/{0}.cshtml"
            };
            this.PartialViewLocationFormats = new[]
            {
            "~/Views/{1}/{0}.cshtml",
            "~/Views/Shared/{0}.cshtml"
            };
        }
    }
}