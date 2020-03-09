using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCCapstone.Startup))]
namespace MVCCapstone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
