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

            b1.Equals(b1).Should().BeTrue();
            b1.Equals(b2).Should().BeTrue();
            b1.Should().Be(b1);
            b1.Should().Be(b2);
            (b1 == b2).Should().BeTrue();
            (b1 != b2).Should().BeFalse();
            b1.GetHashCode().Should().Be(b2.GetHashCode());
        }
    }
}