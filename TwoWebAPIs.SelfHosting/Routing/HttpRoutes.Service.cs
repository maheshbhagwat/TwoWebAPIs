using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Http.SelfHost;

namespace TwoWebAPIs.Controllers.Routing
{
    class HttpRoutes
    {
        public static void AddWebAPIRoutes(HttpSelfHostConfiguration config)
        {
            config.Routes.MapHttpRoute(
                            name: "GetItemsByName",
                            routeTemplate: "v1/twowebapis/items/{name}",
                            defaults: new { controller = "Service", action = "GetItemsByName" },
                            constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) });

            config.Routes.MapHttpRoute(
                            name: "DeleteCategory",
                            routeTemplate: "v1/twowebapis/category",
                            defaults: new { controller = "Service", action = "Category" },
                            constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Delete) });
        }
    }
}
