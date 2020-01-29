using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PdfConvert.Startup))]
namespace PdfConvert
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
