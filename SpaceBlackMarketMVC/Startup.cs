using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpaceBlackMarketMVC.Startup))]
namespace SpaceBlackMarketMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
