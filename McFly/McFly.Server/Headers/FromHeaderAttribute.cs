using System.Web.Http;
using System.Web.Http.Controllers;

namespace McFly.Server.Headers
{
    public abstract class FromHeaderAttribute : ParameterBindingAttribute
    {
        public string HeaderName { get; }

        protected FromHeaderAttribute(string headerName)
        {
            HeaderName = headerName;
        }

        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            return new FromHeaderBinding(parameter, HeaderName);
        }
    }
}