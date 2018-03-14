using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web.Http.Dependencies;

namespace McFly.Server
{
    public class MefDependencyResolver : IDependencyResolver
    {
        public MefDependencyResolver(CompositionContainer compositionContainer, IDependencyResolver dependencyResolver)
        {
            CompositionContainer = compositionContainer;
            Parent = dependencyResolver;
        }

        private CompositionContainer CompositionContainer { get; }
        private IDependencyResolver Parent { get; }

        public void Dispose()
        {
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == null)
                throw new NullReferenceException(nameof(serviceType));

            var export = CompositionContainer.GetExports(serviceType, null, null).FirstOrDefault()?.Value;
            if (export == null)
                export = Parent?.GetService(serviceType);

            return export;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (serviceType == null)
                throw new NullReferenceException(nameof(serviceType));

            var values = CompositionContainer.GetExports(serviceType, null, null).Select(x => x.Value).ToList();
            if (!values.Any())
                values = Parent?.GetServices(serviceType).ToList();
            return values;
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }
    }
}