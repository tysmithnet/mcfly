using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace McFly
{
    public interface IHttpFacade
    {
        Task<HttpResponseMessage> PostAsync(Uri resourceUri, Dictionary<string, string> formContent);
        Task<HttpResponseMessage> PostAsync(Uri resourceUri, byte[] content);
        Task<HttpResponseMessage> PostJsonAsync(Uri resourceUri, object content);
    }
}