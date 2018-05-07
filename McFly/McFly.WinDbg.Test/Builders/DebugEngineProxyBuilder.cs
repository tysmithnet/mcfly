// ***********************************************************************
// Assembly         : McFly.Tests
// Author           : @tysmithnet
// Created          : 03-08-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-18-2018
// ***********************************************************************
// <copyright file="DbgEngProxyBuilder.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using McFly.Core;
using McFly.Core.Registers;
using Moq;

namespace McFly.WinDbg.Test.Builders
{
    /// <summary>
    ///     Class DbgEngProxyBuilder.
    /// </summary>
    internal class DebugEngineProxyBuilder
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DebugEngineProxyBuilder" /> class.
        /// </summary>
        public DebugEngineProxyBuilder()
        {
            Mock.SetupAllProperties();
        }

        /// <summary>
        ///     The mock
        /// </summary>
        public Mock<IDebugEngineProxy> Mock = new Mock<IDebugEngineProxy>();

        /// <summary>
        ///     The thread identifier
        /// </summary>
        private int _threadId;

        /// <summary>
        ///     Builds this instance.
        /// </summary>
        /// <returns>IDbgEngProxy.</returns>
        public IDebugEngineProxy Build()
        {
            return Mock.Object;
        }

        /// <summary>
        ///     Sets the run until break callback.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <returns>DbgEngProxyBuilder.</returns>
        public DebugEngineProxyBuilder SetRunUntilBreakCallback(Action callback)
        {
            Mock.Setup(proxy => proxy.RunUntilBreak()).Callback(callback);
            return this;
        }

        /// <summary>
        ///     With32s the bit.
        /// </summary>
        /// <param name="result">if set to <c>true</c> [result].</param>
        /// <returns>DbgEngProxyBuilder.</returns>
        public DebugEngineProxyBuilder With32Bit(bool result)
        {
            Mock.Setup(proxy => proxy.Is32Bit).Returns(result);
            return this;
        }

        /// <summary>
        ///     Withes the execute result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>DbgEngProxyBuilder.</returns>
        public DebugEngineProxyBuilder WithExecuteResult(string result)
        {
            Mock.Setup(proxy => proxy.Execute(It.IsAny<string>())).Returns(result);
            Mock.Setup(proxy => proxy.Execute(It.IsAny<int>(), It.IsAny<string>())).Returns(result);
            return this;
        }

        /// <summary>
        ///     Withes the execute result.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="result">The result.</param>
        /// <returns>DbgEngProxyBuilder.</returns>
        public DebugEngineProxyBuilder WithExecuteResult(string command, string result)
        {
            Mock.Setup(proxy => proxy.Execute(command)).Returns(result);
            Mock.Setup(proxy => proxy.Execute(It.IsAny<int>(), command)).Returns(result);
            return this;
        }

        /// <summary>
        ///     Withes the get register value.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>DebugEngineProxyBuilder.</returns>
        public DebugEngineProxyBuilder WithGetRegisterValue(byte[] bytes)
        {
            Mock.Setup(proxy => proxy.GetRegisterValue(It.IsAny<int>(), It.IsAny<Register>())).Returns(bytes);
            return this;
        }

        /// <summary>
        ///     Withes the run until break.
        /// </summary>
        /// <returns>DbgEngProxyBuilder.</returns>
        public DebugEngineProxyBuilder WithRunUntilBreak()
        {
            Mock.Setup(proxy => proxy.RunUntilBreak());
            return this;
        }

        /// <summary>
        ///     Withes the thread identifier.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <returns>DbgEngProxyBuilder.</returns>
        public DebugEngineProxyBuilder WithThreadId(int threadId)
        {
            Mock.Setup(proxy => proxy.GetCurrentThreadId()).Returns(threadId);
            return this;
        }

        /// <summary>
        ///     Withes the write line.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>DebugEngineProxyBuilder.</returns>
        public DebugEngineProxyBuilder WithWriteLine(Action<string> action)
        {
            Mock.Setup(proxy => proxy.WriteLine(It.IsAny<string>())).Callback(action);
            return this;
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

        public DebugEngineProxyBuilder WithReadVirtualMemory(byte[] bytes)
        {
            Mock.Setup(proxy => proxy.ReadVirtualMemory(It.IsAny<MemoryRange>())).Returns(bytes);
            return this;
        }
    }
}