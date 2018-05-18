using FluentAssertions;
using McFly.Core;
using Xunit;

namespace McFly.WinDbg.Test
{
    public class PositionsRecord_Should
    {
        [Fact]
        public void Exhibit_Value_Equality()
        {
            var r1 = new PositionsRecord(1, new Position(0, 0), true);
            var r2 = new PositionsRecord(1, new Position(0, 0), true);

            r1.Equals(r1).Should().BeTrue();
            r1.Equals((object)r1).Should().BeTrue();
            r1.Equals(null).Should().BeFalse();
            r1.Equals((object)null).Should().BeFalse();
            r1.Equals(new object()).Should().BeFalse();
            r1.Equals(r2).Should().BeTrue();
            r1.GetHashCode().Should().Be(r2.GetHashCode());
        }
    }
}