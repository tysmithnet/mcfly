using System.Linq;
using FluentAssertions;
using McFly.Core;
using McFly.Server.Data.SqlServer.Test.Builders;
using Xunit;

namespace McFly.Server.Data.SqlServer.Test
{
    public class TagAccess_Should
    {
        [Fact]
        public void Add_Tag_To_Specified_Frames()
        {
            var tagAccess = new TagAccess();
            var builder = new ContextFactoryBuilder();
            builder.WithFrame(new FrameEntity
            {
                PosHi = 0,
                PosLo = 0,
                ThreadId = 1
            }).WithFrame(new FrameEntity
            {
                PosHi = 0,
                PosLo = 0,
                ThreadId = 2
            });
            tagAccess.ContextFactory = builder.Build();

            tagAccess.AddTag("", new Position(0, 0), new[] {1, 2}, new Tag(){Title = "test tag"});
            tagAccess.GetTags("", new Position(0, 0), 1).Single().Title.Should().Be("test tag");
            tagAccess.GetTags("", new Position(0, 0), 2).Single().Title.Should().Be("test tag");
        }
    }
}