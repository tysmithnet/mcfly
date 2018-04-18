// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tysmithnet
// Created          : 03-16-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="FromHeaderAttribute.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Web.Http;
using System.Web.Http.Controllers;

namespace McFly.Server.Headers
{
    /// <summary>
    ///     Attribute indicating that a particular parameter can be found in the header
    /// </summary>
    /// <seealso cref="System.Web.Http.ParameterBindingAttribute" />
    public abstract class FromHeaderAttribute : ParameterBindingAttribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FromHeaderAttribute" /> class.
        /// </summary>
        /// <param name="headerName">Name of the header.</param>
        protected FromHeaderAttribute(string headerName)
        {
            HeaderName = headerName;
        }

        /// <summary>
        ///     Gets the name of the header.
        /// </summary>
        /// <value>The name of the header.</value>
        public string HeaderName { get; }

        /// <summary>
        ///     Gets the parameter binding.
        /// </summary>
        /// <param name="parameter">The parameter description.</param>
        /// <returns>The parameter binding.</returns>
        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            return new FromHeaderBinding(parameter, HeaderName);
        }
    }
}