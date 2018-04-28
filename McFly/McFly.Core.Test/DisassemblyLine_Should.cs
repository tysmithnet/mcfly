using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace McFly.Core.Test
{
    public class DisassemblyLine_Should
    {
        [Fact]
        public void Exhibit_Value_Equality()
        {
            var line0 = new DisassemblyLine(0, new byte[0], "mov", "");
            var line1 = new DisassemblyLine(0, new byte[0], "mov", "");
            var line2 = new DisassemblyLine(0, new byte[0], "pop", "");
            var line3 = new DisassemblyLine(0, new byte[0], "push", "");

            line0.Equals(null).Should().BeFalse();
            line0.Equals(new object()).Should().BeFalse();
            line0.Equals(line0).Should().BeTrue();
            line0.Equals(line1).Should().BeTrue();
            line1.Equals(line2).Should().BeFalse();
            line2.Equals(line3).Should().BeFalse();
        }
    }
}
