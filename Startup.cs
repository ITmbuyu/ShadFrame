using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShadFrame.Startup))]
namespace ShadFrame
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
