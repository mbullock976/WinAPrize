using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WinAPrize.Startup))]
namespace WinAPrize
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
