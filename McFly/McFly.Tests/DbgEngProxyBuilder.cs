using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using McFly.Core;
using Moq;

namespace McFly.Tests
{
    internal class DbgEngProxyBuilder
    {
        public Mock<IDbgEngProxy> Mock = new Mock<IDbgEngProxy>();
        private int _threadId;

        public DbgEngProxyBuilder()
        {
            Mock.SetupAllProperties();
        }

        public DbgEngProxyBuilder WithExecuteResult(string result)
        {
            Mock.Setup(proxy => proxy.Execute(It.IsAny<string>())).Returns(result);
            return this;
        }

        public DbgEngProxyBuilder With32Bit(bool result)
        {
            Mock.Setup(proxy => proxy.Is32Bit).Returns(result);
            return this;
        }

        public DbgEngProxyBuilder WithExecuteResult(string command, string result)
        {
            Mock.Setup(proxy => proxy.Execute(command)).Returns(result);
            return this;
        }

        public IDbgEngProxy Build()
        {
            return Mock.Object;
        }

        public DbgEngProxyBuilder WithThreadId(int threadId)
        {
            Mock.Setup(proxy => proxy.GetCurrentThreadId()).Returns(threadId);
            return this;
        }

        public DbgEngProxyBuilder WithRunUntilBreak()
        {
            Mock.Setup(proxy => proxy.RunUntilBreak());
            return this;
        }

        public DbgEngProxyBuilder SetRunUntilBreakCallback(Action callback)
        {
            Mock.Setup(proxy => proxy.RunUntilBreak()).Callback(callback);
            return this;
        }

        public int CurrentThreadId
        {
            get => Mock.Object.GetCurrentThreadId();
            set { Mock.Setup(proxy => proxy.GetCurrentThreadId()).Returns(value); }
        }

    }
}