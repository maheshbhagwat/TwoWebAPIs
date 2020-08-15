using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.SelfHost;
using TwoWebAPIs.Controllers.Routing;

namespace TwoWebAPIs.SelfHosting
{
    class Startup
    {
        static void Main(string[] args)
        {
            using (SelfhostingServer server = new SelfhostingServer())
            {
                server.Start();
            }
        }
    }

    public class SelfhostingServer : IDisposable
    {
        private const string hostingUrl = "http://localhost:8383";
        private HttpSelfHostServer selfHostingServer;
        private bool disposed = false;

        public void Start()
        {
            var hostconfig = configure();
            selfHostingServer = new HttpSelfHostServer(hostconfig);
            selfHostingServer.OpenAsync().Wait();
            Console.WriteLine("Service is Running. Please Enter to stop the service !!");
            Console.ReadLine();


        }
        private HttpSelfHostConfiguration configure()
        {
            HttpSelfHostConfiguration hostconfig = new HttpSelfHostConfiguration(hostingUrl);
            HttpRoutes.AddWebAPIRoutes(hostconfig);

            hostconfig.Services.Replace(typeof(IHttpControllerActivator), new CustomHttpControllerActivator());

            hostconfig.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });

            hostconfig.MessageHandlers.Add(new GlobalErrorHandler());
            return hostconfig;
        }

        public void Stop()
        {
            if (selfHostingServer != null)
            {
                selfHostingServer.CloseAsync();
                selfHostingServer.Dispose();
                selfHostingServer = null;
            }

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                this.Stop();
            }
            disposed = true;
        }
    }
}
