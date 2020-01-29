using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EvoPdfConverterEx.Startup))]
namespace EvoPdfConverterEx
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
