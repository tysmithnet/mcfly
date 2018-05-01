// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tysmithnet
// Created          : 03-15-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 05-01-2018
// ***********************************************************************
// <copyright file="SwaggerConfig.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Web.Http;
using WebActivatorEx;
using McFly.Server;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace McFly.Server
{
    /// <summary>
    ///     Represents the Swagger configuration
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        ///     Registers this swagger configuration with the <see cref="GlobalConfiguration" />
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c => c.SingleApiVersion("v1", "McFly.Server"))
                .EnableSwaggerUi();
        }
    }
}
