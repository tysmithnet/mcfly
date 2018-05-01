using System;
using FluentAssertions;
using McFly.Core;
using McFly.Server.Data.SqlServer.Test.Builders;
using Xunit;

namespace McFly.Server.Data.SqlServer.Test
{
    public class TagDomainEntityConverter_Should
    {
        [Fact]
        public void Convert_Between_Tag_And_TagEntity()
        {
            var builder = new ContextFactoryBuilder();
            var fac = builder.Build();
            var context = fac.GetContext("");
            var tag = new Tag();
            tag.CreateDateUtc = DateTime.MinValue;
            tag.Title = "hello there";
            tag.Body = "body";
            var converter = new TagDomainEntityConverter();
            var converted = converter.ToEntity(tag, context);
            converted.Title.Should().Be("hello there");
            converted.Body.Should().Be("body");
            var convertedBack = converter.ToDomain(converted, context);
            convertedBack.Title.Should().Be("hello there");
            convertedBack.Body.Should().Be("body");
            convertedBack.CreateDateUtc.Should().Be(DateTime.MinValue);
        }
    }
}