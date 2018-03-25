// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-23-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-24-2018
// ***********************************************************************
// <copyright file="HttpFacade.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

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
    /// <summary>
    ///     Class HttpFacade.
    /// </summary>
    /// <seealso cref="McFly.IHttpFacade" />
    /// <seealso cref="System.IDisposable" />
    [Export(typeof(IHttpFacade))]
    public class HttpFacade : IHttpFacade, IDisposable
    {
        /// <summary>
        ///     The client
        /// </summary>
        private readonly HttpClient _client = new HttpClient();

        /// <summary>
        ///     Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            _client?.Dispose();
        }

        /// <summary>
        ///     Posts the asynchronous.
        /// </summary>
        /// <param name="resourceUri">The resource URI.</param>
        /// <param name="formContent">Content of the form.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        public Task<HttpResponseMessage> PostAsync(Uri resourceUri, Dictionary<string, string> formContent)
        {
            return _client.PostAsync(resourceUri, new FormUrlEncodedContent(formContent));
        }

        /// <summary>
        ///     Posts the asynchronous.
        /// </summary>
        /// <param name="resourceUri">The resource URI.</param>
        /// <param name="content">The content.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        public Task<HttpResponseMessage> PostAsync(Uri resourceUri, byte[] content)
        {
            return _client.PostAsync(resourceUri, new ByteArrayContent(content));
        }

        /// <summary>
        ///     Posts the json asynchronous.
        /// </summary>
        /// <param name="resourceUri">The resource URI.</param>
        /// <param name="content">The content.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        public Task<HttpResponseMessage> PostJsonAsync(Uri resourceUri, object content)
        {
            var json = JsonConvert.SerializeObject(content);
            var bytes = Encoding.UTF8.GetBytes(json);
            var c = new ByteArrayContent(bytes);
            c.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return _client.PostAsync(resourceUri, c);
        }
    }
}