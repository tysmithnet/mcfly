using System.Collections.Generic;
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
            string expected = @"test
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
    }

    internal class TestMethod : IMcFlyMethod
    {
        public HelpInfo HelpInfo { get; } = new HelpInfo()
        {
            Name = "test",
            Description = "Testing method",
            Subcommands = new []
            {
                new HelpInfo
                {
                    Name = "sub1",
                    Description = "First subcommand",
                    Switches = new Dictionary<string, string>()
                    {
                        ["a"] = "First switch",
                        ["b"] = "Second switch"
                    }
                },
                new HelpInfo
                {
                    Name = "sub2",
                    Description = "Second subcommand",
                    Switches = new Dictionary<string, string>()
                    {
                        ["-all"] = "All switch"
                    }
                }
            },
            Switches = new Dictionary<string, string>()
            {
                ["-weird"] = "Weird switch",
                ["--double"] = "Double switch"
            }                                ,
            Examples = new Dictionary<string, string>()
            {
                ["test -weird something --double 2"] = "Test weird something with 2",
                ["test"] = "Run default test"
            }
        };
        public void Process(string[] args)
        {
            
        }
    }
}