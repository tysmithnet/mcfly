using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;

namespace McFly.Tests
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
            Mock.Setup(facade => facade.PostJsonAsync(It.IsAny<Uri>(), It.IsAny<object>(), null))
                .Returns(Task.FromResult(result));
            return this;
        }

        /// <summary>
        ///     Builds this instance.
        /// </summary>
        /// <returns>IHttpFacade.</returns>
        public IHttpFacade Build()
        {
            return Mock.Object;
        }
    }
}