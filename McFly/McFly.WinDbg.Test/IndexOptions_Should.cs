using FluentAssertions;
using McFly.WinDbg;
using Xunit;

namespace McFly.WinDbg.Test
{
    public class IndexOptions_Should
    {
        [Fact]
        public void Exhibit_Value_Equality()
        {
            var o1 = new IndexOptions();
            var o2 = new IndexOptions();

            AssertionExtensions.Should((bool) o1.Equals(o1)).BeTrue();
            AssertionExtensions.Should((bool) o1.Equals((object) o2)).BeTrue();
            AssertionExtensions.Should((bool) o1.Equals(o2)).BeTrue();
            AssertionExtensions.Should((bool) (o1 == o2)).BeTrue();
            AssertionExtensions.Should((int) o1.GetHashCode()).Be(o2.GetHashCode());
        }
    }
}