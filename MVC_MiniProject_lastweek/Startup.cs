using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_MiniProject_lastweek.Startup))]
namespace MVC_MiniProject_lastweek
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
