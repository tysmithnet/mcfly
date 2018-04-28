// ***********************************************************************
// Assembly         : McFly.Tests
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-18-2018
// ***********************************************************************
// <copyright file="HttpFacadeBuilder.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using McFly.WinDbg;
using Moq;

namespace McFly.Test.Builders
{
    /// <summary>
    ///     Class HttpFacadeBuilder.
    /// </summary>
    internal class HttpFacadeBuilder
    {
        /// <summary>
        ///     The mock
        /// </summary>
        public Mock<IHttpFacade> Mock = new Mock<IHttpFacade>();

        /// <summary>
        ///     Builds this instance.
        /// </summary>
        /// <returns>IHttpFacade.</returns>
        public IHttpFacade Build()
        {
            return Mock.Object;
        }

        /// <summary>
        ///     Withes the post asynchronous.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>HttpFacadeBuilder.</returns>
        public HttpFacadeBuilder WithPostAsync(HttpResponseMessage result)
        {
            Mock.Setup(facade => facade.PostAsync(It.IsAny<Uri>(), It.IsAny<byte[]>(), null))
                .Returns(Task.FromResult(result));
            Mock.Setup(facade => facade.PostAsync(It.IsAny<Uri>(), It.IsAny<Dictionary<string, string>>(), null))
                .Returns(Task.FromResult(result));
            return this;
        }

        /// <summary>
        ///     Withes the post json asynchronous.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>HttpFacadeBuilder.</returns>
        public HttpFacadeBuilder WithPostJsonAsync(HttpResponseMessage result)
        {
            Mock.Setup(facade => facade.PostJsonAsync(It.IsAny<Uri>(), It.IsAny<object>(), It.IsAny<HttpHeaders>()))
                .Returns(Task.FromResult(result));
            return this;
        }
    }
}