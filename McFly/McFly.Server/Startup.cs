using System.ComponentModel.Composition.Hosting;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Owin;
using Swashbuckle.Application;

namespace McFly.Server
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
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
            config.EnableSwagger(c => { c.SingleApiVersion("v1", "McFly API"); }).EnableSwaggerUi();

            appBuilder.UseWebApi(config);
        }
    }
}