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
    public class FromHeaderBinding : HttpParameterBinding
    {
        private readonly string _name;

        public FromHeaderBinding(HttpParameterDescriptor parameter, string headerName) : base(parameter)
        {
            if (string.IsNullOrEmpty(headerName))
            {
                throw new ArgumentNullException(nameof(headerName));
            }
            _name = headerName;
        }

        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            if (actionContext.Request.Headers.TryGetValues(_name, out var values))
            {
                var converter = TypeDescriptor.GetConverter(Descriptor.ParameterType);
                try
                {
                    actionContext.ActionArguments[Descriptor.ParameterName] = converter.ConvertFromString(values.FirstOrDefault());
                }
                catch (Exception exception)
                {
                    var error = new HttpError("The request is invalid.") { MessageDetail = exception.Message };
                    throw new HttpResponseException(actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, error));
                }
            }
            else if (Descriptor.IsOptional)
            {
                actionContext.ActionArguments[Descriptor.ParameterName] = Descriptor.DefaultValue ?? Activator.CreateInstance(Descriptor.ParameterType);
            }
            else
            {
                var error = new HttpError("The request is invalid.") { MessageDetail = $"The `{_name}` header is required." };
                throw new HttpResponseException(actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, error));
            }
            return Task.FromResult<object>(null);
        }
    }
}