using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(Smartpos.Api.Startup1))]
namespace Smartpos.Api
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);

                var hubConfiguration = new HubConfiguration();
                map.RunSignalR(hubConfiguration);
            });
        }
    }
}
