using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EvidencijaRacunaObrta.Startup))]
namespace EvidencijaRacunaObrta
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
