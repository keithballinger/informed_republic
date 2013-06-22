using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BackendServer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Add RPC-style API
            config.Routes.MapHttpRoute(
                name: "hack2013",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );

#if false
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
#endif

        }
    }
}
