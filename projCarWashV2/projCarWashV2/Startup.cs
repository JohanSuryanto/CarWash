using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(projCarWashV2.Startup))]
namespace projCarWashV2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
