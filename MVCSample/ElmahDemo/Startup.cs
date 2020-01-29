using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ElmahDemo.Startup))]
namespace ElmahDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
