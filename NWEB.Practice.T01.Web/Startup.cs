using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NWEB.Practice.T01.Web.Startup))]
namespace NWEB.Practice.T01.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
