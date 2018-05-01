using System;
using FluentAssertions;
using McFly.Core;
using McFly.WinDbg.Test.Builders;
using Moq;
using Xunit;

namespace McFly.WinDbg.Test
{
    public class InitMethod_Should
    {
        [Fact]
        public void Correctly_Extract_Options_From_String_Array()
        {
            var initMethod = new InitMethod();
            Action a = () => initMethod.ExtractOptions(null);
            a.Should().Throw<ArgumentNullException>();
            a = () => initMethod.ExtractOptions(new[] {""});
            a.Should().Throw<ArgumentOutOfRangeException>();
            var one = initMethod.ExtractOptions(new[] {"--name", "test"});
            one.ProjectName.Should().Be("test");
            var two = initMethod.ExtractOptions(new[] {"-n", "test"});
            two.ProjectName.Should().Be("test");
        }

        [Fact]
        public void Pass_Correct_Values_To_Server_Client()
        {
            // arrange
            var args = new[] {"-n", "test"};
            var initMethod = new InitMethod();
            var clientBuilder = new ServerClientBuilder();
            var dbg = new DebugEngineProxyBuilder();
            var builder = new TimeTravelFacadeBuilder(dbg);
            builder.WithGetStartingPosition(new Position(0, 0)).WithGetEndingPosition(new Position(1, 0));

            initMethod.TimeTravelFacade = builder.Build();
            initMethod.ServerClient = clientBuilder.Build();
            initMethod.Settings = new Settings
            {
                ServerUrl = "http://localhost:5000"
            };

            // act
            initMethod.Process(args);

            // assert
            clientBuilder.Mock.Verify(
                client => client.InitializeProject("test", new Position(0, 0), new Position(1, 0)), Times.Once);
        }
    }
}