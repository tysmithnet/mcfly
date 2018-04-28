using FluentAssertions;
using McFly.Core;
using McFly.WinDbg;
using Xunit;

namespace McFly.Test
{
    public class PositionsRecord_Should
    {
        [Fact]
        public void Exhibit_Value_Equality()
        {
            // arrange
            var left = new PositionsRecord(1, new Position(0, 0), true);
            var right = new PositionsRecord(1, new Position(0, 0), true);

            // act 
            var equal = left.Equals(right);

            // assert
            equal.Should().BeTrue();
        }
    }
}