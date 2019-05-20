using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pseez.UI.Pmbok.Startup))]
namespace Pseez.UI.Pmbok
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
