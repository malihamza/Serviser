using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Serviser_Web.Startup))]
namespace Serviser_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
