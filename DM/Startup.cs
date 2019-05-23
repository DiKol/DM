using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DM.Startup))]
namespace DM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
