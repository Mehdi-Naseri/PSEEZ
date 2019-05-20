using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pseez.Startup))]
namespace Pseez
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
