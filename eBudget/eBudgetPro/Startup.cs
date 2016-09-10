using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eBudgetPro.Startup))]
namespace eBudgetPro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
