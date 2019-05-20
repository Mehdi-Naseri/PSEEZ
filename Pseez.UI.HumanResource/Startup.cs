using Microsoft.Owin;
using Owin;
using Pseez.UI.HumanResource;

[assembly: OwinStartup(typeof (Startup))]

namespace Pseez.UI.HumanResource
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}