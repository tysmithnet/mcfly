// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-23-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="IHttpFacade.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace McFly.WinDbg
{
    /// <summary>
    ///     Facade over interacting with HTTP
    /// </summary>
    /// <seealso cref="IInjectable" />
    public interface IHttpFacade : IInjectable
    {
        /// <summary>
        ///     Issues a POST request asynchronously
        /// </summary>
        /// <param name="resourceUri">The resource URI.</param>
        /// <param name="formContent">Content of the form.</param>
        /// <param name="requestHeaders">The request headers.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        Task<HttpResponseMessage> PostAsync(Uri resourceUri, Dictionary<string, string> formContent,
            HttpHeaders requestHeaders);

        /// <summary>
        ///     Issues a POST request asynchronously
        /// </summary>
        /// <param name="resourceUri">The resource URI.</param>
        /// <param name="content">The content.</param>
        /// <param name="requestHeaders">The request headers.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        Task<HttpResponseMessage> PostAsync(Uri resourceUri, byte[] content, HttpHeaders requestHeaders);

        /// <summary>
        ///     Issues a POST request asynchronously using the provided object's JSON representation
        /// </summary>
        /// <param name="resourceUri">The resource URI.</param>
        /// <param name="content">The content.</param>
        /// <param name="requestHeaders">The request headers.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        Task<HttpResponseMessage> PostJsonAsync(Uri resourceUri, object content, HttpHeaders requestHeaders);
    }
}