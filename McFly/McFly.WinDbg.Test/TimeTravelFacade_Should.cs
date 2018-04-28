using System.Collections.Generic;
using FluentAssertions;
using McFly.Core;
using McFly.Core.Registers;
using McFly.WinDbg.Test.Builders;
using Moq;
using Xunit;

namespace McFly.WinDbg.Test
{
    public class TimeTravelFacade_Should
    {
        [Fact]
        public void Get_The_Correct_Current_Position()
        {
            // arrange
            var builder = new DebugEngineProxyBuilder();
            builder.WithExecuteResult("!positions",
                @">Thread ID=0x7590 - Position: 35:0
 Thread ID=0x12A0 - Position: 246A:0
 Thread ID=0x6CDC - Position: 21D59:0
 Thread ID=0x2984 - Position: 21DFE:0
 Thread ID=0x3484 - Position: 21ECA:0
 Thread ID=0x60B4 - Position: 2414F:0
 Thread ID=0x1F54 - Position: 241DE:0
");
            var facade = new TimeTravelFacade {DebugEngineProxy = builder.Build()};

            // act
            var position = facade.GetCurrentPosition();
            var threadPosition = facade.GetCurrentPosition(0x60b4);

            // assert
            position.Should().Be(new Position(0x35, 0));
            threadPosition.Should().Be(new Position(0x2414f, 0));
        }

        [Fact]
        public void Get_The_Current_Frame_By_Thread_Id_Correctly()
        {
            // arrange
            var engBuilder = new DebugEngineProxyBuilder();
            engBuilder.WithExecuteResult("!positions", @">Thread ID=0x7590 - Position: 168CC:0
 Thread ID=0x12A0 - Position: 211F5:0
 Thread ID=0x6CDC - Position: 21D59:0
 Thread ID=0x2984 - Position: 21DFE:0
 Thread ID=0x3484 - Position: 21ECA:0
 Thread ID=0x60B4 - Position: 2414F:0
 Thread ID=0x1F54 - Position: 241DE:0
");
            engBuilder.With32Bit(false);
            engBuilder.WithThreadId(0x6CDC);
            var stackBuilder = new StackFacadeBuilder();
            var stackTrace = new StackTrace(new List<StackFrame>());
            stackBuilder.WithGetCurrentStackTrace(0x6CDC, stackTrace);

            var registerSet = new RegisterSet();
            var registerBuilder = new RegisterFacadeBuilder();
            registerBuilder.WithGetCurrentRegisterSet(registerSet);

            var disassemblyLine = new DisassemblyLine(0x00007ffa51315595, ByteArrayBuilder.StringToByteArray("4d3bd1"),
                "cmp", "r10,r9");
            var disBuilder = new DisassemblyFacadeBuilder();
            disBuilder.WithGetDisassemblyLines(0x6CDC, 1, new[] {disassemblyLine});
            var facade = new TimeTravelFacade
            {
                DebugEngineProxy = engBuilder.Build(),
                StackFacade = stackBuilder.Build(),
                RegisterFacade = registerBuilder.Build(),
                DisassemblyFacade = disBuilder.Build()
            };

            // act
            var frame = facade.GetCurrentFrame(0x6CDC);

            // assert
            frame.Position.Should().Be(new Position(0x21D59, 0));
            frame.DisassemblyLine.Should().Be(disassemblyLine);
            frame.RegisterSet.Should().Be(registerSet);
            frame.StackTrace.Should().Be(stackTrace);
            frame.ThreadId.Should().Be(0x6CDC);
        }

        [Fact]
        public void Get_The_Current_Frame_Correctly()
        {
            // arrange
            var engBuilder = new DebugEngineProxyBuilder();
            engBuilder.WithExecuteResult("!positions", @">Thread ID=0x7590 - Position: 168CC:0
 Thread ID=0x12A0 - Position: 211F5:0
 Thread ID=0x6CDC - Position: 21D59:0
 Thread ID=0x2984 - Position: 21DFE:0
 Thread ID=0x3484 - Position: 21ECA:0
 Thread ID=0x60B4 - Position: 2414F:0
 Thread ID=0x1F54 - Position: 241DE:0
");
            engBuilder.With32Bit(false);
            engBuilder.WithThreadId(0x7590);
            var stackBuilder = new StackFacadeBuilder();
            var stackTrace = new StackTrace(new List<StackFrame>());
            stackBuilder.WithGetCurrentStackTrace(stackTrace);

            var registerSet = new RegisterSet();
            var registerBuilder = new RegisterFacadeBuilder();
            registerBuilder.WithGetCurrentRegisterSet(Register.All, registerSet);

            var disassemblyLine = new DisassemblyLine(0x00007ffa51315595, ByteArrayBuilder.StringToByteArray("4d3bd1"),
                "cmp", "r10,r9");
            var disBuilder = new DisassemblyFacadeBuilder();
            disBuilder.WithGetDisassemblyLines(1, new[] {disassemblyLine});
            var facade = new TimeTravelFacade
            {
                DebugEngineProxy = engBuilder.Build(),
                StackFacade = stackBuilder.Build(),
                RegisterFacade = registerBuilder.Build(),
                DisassemblyFacade = disBuilder.Build()
            };

            // act
            var frame = facade.GetCurrentFrame();

            // assert
            frame.Position.Should().Be(new Position(0x168CC, 0));
            frame.DisassemblyLine.Should().Be(disassemblyLine);
            frame.RegisterSet.Should().Be(registerSet);
            frame.StackTrace.Should().Be(stackTrace);
            frame.ThreadId.Should().Be(0x7590);
        }

        [Fact]
        public void Get_The_Ending_Position()
        {
            // arrange
            var builder = new DebugEngineProxyBuilder();
            builder.WithExecuteResult("!tt 100",
                @"Setting position to the end of the trace
Setting position: 2D164:0
ModLoad: 00007ffa`4cc00000 00007ffa`4cc95000   C:\WINDOWS\system32\uxtheme.dll
ModLoad: 00007ffa`4cec0000 00007ffa`4ceea000   C:\WINDOWS\SYSTEM32\dwmapi.dll
ModLoad: 00007ffa`4fc30000 00007ffa`4fd97000   C:\WINDOWS\System32\MSCTF.dll
ModLoad: 00007ffa`51a80000 00007ffa`51b1e000   C:\WINDOWS\System32\clbcatq.dll
ModLoad: 00007ffa`4d750000 00007ffa`4d781000   C:\WINDOWS\SYSTEM32\ntmarta.dll
ModLoad: 00007ffa`4c1e0000 00007ffa`4c2bc000   C:\WINDOWS\System32\CoreMessaging.dll
ModLoad: 00007ffa`49f70000 00007ffa`4a0a6000   C:\WINDOWS\SYSTEM32\wintypes.dll
ModLoad: 00007ffa`48270000 00007ffa`4855e000   C:\WINDOWS\System32\CoreUIComponents.dll
ModLoad: 00007ffa`33e40000 00007ffa`33ed8000   C:\WINDOWS\System32\TextInputFramework.dll
(9b04.7590): Break instruction exception - code 80000003 (first/second chance not available)
Time Travel Position: 2D164:0
ntdll!NtTerminateProcess+0x12:
00007ffa`523603f2 0f05            syscall");
            var facade = new TimeTravelFacade {DebugEngineProxy = builder.Build()};

            // act
            var position = facade.GetEndingPosition();

            // assert
            position.Should().Be(new Position(0x2D164, 0));
        }

        [Fact]
        public void Get_The_Starting_Position()
        {
            // arrange
            var builder = new DebugEngineProxyBuilder();
            builder.WithExecuteResult("!tt 0",
                @"Setting position to the beginning of the trace
Setting position: 35:0
(9b04.7590): Break instruction exception - code 80000003 (first/second chance not available)
Time Travel Position: 35:0
ntdll!NtSetInformationWorkerFactory+0x14:
00007ffa`52363104 c3              ret");
            var facade = new TimeTravelFacade {DebugEngineProxy = builder.Build()};

            // act
            var position = facade.GetStartingPosition();

            // assert
            position.Should().Be(new Position(0x35, 0));
        }

        [Fact]
        public void Set_The_Position_Correctly()
        {
            // arrange
            var facade = new TimeTravelFacade();
            var position = new Position(0, 0);
            var builder = new DebugEngineProxyBuilder();
            facade.DebugEngineProxy = builder.Build();

            // act
            facade.SetPosition(position);

            // assert
            builder.Mock.Verify(proxy => proxy.Execute("!tt 0:0"), Times.Once);
        }
    }
}