using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(pos.Startup))]
namespace pos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
