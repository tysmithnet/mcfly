using FluentAssertions;
using McFly.Core;
using Xunit;

namespace McFly.WinDbg.Test
{
    public class IndexOptions_Should
    {
        [Fact]
        public void Exhibit_Value_Equality()
        {
            var o1 = new IndexOptions()
            {
                Start = new Position(0,0),
                End = new Position(1,1),
                Step = 2,
                MemoryRanges = new []
                {
                    new MemoryRange(0,1), 
                },
                AccessBreakpoints = new []
                {
                    new AccessBreakpoint(0,8,true, true), 
                },
                BreakpointMasks = new []
                {
                    new BreakpointMask("kernel32", "*"), 
                },
                IsAllPositionsInRange = true
            };
            var o2 = new IndexOptions()
            {
                Start = new Position(0, 0),
                End = new Position(1, 1),
                Step = 2,
                MemoryRanges = new[]
                {
                    new MemoryRange(0,1),
                },
                AccessBreakpoints = new[]
                {
                    new AccessBreakpoint(0,8,true, true),
                },
                BreakpointMasks = new[]
                {
                    new BreakpointMask("kernel32", "*"),
                },
                IsAllPositionsInRange = true
            };

            o1.Equals(null).Should().BeFalse();
            o1.Equals(new object()).Should().BeFalse();
            o1.Equals((object)null).Should().BeFalse();
            o1.Equals(o1).Should().BeTrue();
            o1.Equals((object)o1).Should().BeTrue();
            o1.Equals((object) o2).Should().BeTrue();
            o1.Equals(o2).Should().BeTrue();
            (o1 == o2).Should().BeTrue();
            (o1 == o1).Should().BeTrue();
            (o1 != o2).Should().BeFalse();
            o1.GetHashCode().Should().Be(o2.GetHashCode());
            o1.GetHashCode().Should().Be(o2.GetHashCode());
        }
    }
}