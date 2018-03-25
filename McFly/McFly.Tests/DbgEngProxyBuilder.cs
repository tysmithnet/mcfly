// ***********************************************************************
// Assembly         : McFly.Tests
// Author           : @tysmithnet
// Created          : 03-08-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-24-2018
// ***********************************************************************
// <copyright file="DbgEngProxyBuilder.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Moq;

namespace McFly.Tests
{
    /// <summary>
    ///     Class DbgEngProxyBuilder.
    /// </summary>
    internal class DbgEngProxyBuilder
    {
        /// <summary>
        ///     The thread identifier
        /// </summary>
        private int _threadId;

        /// <summary>
        ///     The mock
        /// </summary>
        public Mock<IDbgEngProxy> Mock = new Mock<IDbgEngProxy>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="DbgEngProxyBuilder" /> class.
        /// </summary>
        public DbgEngProxyBuilder()
        {
            Mock.SetupAllProperties();
        }

        /// <summary>
        ///     Gets or sets the current thread identifier.
        /// </summary>
        /// <value>The current thread identifier.</value>
        public int CurrentThreadId
        {
            get => Mock.Object.GetCurrentThreadId();
            set { Mock.Setup(proxy => proxy.GetCurrentThreadId()).Returns(value); }
        }

        /// <summary>
        ///     Withes the execute result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>DbgEngProxyBuilder.</returns>
        public DbgEngProxyBuilder WithExecuteResult(string result)
        {
            Mock.Setup(proxy => proxy.Execute(It.IsAny<string>())).Returns(result);
            return this;
        }

        /// <summary>
        ///     With32s the bit.
        /// </summary>
        /// <param name="result">if set to <c>true</c> [result].</param>
        /// <returns>DbgEngProxyBuilder.</returns>
        public DbgEngProxyBuilder With32Bit(bool result)
        {
            Mock.Setup(proxy => proxy.Is32Bit).Returns(result);
            return this;
        }

        /// <summary>
        ///     Withes the execute result.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="result">The result.</param>
        /// <returns>DbgEngProxyBuilder.</returns>
        public DbgEngProxyBuilder WithExecuteResult(string command, string result)
        {
            Mock.Setup(proxy => proxy.Execute(command)).Returns(result);
            return this;
        }

        /// <summary>
        ///     Builds this instance.
        /// </summary>
        /// <returns>IDbgEngProxy.</returns>
        public IDbgEngProxy Build()
        {
            return Mock.Object;
        }

        /// <summary>
        ///     Withes the thread identifier.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <returns>DbgEngProxyBuilder.</returns>
        public DbgEngProxyBuilder WithThreadId(int threadId)
        {
            Mock.Setup(proxy => proxy.GetCurrentThreadId()).Returns(threadId);
            return this;
        }

        /// <summary>
        ///     Withes the run until break.
        /// </summary>
        /// <returns>DbgEngProxyBuilder.</returns>
        public DbgEngProxyBuilder WithRunUntilBreak()
        {
            Mock.Setup(proxy => proxy.RunUntilBreak());
            return this;
        }

        /// <summary>
        ///     Sets the run until break callback.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <returns>DbgEngProxyBuilder.</returns>
        public DbgEngProxyBuilder SetRunUntilBreakCallback(Action callback)
        {
            Mock.Setup(proxy => proxy.RunUntilBreak()).Callback(callback);
            return this;
        }
    }
}