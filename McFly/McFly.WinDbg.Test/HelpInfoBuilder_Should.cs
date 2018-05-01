using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace McFly.WinDbg.Test
{
    public class HelpInfoBuilder_Should
    {
        [Fact]
        public void Require_Name_And_Description_Be_Set()
        {
            var builder = new HelpInfoBuilder();
            Action a = () => builder.Build();
            a.Should().Throw<NullReferenceException>();
            builder.SetName("name");
            a.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void Upsert_Examples()
        {
            var builder = new HelpInfoBuilder();
            builder.SetName("").SetDescription("");
            builder.AddExample("foo", "bar");
            builder.AddExample("foo", "baz");
            builder.Build().Examples.Single().Value.Should().Be("baz");
        }

        [Fact]
        public void Upsert_Subcommands()
        {
            var builder = new HelpInfoBuilder();
            builder.SetName("root").SetDescription("root");
            var sub1 = new HelpInfoBuilder().SetName("sub1").SetDescription("").Build();
            var clone = new HelpInfoBuilder().SetName("sub1").SetDescription("").AddSwitch("-x", "something").Build();
            builder.AddSubcommand(sub1);
            builder.AddSubcommand(clone);
            builder.Build().Subcommands.Should().HaveCount(1);
            builder.Build().Subcommands.Single().Switches.Should().HaveCount(1);
        }

        [Fact]
        public void Upsert_Switches()
        {
            var builder = new HelpInfoBuilder();
            builder.SetName("").SetDescription("");
            builder.AddSwitch("x", "x");
            builder.AddSwitch("x", "new");
            builder.Build().Switches.Single().Value.Should().Be("new");
        }
    }
}