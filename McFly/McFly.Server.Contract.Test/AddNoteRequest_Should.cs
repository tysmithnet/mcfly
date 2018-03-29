using FluentAssertions;
using McFly.Core;
using Xunit;

namespace McFly.Server.Contract.Test
{
    public class AddNoteRequest_Should
    {
        [Fact]
        public void Exhibit_Value_Equality()
        {
            var addNoteRequest = new AddNoteRequest(new Position(0, 0), 1, "");
            var expected = new AddNoteRequest(new Position(0, 0), 1, "");
            addNoteRequest.Should().Be(expected);
            addNoteRequest.GetHashCode().Should().Be(addNoteRequest.GetHashCode());
            (addNoteRequest == expected).Should().BeTrue();
            (addNoteRequest != expected).Should().BeFalse();
            addNoteRequest.Equals((object) expected).Should().BeTrue();
            addNoteRequest.Equals(addNoteRequest).Should().BeTrue();
        }
    }
}