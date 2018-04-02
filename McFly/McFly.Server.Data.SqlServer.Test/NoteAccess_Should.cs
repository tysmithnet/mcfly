using System.Linq;
using FluentAssertions;
using McFly.Core;
using Xunit;

namespace McFly.Server.Data.SqlServer.Test
{
    public class NoteAccess_Should
    {
        [Fact]
        public void Add_Note_To_Specified_Frames()
        {
            var noteAccess = new NoteAccess();
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
            noteAccess.ContextFactory = builder.Build();

            noteAccess.AddNote("", new Position(0, 0), new[] {1, 2}, "test note");
            noteAccess.GetNotes("", new Position(0, 0), 1).Single().Text.Should().Be("test note");
            noteAccess.GetNotes("", new Position(0, 0), 2).Single().Text.Should().Be("test note");
        }
    }
}