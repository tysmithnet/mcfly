// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tysmithnet
// Created          : 03-12-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-16-2018
// ***********************************************************************
// <copyright file="Startup.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.Composition.Hosting;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using McFly.Server.Headers;
using Owin;
using Swashbuckle.Application;

namespace McFly.Server
{
    /// <summary>
    ///     Class Startup.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        /// <summary>
        ///     Configurations the specified application builder.
        /// </summary>
        /// <param name="appBuilder">The application builder.</param>
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            var executingAssemblyFile = Assembly.GetExecutingAssembly().Location;
            var executingDirectory = Path.GetDirectoryName(executingAssemblyFile);
            var mcFlyAssemblies =
                Directory.EnumerateFiles(executingDirectory, "McFly*.dll", SearchOption.AllDirectories);
            var assemblies = mcFlyAssemblies.Select(Assembly.LoadFile).Select(a => new AssemblyCatalog(a));
            var executingAssembly = Assembly.GetExecutingAssembly();
            var executingAssemblyCatalog = new AssemblyCatalog(executingAssembly);
            var aggregateCatalog = new AggregateCatalog(assemblies.Concat(new[] {executingAssemblyCatalog}));
            var compositionContainer = new CompositionContainer(aggregateCatalog);

            var mefDependencyResolver = new MefDependencyResolver(compositionContainer, config.DependencyResolver);
            config.DependencyResolver = mefDependencyResolver;
            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "McFly API");
                c.OperationFilter(() => new FromHeaderAttributeOperationFilter());
            }).EnableSwaggerUi();

            appBuilder.UseWebApi(config);
        }
    }
}