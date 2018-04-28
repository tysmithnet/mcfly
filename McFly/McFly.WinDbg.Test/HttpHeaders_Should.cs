using FluentAssertions;
using Xunit;

namespace McFly.WinDbg.Test
{
    public class HttpHeaders_Should
    {
        [Fact]
        public void Exhibit_Value_Equality()
        {
            // arrange
            var empty = new HttpHeaders();
            var one = new HttpHeaders();
            one.Add("a", "1");
            one.Add("b", "2");
            var two = new HttpHeaders();
            two.Add("a", "1");
            two.Add("b", "2");
            var three = new HttpHeaders();
            three.Add("a", "1");

            // act
            // assert
            empty.GetHashCode().Should().Be(new HttpHeaders().GetHashCode());
            empty.Should().Equal(new HttpHeaders());
            one.Should().Equal(two);
            two.Should().NotEqual(three);
            (one == two).Should().BeTrue();
            (two != three).Should().BeTrue();
            one.GetHashCode().Should().Be(two.GetHashCode());
        }
    }
}