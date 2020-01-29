using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EopdfEx.Startup))]
namespace EopdfEx
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
