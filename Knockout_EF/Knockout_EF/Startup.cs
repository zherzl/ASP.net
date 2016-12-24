using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Knockout_EF.Startup))]
namespace Knockout_EF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
