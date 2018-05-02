using System;
using System.Collections.Generic;
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
                .WithAddTag(new Position(0, 0), new[] {1}, "This is a tag")
                .WithAddTag(new Position(0, 0), new[] {1, 2}, "This is a tag")
                .Build();
            tagMethod.Settings = new Settings {ProjectName = "test"};
            var options = new AddTagOptions
            {
                Text = "This is a tag",
                IsAllThreadsAtPosition = false
            };

            var options2 = new AddTagOptions
            {
                Text = "This is a tag",
                IsAllThreadsAtPosition = true
            };

            tagMethod.AddTag(options);
            tagMethod.AddTag(options2);
            serverClientBuilder.Mock.Verify(client => client.AddTag(new Position(0, 0), new[] {1}, "This is a tag"),
                Times.Once);
            serverClientBuilder.Mock.Verify(
                client => client.AddTag(new Position(0, 0), new[] {1, 2}, "This is a tag"), Times.Once);
        }

        [Fact]
        public void List_Ten_Most_Recent_Tags_In_Chronological_Order_When_No_Args()
        {
            var tm = new TagMethod();
            tm.ServerClient = new ServerClientBuilder()
                .WithGetRecentTags(new List<Tag>
                {
                    new Tag
                    {
                        Id = Guid.NewGuid(),
                        CreateDateUtc = DateTime.UtcNow,
                        Title = "title0",
                        Body = "body0"
                    },
                    new Tag
                    {
                        Id = Guid.NewGuid(),
                        CreateDateUtc = DateTime.UtcNow,
                        Title = "title1",
                        Body = "body1"
                    },
                    new Tag
                    {
                        Id = Guid.NewGuid(),
                        CreateDateUtc = DateTime.UtcNow.Subtract(TimeSpan.FromDays(1)),
                        Title = "title2",
                        Body = "body2"
                    }
                }).Build();
            string output = null;
            tm.DebugEngineProxy = new DebugEngineProxyBuilder()
                .WithWriteLine(s => output = s)
                .Build();
            tm.Process(new string[0]);
            output.Should().Be(@"1. title2 - body2
2. title0 - body0
3. title1 - body1
");
        }

        [Fact]
        public void Throw_If_Asked_To_Format_Null_Tags()
        {
            var method = new TagMethod();
            Action a  = () => method.FormatTagsForOutput(null);
            a.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Not_Allow_Multiple_Tag_Bodies()
        {
            var tagMethod = new TagMethod();
            Action throw1 = () => tagMethod.Process(new[] {"add", "tag1", "tag2"});
            Action throw2 = () => tagMethod.Process(new[] {"add", "\"this is a tag\"", "\"this is also a tag\""});
            Action throw3 = () => tagMethod.Process(new[] {"add", "tag1", "-a", "tag2"});
            Action throw4 = () => tagMethod.Process(new[] {"add", "tag1", "-a"});
            Action throw5 = () => tagMethod.Process(new[] {"add", "-a", "tag1"});

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
            var a = tagMethod.ExtractAddOptions(new[] {"tag1", "-a"});
            var a2 = tagMethod.ExtractAddOptions(new[] {"-a", "tag1"});
            var n = tagMethod.ExtractAddOptions(new[] {"this is content"});

            a.IsAllThreadsAtPosition.Should().BeTrue();
            a.Text.Should().Be("tag1");

            a2.IsAllThreadsAtPosition.Should().BeTrue();
            a2.Text.Should().Be("tag1");

            n.IsAllThreadsAtPosition.Should().BeFalse();
            n.Text.Should().Be("this is content");
        }

        [Fact]
        public void Throw_If_Not_Given_The_Right_Arguments()
        {
            var tm = new TagMethod();
            Action a = () => tm.Process(null);
            a.Should().Throw<ArgumentNullException>();
        }
    }
}