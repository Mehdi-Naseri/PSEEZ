using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pseez.UI.Cmms.Startup))]
namespace Pseez.UI.Cmms
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
