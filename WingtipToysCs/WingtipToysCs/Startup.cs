using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WingtipToysCs.Startup))]
namespace WingtipToysCs
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
