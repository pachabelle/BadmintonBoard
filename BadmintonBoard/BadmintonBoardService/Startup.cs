using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BadmintonBoardService.Startup))]

namespace BadmintonBoardService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}