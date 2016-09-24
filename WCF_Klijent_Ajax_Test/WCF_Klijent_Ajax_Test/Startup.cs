using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WCF_Klijent_Ajax_Test.Startup))]
namespace WCF_Klijent_Ajax_Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
