// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-23-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-27-2018
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
    public class HttpFacade : IHttpFacade
    {
        /// <summary>
        ///     The client
        /// </summary>
        private readonly HttpClient client = new HttpClient();

        /// <summary>
        ///     Posts the asynchronous.
        /// </summary>
        /// <param name="resourceUri">The resource URI.</param>
        /// <param name="formContent">Content of the form.</param>
        /// <param name="requestHeaders">The request headers.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        public Task<HttpResponseMessage> PostAsync(Uri resourceUri, Dictionary<string, string> formContent,
            HttpHeaders requestHeaders)
        {
            lock (client)
            {
                SetHeaders(requestHeaders, client);
                return client.PostAsync(resourceUri, new FormUrlEncodedContent(formContent));
            }
        }

        /// <summary>
        ///     Posts the asynchronous.
        /// </summary>
        /// <param name="resourceUri">The resource URI.</param>
        /// <param name="content">The content.</param>
        /// <param name="requestHeaders">The request headers.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        public Task<HttpResponseMessage> PostAsync(Uri resourceUri, byte[] content, HttpHeaders requestHeaders)
        {
            lock (client)
            {
                SetHeaders(requestHeaders, client);
                return client.PostAsync(resourceUri, new ByteArrayContent(content));
            }
        }

        /// <summary>
        ///     Sends a post request to a URI with the provided conent a json
        /// </summary>
        /// <param name="resourceUri">The resource URI.</param>
        /// <param name="content">The content.</param>
        /// <param name="requestHeaders">The request headers.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        public Task<HttpResponseMessage> PostJsonAsync(Uri resourceUri, object content,
            HttpHeaders requestHeaders)
        {
            var json = JsonConvert.SerializeObject(content);
            var bytes = Encoding.UTF8.GetBytes(json);
            var c = new ByteArrayContent(bytes);
            c.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            lock (client)
            {
                SetHeaders(requestHeaders, client);
                return client.PostAsync(resourceUri, c); // todo: timeout 
            }
        }

        /// <summary>
        ///     Sets the headers.
        /// </summary>
        /// <param name="requestHeaders">The request headers.</param>
        /// <param name="client">The client.</param>
        /// <exception cref="ArgumentNullException">client</exception>
        private static void SetHeaders(HttpHeaders requestHeaders, HttpClient client)
        {
            if (requestHeaders == null)
                return;
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            client.DefaultRequestHeaders.Clear();
            foreach (var httpRequestHeader in requestHeaders)
                client.DefaultRequestHeaders.Add(httpRequestHeader.Key, httpRequestHeader.Value);
        }
    }
}