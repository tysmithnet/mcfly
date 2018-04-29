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
        public void Convert_Between_Tag_And_TagEntity_Correctly()
        {
            var builder = new ContextFactoryBuilder();
            var fac = builder.Build();
            var tag = new Tag
            {
                Body = "body",
                Title = "title",
                CreateDateUtc = DateTime.MinValue
            };
            var converter = new TagDomainEntityConverter();
            var entity = converter.ToEntity(tag, fac.GetContext(""));
            var domain = converter.ToDomain(entity, fac.GetContext(""));
            domain.Should().Be(tag);
        }
    }
}