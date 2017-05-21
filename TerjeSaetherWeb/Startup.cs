using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TerjeSaetherWeb.Startup))]
namespace TerjeSaetherWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
