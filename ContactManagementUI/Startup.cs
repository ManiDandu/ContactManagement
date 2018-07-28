using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContactManagementUI.Startup))]
namespace ContactManagementUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
