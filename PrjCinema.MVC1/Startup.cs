using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrjCinema.MVC.Startup))]
namespace PrjCinema.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
