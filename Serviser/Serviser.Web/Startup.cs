using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Serviser.Web.Startup))]
namespace Serviser.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
