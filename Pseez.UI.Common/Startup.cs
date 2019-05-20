using Microsoft.Owin;
using Owin;
using Pseez.UI.Common;

[assembly: OwinStartup(typeof (Startup))]

namespace Pseez.UI.Common
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}