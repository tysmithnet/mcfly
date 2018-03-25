// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-23-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-23-2018
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

namespace McFly
{
    /// <summary>
    ///     Interface IHttpFacade
    /// </summary>
    public interface IHttpFacade
    {
        /// <summary>
        ///     Posts the asynchronous.
        /// </summary>
        /// <param name="resourceUri">The resource URI.</param>
        /// <param name="formContent">Content of the form.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        Task<HttpResponseMessage> PostAsync(Uri resourceUri, Dictionary<string, string> formContent);

        /// <summary>
        ///     Posts the asynchronous.
        /// </summary>
        /// <param name="resourceUri">The resource URI.</param>
        /// <param name="content">The content.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        Task<HttpResponseMessage> PostAsync(Uri resourceUri, byte[] content);

        /// <summary>
        ///     Posts the json asynchronous.
        /// </summary>
        /// <param name="resourceUri">The resource URI.</param>
        /// <param name="content">The content.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        Task<HttpResponseMessage> PostJsonAsync(Uri resourceUri, object content);
    }
}