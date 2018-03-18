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

        public DbgEngProxyBuilder WithFrames(IEnumerable<Frame> frames)
        {

            return this;
        }

        public DbgEngProxyBuilder WithStartingPosition(Position position)
        {
            Mock.Setup(proxy => proxy.GetStartingPosition()).Returns(position);
            return this;
        }

        public DbgEngProxyBuilder WithEndingPosition(Position position)
        {
            Mock.Setup(proxy => proxy.GetEndingPosition()).Returns(position);
            return this;
        }
    }
}