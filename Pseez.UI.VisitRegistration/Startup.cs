using Microsoft.Owin;
using Owin;
using Pseez.UI.VisitRegistration;

[assembly: OwinStartup(typeof (Startup))]

namespace Pseez.UI.VisitRegistration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}