using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheCompany.Web.Frontend.Startup))]
namespace TheCompany.Web.Frontend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
