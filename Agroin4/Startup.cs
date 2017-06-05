using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Agroin4.Startup))]
namespace Agroin4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
