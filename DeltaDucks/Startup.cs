using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeltaDucks.Startup))]
namespace DeltaDucks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
