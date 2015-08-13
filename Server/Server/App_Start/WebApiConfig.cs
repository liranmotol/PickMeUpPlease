using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Server
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.EnableCors();
            config.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            JsonSerializerSettings jSettings = new Newtonsoft.Json.JsonSerializerSettings();
            config.Formatters.JsonFormatter.SerializerSettings = jSettings;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

        }
    }
}
