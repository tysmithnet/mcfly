using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using McFly.Core;
using Newtonsoft.Json;

namespace McFly
{
    public class ServerClient : IDisposable
    {
        private HttpClient _httpClient;
        private Uri _serverAddress;

        public ServerClient(Uri serverAddress)
        {
            _serverAddress = serverAddress ?? throw new ArgumentNullException(nameof(serverAddress));
            _httpClient = new HttpClient();
        }
            
        public async Task UpsertFrames(string projectName, IEnumerable<Frame> frames)
        {
            var ub = new UriBuilder(_serverAddress);
            ub.Path = $"api/frame/{projectName}";
            var json = JsonConvert.SerializeObject(frames);
            var bytes = Encoding.UTF8.GetBytes(json);
            var content = new ByteArrayContent(bytes);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            await _httpClient.PostAsync(ub.Uri, content);
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
