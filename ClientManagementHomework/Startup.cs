using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClientManagementHomework.Startup))]
namespace ClientManagementHomework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
