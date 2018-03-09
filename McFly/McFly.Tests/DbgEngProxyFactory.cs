using System.Text.RegularExpressions;
using Moq;

namespace McFly.Tests
{     
    public class DbgEngProxyBuilder
    {
        private Mock<IDbgEngProxy> _mock;

        public DbgEngProxyBuilder()
        {
            _mock = new Mock<IDbgEngProxy>();
        }

        public DbgEngProxyBuilder WithExecuteResult(string command, string result)
        {
            _mock.Setup(proxy => proxy.Execute(command)).Returns(result);
            return this;
        }

        public IDbgEngProxy Build()
        {
            return _mock.Object;
        }
    }
}