using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kolcen.Startup))]
namespace Kolcen
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
