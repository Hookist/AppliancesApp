using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppliancesApp.Startup))]
namespace AppliancesApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
