using System;
using FluentAssertions;
using McFly.Core;
using McFly.WinDbg.Test.Builders;
using Moq;
using Xunit;

namespace McFly.WinDbg.Test
{
    public class TagMethod_Should
    {
        [Fact]
        public void Add_Tags_Correctly()
        {
            var tagMethod = new TagMethod();
            var dbg = new DebugEngineProxyBuilder();
            tagMethod.TimeTravelFacade = new TimeTravelFacadeBuilder(dbg)
                .WithPositions(new PositionsResult(new[]
                {
                    new PositionsRecord(1, new Position(0, 0), true),
                    new PositionsRecord(2, new Position(0, 0), false)
                })).Build();
            var serverClientBuilder = new ServerClientBuilder();
            tagMethod.ServerClient = serverClientBuilder
                .WithAddTag(new Position(0, 0), new[] {1}, "This is a note")
                .WithAddTag(new Position(0, 0), new[] {1, 2}, "This is a note")
                .Build();
            tagMethod.Settings = new Settings {ProjectName = "test"};
            var options = new AddTagOptions
            {
                Text = "This is a note",
                IsAllThreadsAtPosition = false
            };

            var options2 = new AddTagOptions
            {
                Text = "This is a note",
                IsAllThreadsAtPosition = true
            };

            tagMethod.AddTag(options);
            tagMethod.AddTag(options2);
            serverClientBuilder.Mock.Verify(client => client.AddTag(new Position(0, 0), new[] {1}, "This is a note"),
                Times.Once);
            serverClientBuilder.Mock.Verify(
                client => client.AddTag(new Position(0, 0), new[] {1, 2}, "This is a note"), Times.Once);
        }

        [Fact]
        public void Not_Allow_Multiple_Note_Bodies()
        {
            var tagMethod = new TagMethod();
            Action throw1 = () => tagMethod.Process(new[] {"add", "note1", "note2"});
            Action throw2 = () => tagMethod.Process(new[] {"add", "\"this is a note\"", "\"this is also a note\""});
            Action throw3 = () => tagMethod.Process(new[] {"add", "note1", "-a", "note2"});
            Action throw4 = () => tagMethod.Process(new[] {"add", "note1", "-a"});
            Action throw5 = () => tagMethod.Process(new[] {"add", "-a", "note1"});

            throw1.Should().Throw<ArgumentException>();
            throw2.Should().Throw<ArgumentException>();
            throw3.Should().Throw<ArgumentException>();
            throw4.Should().NotThrow<ArgumentException>();
            throw5.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void Parse_Add_Options()
        {
            var tagMethod = new TagMethod();
            var a = tagMethod.ExtractAddOptions(new[] {"note1", "-a"});
            var a2 = tagMethod.ExtractAddOptions(new[] {"-a", "note1"});
            var n = tagMethod.ExtractAddOptions(new[] {"this is content"});

            a.IsAllThreadsAtPosition.Should().BeTrue();
            a.Text.Should().Be("note1");

            a2.IsAllThreadsAtPosition.Should().BeTrue();
            a2.Text.Should().Be("note1");

            n.IsAllThreadsAtPosition.Should().BeFalse();
            n.Text.Should().Be("this is content");
        }
    }
}