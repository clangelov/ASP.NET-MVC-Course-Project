namespace VinylC.Web.MVC
{
    using Infrastructure.ViewEngines;
    using System.Web.Mvc;

    public class ViewEnginesConfig
    {
        public static void RegisterViewEngines()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new CSharpRazorViewEngine());
        }
    }
}