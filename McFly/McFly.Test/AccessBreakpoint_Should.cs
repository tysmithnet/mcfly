using FluentAssertions;
using McFly.WinDbg;
using Xunit;

namespace McFly.Test
{
    public class AccessBreakpoint_Should
    {
        [Fact]
        public void Exhibit_Value_Equality()
        {
            var a1 = new AccessBreakpoint(0, 4, true, false);
            var a2 = new AccessBreakpoint(0, 4, true, false);

            a1.Equals(a1).Should().BeTrue();
            a1.Equals((object) a1).Should().BeTrue();
            a1.Equals(a2).Should().BeTrue();
            (a1 == a2).Should().BeTrue();
            (a1 != a2).Should().BeFalse();
            a1.GetHashCode().Should().Be(a2.GetHashCode());
        }
    }
}