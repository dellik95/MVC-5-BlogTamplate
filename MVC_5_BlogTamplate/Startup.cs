using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_5_BlogTamplate.Startup))]
namespace MVC_5_BlogTamplate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
