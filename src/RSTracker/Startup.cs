using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RSTracker.Startup))]
namespace RSTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
