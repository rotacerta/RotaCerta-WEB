using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PBP_Frontend.Startup))]
namespace PBP_Frontend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
