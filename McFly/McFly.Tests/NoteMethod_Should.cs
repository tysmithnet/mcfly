using System;
using FluentAssertions;
using Xunit;

namespace McFly.Tests
{
    public class NoteMethod_Should
    {
        [Fact]
        public void Not_Allow_Multiple_Note_Bodies()
        {
            var noteMethod = new NoteMethod();
            Action throw1 = () => noteMethod.Process(new[] {"add", "note1", "note2"});
            Action throw2 = () => noteMethod.Process(new[] {"add", "\"this is a note\"", "\"this is also a note\""});
            Action throw3 = () => noteMethod.Process(new[] {"add", "note1", "-a", "note2"});
            Action throw4 = () => noteMethod.Process(new[] {"add", "note1", "-a"});
            Action throw5 = () => noteMethod.Process(new[] {"add", "-a", "note1"});

            throw1.Should().Throw<ArgumentException>();
            throw2.Should().Throw<ArgumentException>();
            throw3.Should().Throw<ArgumentException>();
            throw4.Should().NotThrow<ArgumentException>();
            throw5.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void Parse_Add_Options()
        {
            var noteMethod = new NoteMethod();
            var a = noteMethod.ExtractAddOptions(new[] {"note1", "-a"});
            var a2 = noteMethod.ExtractAddOptions(new[] { "-a", "note1" });
            var n = noteMethod.ExtractAddOptions(new[] {"this is content"});

            a.IsAllThreadsAtPosition.Should().BeTrue();
            a.Text.Should().Be("note1");

            a2.IsAllThreadsAtPosition.Should().BeTrue();
            a2.Text.Should().Be("note1");

            n.IsAllThreadsAtPosition.Should().BeFalse();
            n.Text.Should().Be("this is content");
        }
    }
}
