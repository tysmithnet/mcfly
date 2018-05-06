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
        public void Add_A_Tag_To_The_Current_Frame_When_Called_With_Title_And_Body()
        {
            var method = new TagMethod();
            var engBuilder = new DebugEngineProxyBuilder();
            var debugEngineProxy = engBuilder
                .WithThreadId(1).Build();
            var timeTravelFacade = new TimeTravelFacadeBuilder(engBuilder)
                .WithGetCurrentPosition(new Position(1, 1))
                .WithPositions(new PositionsResult(new List<PositionsRecord>()
                {
                    new PositionsRecord(1, new Position(1,1), true )
                }))
                .Build();
            var serverClientBuilder = new ServerClientBuilder();
            var serverClient = serverClientBuilder
                .WithAddTag()
                .Build();

            method.DebugEngineProxy = debugEngineProxy;
            method.TimeTravelFacade = timeTravelFacade;
            method.ServerClient = serverClient;
            method.Process(new[] {"add", "-t", "title", "-b", "body"});
            method.Process(new[] { "add", "--title", "title", "-b", "body" });
            method.Process(new[] { "add", "-t", "title", "--body", "body" });
            method.Process(new[] { "add", "--title", "title", "--body", "body" });
            serverClientBuilder.Mock.Verify(client => client.AddTag(new Position(1,1), new int[]{1}, It.Is<Tag>(tag => tag.Body == "body" && tag.Title == "title")), Times.Exactly(4));
        }

        [Fact]
        public void Tag_All_Frames_At_The_Same_Position_If_All_Is_Set()
        {
            var method = new TagMethod();
            var engBuilder = new DebugEngineProxyBuilder();
            var debugEngineProxy = engBuilder
                .WithThreadId(1).Build();
            var timeTravelFacade = new TimeTravelFacadeBuilder(engBuilder)
                .WithGetCurrentPosition(new Position(1, 1))
                .WithPositions(new PositionsResult(new List<PositionsRecord>()
                {
                    new PositionsRecord(1, new Position(1,1), true ),
                    new PositionsRecord(2, new Position(1,1), false )
                }))
                .Build();
            var serverClientBuilder = new ServerClientBuilder();
            var serverClient = serverClientBuilder
                .WithAddTag()
                .Build();

            method.DebugEngineProxy = debugEngineProxy;
            method.TimeTravelFacade = timeTravelFacade;
            method.ServerClient = serverClient;
            method.Process(new[] { "add", "-t", "title", "-b", "body", "-a" });
            method.Process(new[] { "add", "--title", "title","--all", "-b", "body" });
            serverClientBuilder.Mock.Verify(client => client.AddTag(new Position(1, 1), new int[] { 1, 2 }, It.Is<Tag>(tag => tag.Body == "body" && tag.Title == "title")), Times.Exactly(2));
        }

        [Fact]
        public void Throw_If_Given_Bad_Args()
        {
            var method = new TagMethod();
            Action a = () => method.ExtractAddOptions(new[] {"-t", "title", "-b"});
            Action a2 = () => method.ExtractAddOptions(new[] {"-t"});
            a.Should().Throw<ArgumentException>();
            a2.Should().Throw<ArgumentException>();
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
            Action a = () => method.FormatTagsForOutput(null);
            a.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Throw_If_Invalid_Subcommand_Passed()
        {
            var method = new TagMethod();
            Action a = () => method.Process(new[] {"gibberish"});
            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Throw_If_Not_Given_Valid_Arguments()
        {
            var tm = new TagMethod();
            Action a = () => tm.Process(null);
            a.Should().Throw<ArgumentNullException>();
            a = () => tm.Process(new[] {"gibberish"});
            a.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}