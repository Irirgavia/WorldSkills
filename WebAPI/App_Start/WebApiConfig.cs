using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiContrib.Formatting.Jsonp;
using System.Web.Http.Cors;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("http://localhost:7700", "*", "*");
            // Web API configuration and services
            config.EnableCors(cors);
            // Web API routes
            GlobalConfiguration.Configuration.AddJsonpFormatter();
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
            name: "ActionRoute",
            routeTemplate: "api/{controller}/{action}"
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
