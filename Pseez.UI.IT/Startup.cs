using Microsoft.Owin;
using Owin;
using Pseez.UI.IT;

[assembly: OwinStartup(typeof (Startup))]

namespace Pseez.UI.IT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}