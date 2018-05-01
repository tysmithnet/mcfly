using System;
using FluentAssertions;
using Xunit;

namespace McFly.WinDbg.Test
{
    public class BreakpointMask_Should
    {
        [Fact]
        public void Exhibit_Value_Equality()
        {
            var b1 = new BreakpointMask("mod", "fun");
            var b2 = new BreakpointMask("mod", "fun");

            b1.Equals(null).Should().BeFalse();
            b1.Equals((object)null).Should().BeFalse();
            b1.Equals(b1).Should().BeTrue();
            b1.Equals(b2).Should().BeTrue();
            b1.Equals((object)b1).Should().BeTrue();
            b1.Equals((object)b2).Should().BeTrue();
            b1.Equals(new object()).Should().BeFalse();
            b1.Should().Be(b1);
            b1.Should().Be(b2);
            b1.GetHashCode().Should().Be(b2.GetHashCode());
        }

        [Fact]
        public void Parse_Correctly()
        {
            Action a = () => BreakpointMask.Parse(null);
            a.Should().Throw<ArgumentException>();

            a = () => BreakpointMask.Parse("gibberish");
            a.Should().Throw<FormatException>();

            var bp = BreakpointMask.Parse("kernel32!*");
            bp.ModuleMask.Should().Be("kernel32");
            bp.FunctionMask.Should().Be("*");
        }

        [Fact]
        public void Set_Breakpoint_Correctly()
        {
            
        }
    }
}