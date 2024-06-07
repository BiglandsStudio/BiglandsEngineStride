using Microsoft.Owin;
using Owin;
using BiglandsEngine.Metrics.ServerApp;

[assembly: OwinStartup(typeof(BiglandsEngine.Metrics.ServerApp.Startup))]

namespace BiglandsEngine.Metrics.ServerApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseMetricServer();
        }
    }
}
