using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EphtmltoPdf_V_9._5._0.Startup))]
namespace EphtmltoPdf_V_9._5._0
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
