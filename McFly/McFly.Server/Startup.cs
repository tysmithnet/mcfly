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

using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.ModelBinding.Binders;
using Common.Logging;
using McFly.Server.Contract;
using McFly.Server.Data;
using McFly.Server.Headers;
using Owin;
using Swashbuckle.Application;

namespace McFly.Server
{
    /// <summary>
    ///     Represents the start up logic for the application
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        private ILog Log = LogManager.GetLogger<Startup>();

        /// <summary>
        ///     Configurations the specified application builder.
        /// </summary>
        /// <param name="appBuilder">The application builder.</param>
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.Use<LoggingMiddleware>();
            var config = new HttpConfiguration();
            //var provider = new SimpleModelBinderProvider(typeof(Criterion), new SearchRequestJsonConverter());
            //config.Services.Insert(typeof(ModelBinderProvider), 0, provider);
            var formatters = config.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.Converters.Add(new SearchRequestJsonConverter());
            config.MapHttpAttributeRoutes();
            // todo: extract
            var mefDependencyResolver = GetDependencyResolver(config);
            config.DependencyResolver = mefDependencyResolver;
            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "McFly API");
                c.OperationFilter(() => new FromHeaderAttributeOperationFilter());
            }).EnableSwaggerUi();

            appBuilder.UseWebApi(config);
        }

        private MefDependencyResolver GetDependencyResolver(HttpConfiguration config)
        {
            Log.Info("Looking for MEF components");
            var executingAssemblyFile = Assembly.GetExecutingAssembly().Location;
            var executingDirectory = Path.GetDirectoryName(executingAssemblyFile);
            var mcFlyAssemblies =
                Directory.EnumerateFiles(executingDirectory, "McFly*.dll", SearchOption.AllDirectories);
            var assemblies = mcFlyAssemblies.Select(Assembly.LoadFile).Select(a => new AssemblyCatalog(a));
            var executingAssembly = Assembly.GetExecutingAssembly();
            var executingAssemblyCatalog = new AssemblyCatalog(executingAssembly);
            var aggregateCatalog = new AggregateCatalog(assemblies.Concat(new[] {executingAssemblyCatalog}));
            var compositionContainer = new CompositionContainer(aggregateCatalog);
            var settings = new Settings {ConnectionString = "Data Source=localhost;Integrated Security=true"};
            compositionContainer.ComposeExportedValue(settings);
            var mefDependencyResolver = new MefDependencyResolver(compositionContainer, config.DependencyResolver);
            return mefDependencyResolver;
        }
    }
}