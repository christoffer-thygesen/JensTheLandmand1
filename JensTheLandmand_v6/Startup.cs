using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JensTheLandmand_v6.Startup))]
namespace JensTheLandmand_v6
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
