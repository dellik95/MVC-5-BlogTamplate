using Microsoft.Owin;
using MVC_5_BlogTamplate;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

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