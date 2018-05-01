using System;
using FluentAssertions;
using Xunit;

namespace McFly.WinDbg.Test
{
    public class AccessBreakpoint_Should
    {
        [Fact]
        public void Exhibit_Value_Equality()
        {
            var a1 = new AccessBreakpoint(0, 4, true, false);
            var a2 = new AccessBreakpoint(0, 4, true, false);

            a1.Equals(null).Should().BeFalse();
            a1.Equals((object) null).Should().BeFalse();
            a1.Equals(a1).Should().BeTrue();
            a1.Equals((object) a1).Should().BeTrue();
            a1.Equals(new object()).Should().BeFalse();
            a1.Equals(a2).Should().BeTrue();
            a1.GetHashCode().Should().Be(a2.GetHashCode());
        }

        [Fact]
        public void Only_Allow_Lengths_Of_1_2_4_8()
        {
            Action a = () => new AccessBreakpoint(1, 0);
            a.Should().Throw<ArgumentOutOfRangeException>();
            a = () => new AccessBreakpoint(0, 3);
            a.Should().Throw<ArgumentOutOfRangeException>();
            a = () => new AccessBreakpoint(0, 1, false, false);
            a.Should().Throw<ArgumentException>();
        }
    }
}