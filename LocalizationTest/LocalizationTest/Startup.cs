using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LocalizationTest.Startup))]
namespace LocalizationTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
