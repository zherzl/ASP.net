using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebShop_tema2.Startup))]
namespace WebShop_tema2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
