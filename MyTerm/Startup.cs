using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyTermMVC.Startup))]
namespace MyTermMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
