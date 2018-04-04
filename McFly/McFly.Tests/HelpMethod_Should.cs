using System.Collections.Generic;
using FluentAssertions;
using McFly.Tests.Builders;
using Xunit;

namespace McFly.Tests
{
    public class HelpMethod_Should
    {
        [Fact]
        public void Print_Command_Help_If_A_Single_Command_Is_Specified()
        {
            var helpMethod = new HelpMethod();
            var dbg = new DebugEngineProxyBuilder();
            string output = null;
            dbg.WithWriteLine(s => output = s);
            helpMethod.DebugEngineProxy = dbg.Build();
            helpMethod.Methods = new IMcFlyMethod[]
            {
                new TestMethod()
            };
            var expected = @"test
Testing method

Switches:
	-weird                           Weird switch
	--double                         Double switch

Subcommands:
	test sub1                        First subcommand
	test sub2                        Second subcommand

Examples:
	Example 1
	test -weird something --double 2
	Test weird something with 2
	Example 2
	test
	Run default test
";

            helpMethod.Process("test".Split(' '));

            output.Should().Be(expected);
        }

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
                new StartMethod()
            };
            var expected = @"5 Available commands:
index                    Record the state of registers, memory, etc for further analysis
init                     Create a new project using the loaded trace file
help                     Get help and find commands
settings                 Manage application settings
start                    Start the local server

Get extended help:
!mf help command
";

            helpMethod.Process("".Split(' '));

            output.Should().Be(expected);
        }
    }

    internal class TestMethod : IMcFlyMethod
    {
        public HelpInfo HelpInfo { get; } = new HelpInfo
        (
            "test",
            "Testing method",
            new Dictionary<string, string>
            {
                ["-weird"] = "Weird switch",
                ["--double"] = "Double switch"
            },
            new Dictionary<string, string>
            {
                ["test -weird something --double 2"] = "Test weird something with 2",
                ["test"] = "Run default test"
            }, new[]
            {
                new HelpInfo
                (
                    "sub1",
                    "First subcommand",
                    new Dictionary<string, string>
                    {
                        ["a"] = "First switch",
                        ["b"] = "Second switch"
                    }, null, null
                ),
                new HelpInfo
                (
                    "sub2",
                    "Second subcommand",
                    new Dictionary<string, string>
                    {
                        ["-all"] = "All switch"
                    }, null, null
                )
            }
        );

        public void Process(string[] args)
        {
        }
    }
}