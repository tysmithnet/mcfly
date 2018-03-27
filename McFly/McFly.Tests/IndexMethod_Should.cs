using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using McFly.Core;
using Moq;
using Xunit;

namespace McFly.Tests
{
    public class IndexMethod_Should
    {
        [Fact]
        public void Get_Stack_Frames_Correctly()
        {
            // arrange
            var stackTrace = @"00000000`0014d1d0 00007ffa`513138e6 KERNEL32!GetTimeFormatWWorker+0x7ed
00000000`0014d220 00007ffa`513165ee KERNEL32!QuirkIsEnabledForPackageWorker";

            var expected = new[]
            {
                new StackFrame(0x014d1d0, 0x0007ffa513138e6, "KERNEL32", "GetTimeFormatWWorker", 0x7ed),
                new StackFrame(0x014d220, 0x0007ffa513165ee, "KERNEL32", "QuirkIsEnabledForPackageWorker", 0)
            };

            // act                                                                           
            // assert
            IndexMethod.GetStackFrames(stackTrace).Should().Equal(expected);
        }

        [Fact]
        public void Identify_32_And_64_Bit_Arch()
        {
            // Arrange
            var builder = new DebugEngineProxyBuilder();
            builder.WithExecuteResult("!peb", @"PEB at 00000000003b9000
    InheritedAddressSpace:    No
    ReadImageFileExecOptions: No
    BeingDebugged:            No
    ...
    ImageBaseAddress:         0000000140000000        _NT_SYMBOL_PATH=SRV*c:\symbols*http://msdl.microsoft.com/download/symbols");
            var proxy = builder.Build();

            // Act
            var indexMethod = new IndexMethod();
            indexMethod.DebugEngineProxy = builder.Build();
            var is32 = indexMethod.Is32Bit();

            // Assert
            is32.Should().BeFalse("00000000003b9000 is 16 characters and thus 64bit");
        }

        [Fact]
        public void Identify_Correct_Ending_Position()
        {
            // Arrange                             
            var options = new IndexOptions
            {
                End = new Position(0x35, 0x1)
            };

            var dbg = new DebugEngineProxyBuilder();
            var indexMethod = new IndexMethod();
            indexMethod.DebugEngineProxy = dbg.Build();
            var builder = new TimeTravelFacadeBuilder(dbg);
            builder.WithGetEndingPosition(new Position(0x35, 5));
            indexMethod.TimeTravelFacade = builder.Build();

            // Act
            var endingPosition = indexMethod.GetEndingPosition(options);

            // Assert
            endingPosition.Should().Be(new Position(0x35, 1),
                "35:1 means that the high portion is 35 and the low portion is 1");
        }

        [Fact]
        public void Identify_Correct_Starting_Position()
        {
            // Arrange                             
            var options = new IndexOptions
            {
                Start = new Position(0x35, 0x1)
            };

            var dbg = new DebugEngineProxyBuilder();
            var indexMethod = new IndexMethod();
            indexMethod.DebugEngineProxy = dbg.Build();
            var builder = new TimeTravelFacadeBuilder(dbg);
            builder.WithGetStartingPosition(new Position(0x35, 0));
            indexMethod.TimeTravelFacade = builder.Build();

            // Act
            var startingPosition = indexMethod.GetStartingPosition(options);

            // Assert
            startingPosition.Should().Be(new Position(0x35, 1),
                "35:1 means that the high portion is 35 and the low portion is 1");
        }

        [Fact]
        public void Set_Breakpoints_If_They_Are_Provided_In_The_Options()
        {
            // arrange
            var indexMethod = new IndexMethod();
            var indexOptions = new IndexOptions
            {
                AccessBreakpoints = new[] {AccessBreakpoint.Parse("r8:100"), AccessBreakpoint.Parse("w8:200"), AccessBreakpoint.Parse("rw4:300"), },
                BreakpointMasks = new[] {BreakpointMask.Parse("kernel32!createprocess*"), BreakpointMask.Parse("user32!*"), BreakpointMask.Parse("mycustommod!myfancyfunction"), }
            };
            var builder = new BreakpointFacadeBuilder();
            indexMethod.BreakpointFacade = builder.Build();

            // act
            indexMethod.SetBreakpoints(indexOptions);

            // assert
            builder.Mock.Verify(proxy => proxy.SetBreakpointByMask("kernel32", "createprocess*"), Times.Once);
            builder.Mock.Verify(proxy => proxy.SetBreakpointByMask("user32", "*"), Times.Once);
            builder.Mock.Verify(proxy => proxy.SetBreakpointByMask("mycustommod", "myfancyfunction"), Times.Once);

            builder.Mock.Verify(proxy => proxy.SetReadAccessBreakpoint(0x8, 0x100), Times.Once);
            builder.Mock.Verify(proxy => proxy.SetReadAccessBreakpoint(0x4, 0x300), Times.Once);
            builder.Mock.Verify(proxy => proxy.SetWriteAccessBreakpoint(0x8, 0x200), Times.Once);
            builder.Mock.Verify(proxy => proxy.SetWriteAccessBreakpoint(0x4, 0x300), Times.Once);
        }

        [Fact]
        public void Upsert_Frames_From_Breaks()
        {
            var dbg = new DebugEngineProxyBuilder();
            var tt = new TimeTravelFacadeBuilder(dbg);
            var sc = new ServerClientBuilder();

            dbg.WithRunUntilBreak();
            var count = 0;
            dbg.SetRunUntilBreakCallback(() =>
            {
                if (count++ > 0)
                    tt.AdvanceToNextPosition();
            });
            var dbgEngProxy = dbg.Build();
            var timeTravelFacade = tt.Build();
            var serverClient = sc.Build();

            dbg.CurrentThreadId = MockFrames.SingleThreaded0.First().ThreadId;
            tt.WithFrames(MockFrames.SingleThreaded0);
            sc.WithUpsertFrames(() => { });

            var indexMethod = new IndexMethod
            {
                DebugEngineProxy = dbgEngProxy,
                TimeTravelFacade = timeTravelFacade,
                ServerClient = serverClient
            };

            indexMethod.ProcessInternal(new Position(0, 0), MockFrames.SingleThreaded0.Max(x => x.Position));
            sc.Mock.Verify(client =>
                client.UpsertFrames(
                    It.Is<IEnumerable<Frame>>(frames => frames.SequenceEqual(MockFrames.SingleThreaded0))));
        }
    }
}