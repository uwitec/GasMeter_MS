using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GasMeter_MS.Startup))]
namespace GasMeter_MS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
