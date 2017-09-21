using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TallerDeMotos.Startup))]
namespace TallerDeMotos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
