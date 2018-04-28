using FluentAssertions;
using McFly.WinDbg;
using Xunit;

namespace McFly.Test
{
    public class IndexOptions_Should
    {
        [Fact]
        public void Exhibit_Value_Equality()
        {
            var o1 = new IndexOptions();
            var o2 = new IndexOptions();

            o1.Equals(o1).Should().BeTrue();
            o1.Equals((object) o2).Should().BeTrue();
            o1.Equals(o2).Should().BeTrue();
            (o1 == o2).Should().BeTrue();
            o1.GetHashCode().Should().Be(o2.GetHashCode());
        }
    }
}