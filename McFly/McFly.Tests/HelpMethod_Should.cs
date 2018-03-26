using FluentAssertions;
using Xunit;

namespace McFly.Tests
{
    public class HelpMethod_Should
    {
        [Fact]
        public void Print_Command_Listing_When_No_Args()
        {
            var helpMethod = new HelpMethod();
            var dbg = new DebugEngineProxyBuilder();
            string output = null;
            dbg.WithWriteLine(s => output = s);
            helpMethod.DebugEngineProxy = dbg.Build();
            helpMethod.Methods = new IMcFlyMethod[]
            {
                new IndexMethod(), 
                new InitMethod(), 
                new HelpMethod(), 
                new SettingsMethod(), 
            };
            string expected = @"4 Available commands:
index                    Record the state of registers, memory, etc for further analysis
init                     Create a new project using the loaded trace file
help                     Get help and find commands
settings                 Manage application settings

Get extended help:
!mf help command
";

            helpMethod.Process("".Split(' '));

            output.Should().Be(expected);
        }
    }
}