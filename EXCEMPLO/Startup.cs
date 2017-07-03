using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EXCEMPLO.Startup))]
namespace EXCEMPLO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
