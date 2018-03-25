// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tysmithnet
// Created          : 03-14-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-16-2018
// ***********************************************************************
// <copyright file="MefDependencyResolver.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web.Http.Dependencies;

namespace McFly.Server
{
    /// <summary>
    ///     Dependency resolver that uses MEF as its container functionality
    /// </summary>
    /// <seealso cref="System.Web.Http.Dependencies.IDependencyResolver" />
    public class MefDependencyResolver : IDependencyResolver
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MefDependencyResolver" /> class.
        /// </summary>
        /// <param name="compositionContainer">The composition container.</param>
        /// <param name="dependencyResolver">The dependency resolver.</param>
        public MefDependencyResolver(CompositionContainer compositionContainer, IDependencyResolver dependencyResolver)
        {
            CompositionContainer = compositionContainer;
            Parent = dependencyResolver;
        }

        /// <summary>
        ///     Gets the composition container.
        /// </summary>
        /// <value>The composition container.</value>
        private CompositionContainer CompositionContainer { get; }

        /// <summary>
        ///     Gets the parent.
        /// </summary>
        /// <value>The parent.</value>
        private IDependencyResolver Parent { get; }

        /// <summary>
        ///     Disposes this instance.
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        ///     Retrieves a service from the scope.
        /// </summary>
        /// <param name="serviceType">The service to be retrieved.</param>
        /// <returns>The retrieved service.</returns>
        /// <exception cref="NullReferenceException">serviceType</exception>
        public object GetService(Type serviceType)
        {
            if (serviceType == null)
                throw new NullReferenceException(nameof(serviceType));

            var export = CompositionContainer.GetExports(serviceType, null, null).FirstOrDefault()?.Value;
            if (export == null)
                export = Parent?.GetService(serviceType);

            return export;
        }

        /// <summary>
        ///     Retrieves a collection of services from the scope.
        /// </summary>
        /// <param name="serviceType">The collection of services to be retrieved.</param>
        /// <returns>The retrieved collection of services.</returns>
        /// <exception cref="NullReferenceException">serviceType</exception>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (serviceType == null)
                throw new NullReferenceException(nameof(serviceType));

            var values = CompositionContainer.GetExports(serviceType, null, null).Select(x => x.Value).ToList();
            if (!values.Any())
                values = Parent?.GetServices(serviceType).ToList();
            return values;
        }

        /// <summary>
        ///     Starts a resolution scope.
        /// </summary>
        /// <returns>The dependency scope.</returns>
        public IDependencyScope BeginScope()
        {
            return this;
        }
    }
}