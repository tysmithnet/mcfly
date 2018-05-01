using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace McFly.WinDbg.Test
{
    public class HelpInfoBuilder_Should
    {
        [Fact]
        public void Overwrite_An_Existing_Subcommand_If_Same_Name_Specified()
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
    }
}
