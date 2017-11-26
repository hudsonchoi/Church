using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LandWeb.Startup))]
namespace LandWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
