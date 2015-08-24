using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(wm.sqlsat.alt.UI.Startup))]
namespace wm.sqlsat.alt.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
