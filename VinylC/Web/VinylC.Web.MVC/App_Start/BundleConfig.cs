namespace VinylC.Web.MVC
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo")
                .Include("~/Scripts/KendoUI/kendo.all.min.js")
                .Include("~/Scripts/KendoUI/kendo.aspnetmvc.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryajax").Include(
                      "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/registration").Include(
                      "~/Scripts/App/profile-picture-display.js"));

            bundles.Add(new ScriptBundle("~/bundles/customsearch").Include(
                      "~/Scripts/App/search-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/backbuttonlogic").Include(
                      "~/Scripts/App/back-button-logic.js"));

            bundles.Add(new ScriptBundle("~/bundles/chat").Include(
                      "~/Scripts/App/chat.js"));

            bundles.Add(new ScriptBundle("~/bundles/video").Include(
                      "~/Scripts/App/control-video.js"));

            bundles.Add(new ScriptBundle("~/bundles/progressbar").Include(
                      "~/Scripts/nprogress.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/progressbarcontrol").Include(
                      "~/Scripts/App/progress-bar-control.js"));

            bundles.Add(new ScriptBundle("~/bundles/maplogic").Include(
                      "~/Scripts/App/map-logic.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/comments").Include(
                      "~/Content/CommentsStyle.css"));

            bundles.Add(new StyleBundle("~/bundles/pagedlist").Include(
                    "~/Content/PagedList.css"));

            bundles.Add(new StyleBundle("~/bundles/homevideo").Include(
                    "~/Content/homeVideo.css"));

            bundles.Add(new StyleBundle("~/Content/progressbar").Include(
                    "~/Content/nprogress.css"));

            bundles.Add(new StyleBundle("~/Content/kendo").Include(
                      "~/Content/KendoUI/kendo.common-bootstrap.min.css",
                      "~/Content/KendoUI/kendo.default.min.css"));
            
        }
    }
}
