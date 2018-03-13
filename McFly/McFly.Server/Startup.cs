using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using Owin;
using Swashbuckle.Application;

namespace McFly.Server
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "McFly API");
            }).EnableSwaggerUi();
            
            appBuilder.UseWebApi(config);
        }
    }
}