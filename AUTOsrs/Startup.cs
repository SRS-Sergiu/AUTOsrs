using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AUTOsrs.Startup))]
namespace AUTOsrs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
