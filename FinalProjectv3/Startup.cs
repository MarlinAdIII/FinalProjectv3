using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalProjectv3.Startup))]
namespace FinalProjectv3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
