using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace ETravel.Nps.Service
{
    public static class WebApiConfig
    {
        private static IWindsorContainer container;

        public static void Register(HttpConfiguration config)
        {
            // Setup dependency injection.
            container = new WindsorContainer().Install(FromAssembly.This());
            GlobalConfiguration.Configuration.Services.Replace(typeof (IHttpControllerActivator),new WindsorCompositionRoot(container));

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