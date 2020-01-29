using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KnockOutJsDemo.Startup))]
namespace KnockOutJsDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
