using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using McFly.Core;
using McFly.WinDbg.Test.Builders;
using Moq;
using Xunit;

namespace McFly.WinDbg.Test
{
    public class IndexMethod_Should
    {
        [Fact]
        public void Create_Frames_For_All_Frames_With_The_Same_Position()
        {
            var indexMethod = new IndexMethod();
            indexMethod.TimeTravelFacade = new TimeTravelFacadeBuilder()
                .WithGetCurrentFrame(1, new Frame {ThreadId = 1})
                .WithGetCurrentFrame(2, new Frame {ThreadId = 2})
                .Build();

            var positionsResult = new PositionsResult(new[]
            {
                new PositionsRecord(1, new Position(1, 1), true),
                new PositionsRecord(3, new Position(2, 1), false),
                new PositionsRecord(2, new Position(1, 1), false)
            });

            var frames = indexMethod.CreateFramesForUpsert(positionsResult);
            frames[0].ThreadId.Should().Be(1);
            frames[1].ThreadId.Should().Be(2);
        }

        [Fact]
        public void Upsert_All_Frames_At_The_Current_Position()
        {
            var options = new IndexOptions()
            {
                MemoryRanges = new []
                {
                    new MemoryRange(0x100, 0x200), 
                }
            };
            var indexMethod = new IndexMethod();
            var sc = new ServerClientBuilder();
            sc.WithUpsertFrames(() =>
            {

            });
            sc.WithAddMemoryRange();
            var ttf = new TimeTravelFacadeBuilder();
            ttf.WithPositions(new PositionsResult(new[]
            {
                new PositionsRecord(1, new Position(1,1), true),
                new PositionsRecord(2, new Position(1,1), false),
            }));
            var dbg = new DebugEngineProxyBuilder();
            dbg.WithReadVirtualMemory(new byte[] {0x00, 0x11});
            indexMethod.ServerClient = sc.Build();
            indexMethod.TimeTravelFacade = ttf.Build();
            indexMethod.DebugEngineProxy = dbg.Build();

            indexMethod.UpsertCurrentPosition(options);
            sc.Mock.Verify(client => client.UpsertFrames(It.Is<IEnumerable<Frame>>(frames => frames.Count() == 2)), Times.Once);
            sc.Mock.Verify(client => client.AddMemoryRange(It.IsAny<MemoryChunk>()), Times.Once);
        }

        [Fact]
        public void Extract_Access_Breakpoints_From_Args()
        {
            var indexMethod = new IndexMethod();

            {
                var options = new IndexOptions();
                var args = new[] {"--ba", "rw8:abc120", "r8:abc420", "-s", "0:0"};
                var index = indexMethod.ExtractAccessBreakpoints(args, 0, "--ba", options);
                index.Should().Be(2);
                options.AccessBreakpoints.Should().HaveCount(2);
                options.AccessBreakpoints.ElementAt(0).Should().Be(new AccessBreakpoint(0xabc120, 8, true, true));
                options.AccessBreakpoints.ElementAt(1).Should().Be(new AccessBreakpoint(0xabc420, 8, true, false));
            }

            {
                var options = new IndexOptions();
                var args = new[] {"-s", "0:0", "--ba"};
                var index = indexMethod.ExtractAccessBreakpoints(args, 2, "--ba", options);
                index.Should().Be(2);
                options.AccessBreakpoints.Should().HaveCount(0);
            }

            {
                var options = new IndexOptions();
                var args = new[] {"--ba", "gibberish", "-s", "0:0"};
                Action a = () => indexMethod.ExtractAccessBreakpoints(args, 0, "--ba", options);
                a.Should().Throw<FormatException>();
            }
        }

        [Fact]
        public void Extract_Breakpoint_Masks_From_Args()
        {
            var indexMethod = new IndexMethod();

            {
                var options = new IndexOptions();
                var args = new[] {"--bm", "kernel32!*", "ntdll!*", "-s", "0:0"};
                var index = indexMethod.ExtractBreakpointMasks(args, 0, "--bm", options);
                index.Should().Be(2);
                options.BreakpointMasks.Should().HaveCount(2);
                options.BreakpointMasks.ElementAt(0).Should().Be(new BreakpointMask("kernel32", "*"));
                options.BreakpointMasks.ElementAt(1).Should().Be(new BreakpointMask("ntdll", "*"));
            }

            {
                var options = new IndexOptions();
                var args = new[] {"--bm"};
                var index = indexMethod.ExtractBreakpointMasks(args, 0, "--bm", options);
                index.Should().Be(0);
                options.BreakpointMasks.Should().HaveCount(0);
            }

            {
                var options = new IndexOptions();
                var args = new[] {"--bm", "gibberish", "-s", "0:0"};
                Action a = () => indexMethod.ExtractBreakpointMasks(args, 0, "--bm", options);
                a.Should().Throw<FormatException>();
            }
        }

        [Fact]
        public void Extract_Memory_Ranges_()
        {
            var indexMethod = new IndexMethod();

            {
                var options = new IndexOptions();
                var args = new[] {"-m", "abc120L50", "abc100:abc420", "-s", "0:0"};
                var index = indexMethod.ExtractMemoryRanges(args, 0, "-m", options);
                index.Should().Be(2);
                options.MemoryRanges.Should().HaveCount(2);
                options.MemoryRanges.ElementAt(0).Should().Be(new MemoryRange(0xabc120, 0xabc170));
                options.MemoryRanges.ElementAt(1).Should().Be(new MemoryRange(0xabc100, 0xabc420));
            }

            {
                var options = new IndexOptions();
                var args = new[] {"-s", "0:0", "--ba", "-m"};
                var index = indexMethod.ExtractMemoryRanges(args, 4, "-m", options);
                index.Should().Be(4);
                options.MemoryRanges.Should().HaveCount(0);
            }

            {
                var options = new IndexOptions();
                var args = new[] {"-m", "gibberish", "-s", "0:0"};
                Action a = () => indexMethod.ExtractMemoryRanges(args, 0, "-m", options);
                a.Should().Throw<FormatException>();
            }
        }

        [Fact]
        public void Extract_The_Desired_Ending_Position_From_Args()
        {
            var indexMethod = new IndexMethod();

            {
                var options = new IndexOptions();
                var args = new[] {"--ba", "-s", "0:0", "-e", "42:10"};
                var index = indexMethod.ExtractEndingPosition(args, 3, "-e", options);
                index.Should().Be(4);
                options.End.Should().Be(new Position(0x42, 0x10));
            }

            {
                var options = new IndexOptions();
                var args = new[] {"--ba", "-e", "1:0", "-s", "0:0"};
                var index = indexMethod.ExtractEndingPosition(args, 1, "-e", options);
                index.Should().Be(2);
                options.End.Should().Be(new Position(1, 0));
            }

            {
                var options = new IndexOptions();
                var args = new[] {"--ba", "-e", "gibberish", "-s", "0:0"};
                Action a = () => indexMethod.ExtractEndingPosition(args, 1, "-e", options);
                a.Should().Throw<FormatException>();
            }

            {
                var options = new IndexOptions();
                var args = new[] {"--ba", "-e"};
                Action a = () => indexMethod.ExtractEndingPosition(args, 1, "-e", options);
                a.Should().Throw<ArgumentException>();
            }
        }

        [Fact]
        public void Extract_The_Desired_Starting_Position_From_Args()
        {
            var indexMethod = new IndexMethod();

            {
                var options = new IndexOptions();
                var args = new[] {"--ba", "-s", "0:0", "-e", "42:10"};
                var index = indexMethod.ExtractStartingPosition(args, 1, "-s", options);
                index.Should().Be(2);
                options.Start.Should().Be(new Position(0, 0));
            }

            {
                var options = new IndexOptions();
                var args = new[] {"--ba", "-e", "1:0", "-s", "0:0"};
                var index = indexMethod.ExtractStartingPosition(args, 3, "-s", options);
                index.Should().Be(4);
                options.Start.Should().Be(new Position(0, 0));
            }

            {
                var options = new IndexOptions();
                var args = new[] {"--ba", "-e", "1:0", "-s", "gibberish"};
                Action a = () => indexMethod.ExtractStartingPosition(args, 3, "-s", options);
                a.Should().Throw<FormatException>();
            }

            {
                var options = new IndexOptions();
                var args = new[] {"--ba", "-s"};
                Action a = () => indexMethod.ExtractStartingPosition(args, 1, "-s", options);
                a.Should().Throw<ArgumentException>();
            }
        }

        [Fact]
        public void Extract_The_Desired_Step_From_Args()
        {
            var indexMethod = new IndexMethod();

            {
                var options = new IndexOptions();
                var args = new[] {"--ba", "-s", "0:0", "-e", "42:10", "--step", "1"};
                var index = indexMethod.ExtractStep(args, 5, options);
                index.Should().Be(6);
                options.Step.Should().Be(1);
            }

            {
                var options = new IndexOptions();
                var args = new[] {"--step", "1", "-s", "0:0", "-e", "42:10"};
                var index = indexMethod.ExtractStep(args, 0, options);
                index.Should().Be(1);
                options.Step.Should().Be(1);
            }

            {
                var options = new IndexOptions();
                var args = new[] {"--ba", "--step", "gibberish", "-s", "0:0"};
                Action a = () => indexMethod.ExtractStep(args, 1, options);
                a.Should().Throw<FormatException>();
            }

            {
                var options = new IndexOptions();
                var args = new[] {"--ba", "--step"};
                Action a = () => indexMethod.ExtractStep(args, 1, options);
                a.Should().Throw<ArgumentException>();
            }
        }

        [Fact]
        public void Get_The_Correct_Ending_Position()
        {
            var indexMethod = new IndexMethod();
            indexMethod.TimeTravelFacade = new TimeTravelFacadeBuilder()
                .WithLastPosition(new Position(1, 1))
                .Build();
            indexMethod.GetEndingPosition(new IndexOptions()).Should().Be(new Position(1, 1));
            indexMethod.GetEndingPosition(new IndexOptions {End = new Position(2, 2)}).Should().Be(new Position(2, 2));
        }

        [Fact]
        public void Get_The_Correct_Starting_Position()
        {
            var indexMethod = new IndexMethod();
            indexMethod.TimeTravelFacade = new TimeTravelFacadeBuilder()
                .WithFirstPosition(new Position(1, 1))
                .Build();
            indexMethod.GetStartingPosition(new IndexOptions()).Should().Be(new Position(1, 1));
            indexMethod.GetStartingPosition(new IndexOptions {Start = new Position(2, 2)}).Should()
                .Be(new Position(2, 2));
        }

        [Fact]
        public void Index_All_Breakpoint_Hits_If_All_Isnt_Provided()
        {
            var mock = new Mock<IndexMethod>();
            mock.CallBase = true;
            mock.SetupAllProperties();
            mock.Object.BreakpointFacade = new BreakpointFacadeBuilder().Build();
            mock.Object.DebugEngineProxy = new DebugEngineProxyBuilder().Build();
            var ttf = new Mock<ITimeTravelFacade>();
            ttf.SetupSequence(facade => facade.SetPosition(It.IsAny<Position>()))
                .Returns(new SetPositionResult
                {
                    ActualPosition = new Position(0, 0)
                })
                .Returns(new SetPositionResult
                {
                    ActualPosition = new Position(0, 1),
                    BreakpointHit = 2
                }).Returns(new SetPositionResult
                {
                    ActualPosition = new Position(0, 2),
                    BreakpointHit = 3
                }).Returns(new SetPositionResult
                {
                    ActualPosition = new Position(1, 0),
                    BreakpointHit = 2
                }).Returns(new SetPositionResult
                {
                    ActualPosition = new Position(1, 1),
                    BreakpointHit = 1
                });
            ttf.SetupSequence(facade => facade.GetCurrentPosition())
                .Returns(new Position(0, 1))
                .Returns(new Position(0, 2))
                .Returns(new Position(1, 0))
                .Returns(new Position(1, 1));
            mock.Object.TimeTravelFacade = ttf.Object;

            mock.Setup(method => method.GetStartingPosition(It.IsAny<IndexOptions>())).Returns(new Position(0, 0));
            mock.Setup(method => method.GetEndingPosition(It.IsAny<IndexOptions>())).Returns(new Position(1, 0));
            mock.Setup(method => method.UpsertCurrentPosition(It.IsAny<IndexOptions>()));
            mock.Setup(method => method.SetBreakpoints(It.IsAny<IndexOptions>()));

            mock.Object.IndexBreakpointHits(new IndexOptions());
            mock.Verify(method => method.UpsertCurrentPosition(It.IsAny<IndexOptions>()), Times.Exactly(3));
        }

        [Fact]
        public void Index_All_Positions_In_Range_If_All_Is_Passed()
        {
            var mock = new Mock<IndexMethod>();
            mock.CallBase = true;
            mock.Setup(method => method.ExtractIndexOptions(It.IsAny<string[]>())).Returns(new IndexOptions
            {
                IsAllPositionsInRange = true
            });
            mock.Setup(method => method.IndexAllPositionsInRange(It.IsAny<IndexOptions>()));
            mock.Object.Process(new string[0]);
            mock.Verify(method => method.IndexAllPositionsInRange(It.IsAny<IndexOptions>()), Times.Once);
        }

        [Fact]
        public void Index_All_Positions_In_Range_If_All_Is_Provided()
        {
            var mock = new Mock<IndexMethod>();
            mock.CallBase = true;
            mock.SetupAllProperties();
            var ttf = new Mock<ITimeTravelFacade>();
            ttf.SetupSequence(facade => facade.SetPosition(It.IsAny<Position>()))
                .Returns(new SetPositionResult
                {
                    ActualPosition = new Position(0, 0)
                })
                .Returns(new SetPositionResult
                {
                    ActualPosition = new Position(0, 1)
                }).Returns(new SetPositionResult
                {
                    ActualPosition = new Position(0, 2)
                }).Returns(new SetPositionResult
                {
                    ActualPosition = new Position(1, 0)
                }).Returns(new SetPositionResult
                {
                    ActualPosition = new Position(1, 1)
                });

            mock.Object.TimeTravelFacade = ttf.Object;

            mock.Setup(method => method.GetStartingPosition(It.IsAny<IndexOptions>())).Returns(new Position(0, 0));
            mock.Setup(method => method.GetEndingPosition(It.IsAny<IndexOptions>())).Returns(new Position(1, 0));
            mock.Setup(method => method.UpsertCurrentPosition(It.IsAny<IndexOptions>()));

            mock.Object.IndexAllPositionsInRange(null);
            mock.Verify(method => method.UpsertCurrentPosition(It.IsAny<IndexOptions>()), Times.Exactly(4));
        }

        [Fact]
        public void Index_Breakpoint_Hits_If_All_Is_Not_Set()
        {
            var mock = new Mock<IndexMethod>();
            mock.CallBase = true;
            mock.Setup(method => method.ExtractIndexOptions(It.IsAny<string[]>())).Returns(new IndexOptions
            {
                IsAllPositionsInRange = false
            });
            mock.Setup(method => method.IndexBreakpointHits(It.IsAny<IndexOptions>()));
            mock.Object.Process(new string[0]);
            mock.Verify(method => method.IndexBreakpointHits(It.IsAny<IndexOptions>()), Times.Once);
        }

        [Fact]
        public void Process_Command_Line_Arguments_Properly()
        {
            var indexMethod = new IndexMethod();

            {
                var options = indexMethod.ExtractIndexOptions(new string[] { });
                options.AccessBreakpoints.Should().BeNull();
                options.End.Should().BeNull();
                options.BreakpointMasks.Should().BeNull();
                options.IsAllPositionsInRange.Should().BeFalse();
                options.Step.Should().Be(0);
                options.Start.Should().BeNull();
                options.MemoryRanges.Should().BeNull();
            }

            {
                var options = indexMethod.ExtractIndexOptions(new[]
                {
                    "-s", "0:0", "-m", "abc123L50", "def341:def441", "-e", "1:0", "--step", "1", "--ba", "rw8:abc120",
                    "--bm", "kernel32!*", "-a"
                });
                options.AccessBreakpoints.Should().HaveCount(1);
                options.End.Should().Be(new Position(1, 0));
                options.BreakpointMasks.Should().HaveCount(1);
                options.IsAllPositionsInRange.Should().BeTrue();
                options.Step.Should().Be(1);
                options.Start.Should().Be(new Position(0, 0));
                options.MemoryRanges.Should().HaveCount(2);
            }
        }

        [Fact]
        public void Set_Breakpoints_Correctly()
        {
            var options = new IndexOptions()
            {
                BreakpointMasks = new []
                {
                    new BreakpointMask("kernel32", "*create*"),
                    new BreakpointMask("kernel32", "*process*"),
                },
                AccessBreakpoints = new []
                {
                    new AccessBreakpoint(0x100, 8, true, false),
                }
            };
            var indexMethod = new IndexMethod();
            BreakpointFacadeBuilder breakpointFacadeBuilder = new BreakpointFacadeBuilder();
            indexMethod.BreakpointFacade = breakpointFacadeBuilder
                .WithSetBreakpointByMask()
                .WithSetReadAccessBreakpoint()
                .Build();
            indexMethod.SetBreakpoints(options);
            breakpointFacadeBuilder.Mock.Verify(facade => facade.SetBreakpointByMask(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            breakpointFacadeBuilder.Mock.Verify(facade => facade.SetReadAccessBreakpoint(It.IsAny<int>(), It.IsAny<ulong>()), Times.Once);
        }

        

        [Fact]
        public void Step_Additional_Positions_If_Provided()
        {
            var mock = new Mock<IndexMethod>();
            mock.CallBase = true;
            mock.SetupAllProperties();
            mock.Object.BreakpointFacade = new BreakpointFacadeBuilder().Build();
            mock.Object.DebugEngineProxy = new DebugEngineProxyBuilder().Build();
            var ttf = new Mock<ITimeTravelFacade>();
            ttf.SetupSequence(facade => facade.SetPosition(It.IsAny<Position>()))
                .Returns(new SetPositionResult
                {
                    ActualPosition = new Position(0, 0)
                })
                .Returns(new SetPositionResult
                {
                    ActualPosition = new Position(0, 1),
                    BreakpointHit = 2
                }).Returns(new SetPositionResult
                {
                    ActualPosition = new Position(0, 2),
                    BreakpointHit = 3
                }).Returns(new SetPositionResult
                {
                    ActualPosition = new Position(1, 0),
                    BreakpointHit = 2
                }).Returns(new SetPositionResult
                {
                    ActualPosition = new Position(1, 1),
                    BreakpointHit = 1
                });
            ttf.SetupSequence(facade => facade.GetCurrentPosition())
                .Returns(new Position(0, 1))
                .Returns(new Position(0, 2))
                .Returns(new Position(1, 0))
                .Returns(new Position(1, 1));
            mock.Object.TimeTravelFacade = ttf.Object;

            mock.Setup(method => method.GetStartingPosition(It.IsAny<IndexOptions>())).Returns(new Position(0, 0));
            mock.Setup(method => method.GetEndingPosition(It.IsAny<IndexOptions>())).Returns(new Position(1, 0));
            mock.Setup(method => method.UpsertCurrentPosition(It.IsAny<IndexOptions>()));
            mock.Setup(method => method.SetBreakpoints(It.IsAny<IndexOptions>()));

            mock.Object.IndexBreakpointHits(new IndexOptions
            {
                Step = 3
            });
            mock.Verify(method => method.UpsertCurrentPosition(It.IsAny<IndexOptions>()), Times.Exactly(3));
        }
    }
}