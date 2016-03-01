using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BnB.Startup))]
namespace BnB
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
