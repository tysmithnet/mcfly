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
        public void Set_Breakpoints_If_They_Are_Provided_In_The_Options()
        {
            // arrange
            var indexMethod = new IndexMethod();
            var indexOptions = new IndexOptions()
            {
                AccessBreakpoints = new []{"r8:100", "w10:200", "rw10:300"},
                BreakpointMasks = new[] {"kernel32!createprocess*", "user32!*", "mycustommod!myfancyfunction"}
            };
            var builder = new BreakpointFacadeBuilder();
            indexMethod.BreakpointFacade = builder.Build();

            // act
            indexMethod.SetBreakpoints(indexOptions);
            
            // assert
            builder.Mock.Verify(proxy => proxy.SetBreakpointByMask("kernel32!createprocess*"), Times.Once);
            builder.Mock.Verify(proxy => proxy.SetBreakpointByMask("user32!*"), Times.Once);
            builder.Mock.Verify(proxy => proxy.SetBreakpointByMask("mycustommod!myfancyfunction"), Times.Once);

            builder.Mock.Verify(proxy => proxy.SetReadAccessBreakpoint(0x8, 0x100), Times.Once);
            builder.Mock.Verify(proxy => proxy.SetReadAccessBreakpoint(0x10, 0x300), Times.Once);
            builder.Mock.Verify(proxy => proxy.SetWriteAccessBreakpoint(0x10, 0x200), Times.Once);
            builder.Mock.Verify(proxy => proxy.SetWriteAccessBreakpoint(0x10, 0x300), Times.Once);
        }

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
            var builder = new DbgEngProxyBuilder();
            builder.WithExecuteResult("!peb", @"PEB at 00000000003b9000
    InheritedAddressSpace:    No
    ReadImageFileExecOptions: No
    BeingDebugged:            No
    ...
    ImageBaseAddress:         0000000140000000        _NT_SYMBOL_PATH=SRV*c:\symbols*http://msdl.microsoft.com/download/symbols");
            var proxy = builder.Build();

            // Act
            var indexMethod = new IndexMethod();
            indexMethod.DbgEngProxy = builder.Build();
            var is32 = indexMethod.Is32Bit();

            // Assert
            is32.Should().BeFalse("00000000003b9000 is 16 characters and thus 64bit");
        }

        [Fact]
        public void Identify_Correct_Starting_Position()
        {
            // Arrange                             
            var options = new IndexOptions
            {
                Start = "35:1"
            };                                      

            var dbg = new DbgEngProxyBuilder();
            var indexMethod = new IndexMethod();
            indexMethod.DbgEngProxy = dbg.Build();
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
        public void Identify_Correct_Ending_Position()
        {
            // Arrange                             
            var options = new IndexOptions
            {
                End = "35:1"
            };

            var dbg = new DbgEngProxyBuilder();
            var indexMethod = new IndexMethod();
            indexMethod.DbgEngProxy = dbg.Build();
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
        public void Upsert_Frames_From_Breaks()
        {
            var dbg = new DbgEngProxyBuilder();
            var tt = new TimeTravelFacadeBuilder(dbg);
            var sc = new ServerClientBuilder();
            
            dbg.WithRunUntilBreak();
            int count = 0;
            dbg.SetRunUntilBreakCallback(() =>
            {
                if(count++ > 0)
                    tt.AdvanceToNextPosition();
            });
            var dbgEngProxy = dbg.Build();
            var timeTravelFacade = tt.Build();
            var serverClient = sc.Build();

            dbg.CurrentThreadId = SingleThreaded0.First().ThreadId;
            tt.WithFrames(SingleThreaded0);
            sc.WithUpsertFrames(() =>
            {

            });

            var indexMethod = new IndexMethod
            {
                DbgEngProxy = dbgEngProxy,
                TimeTravelFacade = timeTravelFacade,
                ServerClient = serverClient
            };

            indexMethod.ProcessInternal(new Position(0,0), SingleThreaded0.Max(x => x.Position));
            sc.Mock.Verify(client => client.UpsertFrames(It.Is<IEnumerable<Frame>>(frames => frames.SequenceEqual(SingleThreaded0))));
        }
                  
        private static Frame[] SingleThreaded0 = // todo: more accurate name
        {
            new Frame
            {
                Position = new Position(0x35, 0),
                RegisterSet = new RegisterSet
                {
                    Rax = 0x1,
                    Rbx = 0x1
                },
                StackTrace = new StackTrace (new StackFrame[]
                {
                    new StackFrame(0x123, 0x789, "mod0", "helloworld", 0x35),
                    new StackFrame(0x123, 0x790, "mod0", "helloworld", 0x36),
                    new StackFrame(0x123, 0x791, "mod0", "helloworld", 0x37),
                    new StackFrame(0x123, 0x792, "mod0", "helloworld", 0x38),
                    new StackFrame(0x123, 0x797, "mod0", "helloworld", 0x45),

                }),
                DisassemblyLine = new DisassemblyLine(0x123, new byte[] {0x00, 0x11}, "mov", "[rax],1"),
                ThreadId = 1
            },
            new Frame
            {
                Position = new Position(0x135, 0),
                RegisterSet = new RegisterSet
                {
                    Rax = 0x1,
                    Rbx = 0x1
                },
                StackTrace = new StackTrace (new StackFrame[]
                {
                    new StackFrame(0x123, 0x789, "mod0", "helloworld", 0x35),
                    new StackFrame(0x123, 0x790, "mod0", "helloworld", 0x36),
                    new StackFrame(0x123, 0x125, "mod1", "thing", 0x15),
                    new StackFrame(0x123, 0x123, "mod1", "thing", 0x35),
                    new StackFrame(0x123, 0x166, "mod1", "otherthing", 0x55),

                }),
                DisassemblyLine = new DisassemblyLine(0x123, new byte[] {0x00, 0x11}, "xor", "word ptr [r14+132h],r8w"),
                ThreadId = 1
            },
        };
    }
}


