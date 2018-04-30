using System;
using FluentAssertions;
using Xunit;

namespace McFly.Core.Test
{
    public class Tag_Should
    {
        [Fact]
        public void Exhibit_Entity_Equality()
        {
            var guid = Guid.Empty;
            var t1 = new Tag
            {
                Id = guid,
                Body = "body",
                CreateDateUtc = DateTime.MinValue,
                Title = "title"
            };
            var t2 = new Tag
            {
                Id = guid,
                Body = "body",
                CreateDateUtc = DateTime.MinValue,
                Title = "title"
            };
            var t3 = new Tag
            {
                Id = Guid.NewGuid(),
                Body = "body",
                CreateDateUtc = DateTime.MinValue,
                Title = "title"
            };
            t1.Equals(null).Should().BeFalse();
            t1.Equals((object) null).Should().BeFalse();
            t1.Equals(t1).Should().BeTrue();
            t1.Equals((object) t1).Should().BeTrue();
            t1.Equals(t2).Should().BeTrue();
            t1.Equals(t3).Should().BeFalse();
            t1.GetHashCode().Should().Be(t2.GetHashCode());
        }
    }
}