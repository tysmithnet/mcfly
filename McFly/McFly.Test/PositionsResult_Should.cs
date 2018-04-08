using FluentAssertions;
using McFly.Core;
using Xunit;

namespace McFly.Test
{
    public class PositionsResult_Should
    {
        [Fact]
        public void Identify_The_Current_Thread()
        {
            // arrange
            var records = new[]
            {
                new PositionsRecord(1, new Position(0, 0), false),
                new PositionsRecord(2, new Position(1, 0), true),
                new PositionsRecord(3, new Position(2, 0), false),
                new PositionsRecord(4, new Position(3, 0), false)
            };
            var result = new PositionsResult(records);

            // act
            var thread = result.CurrentThreadResult;

            // assert
            thread.ThreadId.Should().Be(2);
        }
    }
}