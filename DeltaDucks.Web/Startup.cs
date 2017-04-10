using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeltaDucks.Web.Startup))]
namespace DeltaDucks.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
