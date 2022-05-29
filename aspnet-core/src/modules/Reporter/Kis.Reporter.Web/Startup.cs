using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(It2g.Reporter.Web.Startup))]
namespace It2g.Reporter.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
