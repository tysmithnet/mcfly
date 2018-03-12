// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 03-02-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-08-2018
// ***********************************************************************
// <copyright file="ServerClient.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using McFly.Core;
using Newtonsoft.Json;

namespace McFly
{
    /// <summary>
    ///     Class ServerClient.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class ServerClient : IDisposable
    {
        /// <summary>
        ///     The HTTP client
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        ///     The server address
        /// </summary>
        private readonly Uri _serverAddress;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ServerClient" /> class.
        /// </summary>
        /// <param name="serverAddress">The server address.</param>
        /// <exception cref="System.ArgumentNullException">serverAddress</exception>
        /// <exception cref="ArgumentNullException">serverAddress</exception>
        public ServerClient(Uri serverAddress)
        {
            _serverAddress = serverAddress ?? throw new ArgumentNullException(nameof(serverAddress));
            _httpClient = new HttpClient();
        }

        /// <summary>
        ///     Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        /// <summary>
        ///     Upserts the frames.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="frames">The frames.</param>
        /// <returns>Task.</returns>
        public void UpsertFrames(string projectName, IEnumerable<Frame> frames)
        {
            var ub = new UriBuilder(_serverAddress) {Path = $"api/frame/{projectName}"};
            var json = JsonConvert.SerializeObject(frames);
            var bytes = Encoding.UTF8.GetBytes(json);
            var content = new ByteArrayContent(bytes);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            _httpClient.PostAsync(ub.Uri, content).GetAwaiter().GetResult();
        }

        public void AddNote(string projectName, Position position, int threadId, string text)
        {
            var ub = new UriBuilder(_serverAddress) { Path = $"api/frame/{projectName}" };
            var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("projectName", projectName),
                new KeyValuePair<string, string>("position", position.ToString()),
                new KeyValuePair<string, string>("threadId", threadId.ToString()),
                new KeyValuePair<string, string>("text", text),
            });

            _httpClient.PostAsync(ub.Uri, content).GetAwaiter().GetResult();
        }

        public void InitializeProject(string projectName, Position start, Position end)
        {
            var ub = new UriBuilder(_serverAddress) { Path = $"api/project" };
            var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("projectName", projectName),
            });

            _httpClient.PostAsync(ub.Uri, content).GetAwaiter().GetResult();
        }
    }
}