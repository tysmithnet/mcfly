using System;
using System.Collections.Generic;
using FluentAssertions;
using McFly.Core;
using McFly.WinDbg.Test.Builders;
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
                .Build();
            var serverClientBuilder = new ServerClientBuilder();
            var serverClient = serverClientBuilder
                .WithAddTag()
                .Build();

            method.DebugEngineProxy = debugEngineProxy;
            method.TimeTravelFacade = timeTravelFacade;
            method.ServerClient = serverClient;
            method.Process(new[] {"-t", "title", "-b", "body"});
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