using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TMP_Identity.Startup))]
namespace TMP_Identity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
