﻿using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http;
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
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional}
            );

            var executingAssemblyFile = Assembly.GetExecutingAssembly().Location;
            var executingDirectory = Path.GetDirectoryName(executingAssemblyFile);
            var mcFlyAssemblies = Directory.EnumerateFiles(executingDirectory, "McFly*.dll", SearchOption.AllDirectories);
            var assemblies = mcFlyAssemblies.Select(Assembly.LoadFile).Select(a => new AssemblyCatalog(a));
            var executingAssembly = Assembly.GetExecutingAssembly();
            var executingAssemblyCatalog = new AssemblyCatalog(executingAssembly);
            var aggregateCatalog = new AggregateCatalog(assemblies.Concat(new [] {executingAssemblyCatalog}));
            var compositionContainer = new CompositionContainer(aggregateCatalog);

            var mefDependencyResolver = new MefDependencyResolver(compositionContainer, config.DependencyResolver);
            config.DependencyResolver = mefDependencyResolver;
            config.EnableSwagger(c => { c.SingleApiVersion("v1", "McFly API"); }).EnableSwaggerUi();

            appBuilder.UseWebApi(config);
        }
    }
}