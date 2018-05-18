using FluentAssertions;
using McFly.Core;
using Xunit;

namespace McFly.Server.Core.Test
{
    public class AddTagRequest_Should
    {
        [Fact]
        public void Exhibit_Value_Equality()
        {
            var addTagRequest = new AddTagRequest(new Position(0, 0), new[] {1}, new Tag());
            var expected = new AddTagRequest(new Position(0, 0), new[] {1}, new Tag());
            addTagRequest.Should().Be(expected);
            addTagRequest.GetHashCode().Should().Be(addTagRequest.GetHashCode());
            (addTagRequest == expected).Should().BeTrue();
            (addTagRequest != expected).Should().BeFalse();
            addTagRequest.Equals((object) expected).Should().BeTrue();
            addTagRequest.Equals(addTagRequest).Should().BeTrue();
        }
    }
}