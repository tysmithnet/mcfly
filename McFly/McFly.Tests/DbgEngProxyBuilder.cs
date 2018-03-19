using System.Collections.Generic;
using System.Text.RegularExpressions;
using Moq;

namespace McFly.Tests
{
    internal class DbgEngProxyBuilder
    {
        public Mock<IDbgEngProxy> Mock = new Mock<IDbgEngProxy>();
                                                                
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
    }
}