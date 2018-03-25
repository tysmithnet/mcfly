using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace McFly
{
    [Export(typeof(IHttpFacade))]
    public class HttpFacade : IHttpFacade, IDisposable
    {
        private HttpClient _client = new HttpClient();

        public Task<HttpResponseMessage> PostAsync(Uri resourceUri, Dictionary<string, string> formContent)
        {
            return _client.PostAsync(resourceUri, new FormUrlEncodedContent(formContent));
        }

        public Task<HttpResponseMessage> PostAsync(Uri resourceUri, byte[] content)
        {
            return _client.PostAsync(resourceUri, new ByteArrayContent(content));
        }

        public Task<HttpResponseMessage> PostJsonAsync(Uri resourceUri, object content)
        {
            var json = JsonConvert.SerializeObject(content);
            var bytes = Encoding.UTF8.GetBytes(json);
            var c = new ByteArrayContent(bytes);
            c.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return _client.PostAsync(resourceUri, c);
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}