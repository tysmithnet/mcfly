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
            one.Equals(null).Should().BeFalse();
            one.Equals((object) null).Should().BeFalse();
            one.Equals(new object()).Should().BeFalse();
            one.Equals(one).Should().BeTrue();
            one.Equals(two).Should().BeTrue();
            one.Equals((object)one).Should().BeTrue();
            one.Equals((object)two).Should().BeTrue();
            one.GetHashCode().Should().Be(two.GetHashCode());
            one.Equals(three).Should().BeFalse();
            two.Equals(three).Should().BeFalse();
        }
    }
}