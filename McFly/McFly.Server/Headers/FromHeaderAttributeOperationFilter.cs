// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tysmithnet
// Created          : 03-16-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="FromHeaderAttributeOperationFilter.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Linq;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace McFly.Server.Headers
{
    /// <summary>
    ///     Operation filter for the from header attribute
    /// </summary>
    /// <seealso cref="Swashbuckle.Swagger.IOperationFilter" />
    public class FromHeaderAttributeOperationFilter : IOperationFilter
    {
        /// <summary>
        ///     Applies the specified operation.
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <param name="schemaRegistry">The schema registry.</param>
        /// <param name="apiDescription">The API description.</param>
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            foreach (var httpParameterDescriptor in apiDescription.ActionDescriptor.GetParameters()
                .Where(e => e.GetCustomAttributes<FromHeaderAttribute>().Any()))
            {
                var parameter = operation.parameters.Single(p => p.name == httpParameterDescriptor.ParameterName);
                parameter.name = httpParameterDescriptor.GetCustomAttributes<FromHeaderAttribute>().Single().HeaderName;
                parameter.@in = "header";
            }
        }
    }
}