using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DataTableDemo.Startup))]
namespace DataTableDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
