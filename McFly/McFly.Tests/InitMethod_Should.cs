using McFly.Core;
using Moq;
using Xunit;

namespace McFly.Tests
{
    public class InitMethod_Should
    {
        [Fact]
        public void Pass_Correct_Values_To_Server_Client()
        {
            // arrange
            var args = new[] {"-n", "test"};
            var initMethod = new InitMethod();
            var clientBuilder = new ServerClientBuilder();
            var dbgEngProxyBuilder = new DbgEngProxyBuilder();
            dbgEngProxyBuilder
                .WithStartingPosition(new Position(0, 0))
                .WithEndingPosition(new Position(1, 0));

            initMethod.DbgEngProxy = dbgEngProxyBuilder.Build();
            initMethod.ServerClient = clientBuilder.Build();
            initMethod.Settings = new Settings
            {
                ServerUrl = "http://localhost:5000",
            };
            // act
            initMethod.Process(args);

            // assert
            clientBuilder.Mock.Verify(
                client => client.InitializeProject("test", new Position(0, 0), new Position(1, 0)), Times.Once);
        }
    }
}