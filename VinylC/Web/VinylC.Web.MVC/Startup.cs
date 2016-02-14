using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VinylC.Web.MVC.Startup))]
namespace VinylC.Web.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
