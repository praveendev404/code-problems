using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ActionFiltersDemo.Startup))]
namespace ActionFiltersDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
