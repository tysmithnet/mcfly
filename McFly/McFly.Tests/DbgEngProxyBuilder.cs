using System.Collections.Generic;
using System.Text.RegularExpressions;
using McFly.Core;
using Moq;

namespace McFly.Tests
{     
    public class DbgEngProxyBuilder
    {
        public Mock<IDbgEngProxy> Mock = new Mock<IDbgEngProxy>();
                                                                
        public DbgEngProxyBuilder WithExecuteResult(string result)
        {
            Mock.Setup(proxy => proxy.Execute(It.IsAny<string>())).Returns(result);
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
    }

}