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

        [Fact]
        public void Return_The_Existing_Tag_If_One_Exists()
        {
            var id = Guid.NewGuid();
            var dc = DateTime.UtcNow;
            var builder = new ContextFactoryBuilder();
            TagEntity tag = new TagEntity()
            {
                Id = id,
                Body = "body",
                Title = "title",
                CreateDateUtc = dc
            };
            builder.WithTag(tag);
            var fac = builder.Build();
            var context = fac.GetContext("");
            var converter = new TagDomainEntityConverter();
            converter.ToEntity(new Tag() {Id = id}, context).Should().BeSameAs(tag);
        }
    }
}