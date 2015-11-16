using System.Web.Http;
using System.Web.Mvc;

namespace ETravel.Nps.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Nps API",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Register help page.
            AreaRegistration.RegisterAllAreas();
        }
    }
}
