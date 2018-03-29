// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tysmithnet
// Created          : 03-16-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-16-2018
// ***********************************************************************
// <copyright file="FromHeaderBinding.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;

namespace McFly.Server.Headers
{
    /// <summary>
    ///     Binding for the from header attribute
    /// </summary>
    /// <seealso cref="System.Web.Http.Controllers.HttpParameterBinding" />
    public class FromHeaderBinding : HttpParameterBinding
    {
        /// <summary>
        ///     The name
        /// </summary>
        private readonly string _name;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FromHeaderBinding" /> class.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <param name="headerName">Name of the header.</param>
        /// <exception cref="ArgumentNullException">headerName</exception>
        public FromHeaderBinding(HttpParameterDescriptor parameter, string headerName) : base(parameter)
        {
            if (string.IsNullOrEmpty(headerName))
                throw new ArgumentNullException(nameof(headerName));
            _name = headerName;
        }

        /// <summary>
        ///     Asynchronously executes the binding for the given request.
        /// </summary>
        /// <param name="metadataProvider">Metadata provider to use for validation.</param>
        /// <param name="actionContext">
        ///     The action context for the binding. The action context contains the parameter dictionary
        ///     that will get populated with the parameter.
        /// </param>
        /// <param name="cancellationToken">Cancellation token for cancelling the binding operation.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        /// <exception cref="HttpResponseException">
        /// </exception>
        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider,
            HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            if (actionContext.Request.Headers.TryGetValues(_name, out var values))
            {
                var converter = TypeDescriptor.GetConverter(Descriptor.ParameterType);
                try
                {
                    actionContext.ActionArguments[Descriptor.ParameterName] =
                        converter.ConvertFromString(values.FirstOrDefault());
                }
                catch (Exception exception)
                {
                    var error = new HttpError("The request is invalid.") {MessageDetail = exception.Message};
                    throw new HttpResponseException(
                        actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, error));
                }
            }
            else if (Descriptor.IsOptional)
            {
                actionContext.ActionArguments[Descriptor.ParameterName] =
                    Descriptor.DefaultValue ?? Activator.CreateInstance(Descriptor.ParameterType);
            }
            else
            {
                var error = new HttpError("The request is invalid.")
                {
                    MessageDetail = $"The `{_name}` header is required."
                };
                throw new HttpResponseException(
                    actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, error));
            }
            return Task.FromResult<object>(null);
        }
    }
}