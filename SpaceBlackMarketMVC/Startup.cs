using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using SpaceBlackMarketMVC.Data;

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
