using FluentAssertions;
using McFly.Core;
using McFly.WinDbg.Test.Builders;
using Xunit;

namespace McFly.WinDbg.Test
{
    public class StackFacade_Should
    {
        [Fact]
        public void Get_The_Current_StackTrace_Correctly()
        {
            // arrange
            var builder = new DebugEngineProxyBuilder();
            builder.WithExecuteResult("k", @"Child-SP          RetAddr           Call Site
00000000`0014d180 00007ffa`513150ed KERNEL32!GetTimeFormatWWorker+0xc43
00000000`0014d1d0 00007ffa`513138e6 KERNEL32!GetTimeFormatWWorker+0x7ed
00000000`0014ff90 00000000`00000000 ntdll!RtlUserThreadStart+0x21");
            builder.WithExecuteResult("~~[7590] k", @"Child-SP          RetAddr           Call Site
00000000`0014d180 00007ffa`513150ed KERNEL32!GetTimeFormatWWorker+0xc43
00000000`0014d1d0 00007ffa`513138e6 KERNEL32!GetTimeFormatWWorker+0x7ed
00000000`0014ff90 00000000`00000000 ntdll!RtlUserThreadStart+0x21");

            builder.WithThreadId(0x7590);
            var stackFacade = new StackFacade {DebugEngineProxy = builder.Build()};

            // act
            var stackTrace = stackFacade.GetCurrentStackTrace();
            var stackTrace2 = stackFacade.GetCurrentStackTrace(0x7590);

            // assert
            stackTrace.Should().Be(new StackTrace(new[]
            {
                new StackFrame(0x000000000014d180, 0x00007ffa513150ed, "KERNEL32", "GetTimeFormatWWorker", 0xc43),
                new StackFrame(0x000000000014d1d0, 0x00007ffa513138e6, "KERNEL32", "GetTimeFormatWWorker", 0x7ed),
                new StackFrame(0x000000000014ff90, 0x0000000000000000, "ntdll", "RtlUserThreadStart", 0x21)
            }));
            stackTrace2.Should().Be(new StackTrace(new[]
            {
                new StackFrame(0x000000000014d180, 0x00007ffa513150ed, "KERNEL32", "GetTimeFormatWWorker", 0xc43),
                new StackFrame(0x000000000014d1d0, 0x00007ffa513138e6, "KERNEL32", "GetTimeFormatWWorker", 0x7ed),
                new StackFrame(0x000000000014ff90, 0x0000000000000000, "ntdll", "RtlUserThreadStart", 0x21)
            }));
        }

        [Fact]
        public void Get_Stack_Frames_Correctly()
        {
            // arrange
            var stackTrace = @"ChildEBP RetAddr  
WARNING: Frame IP not in any known module. Following frames may be wrong.
004ffc7c 77c1ea4c 0x75607000
004ffd58 77aa3bd3 ntdll!ZwTerminateProcess+0xc
004ffe04 00121c7d McFly_Samples_Console_HelloWorld+0x11df8";

            var expected = new[]
            {
                new StackFrame(0x004ffc7c, 0x77c1ea4c, null, null, 0x75607000),
                new StackFrame(0x004ffd58, 0x77aa3bd3, "ntdll", "ZwTerminateProcess", 0xc),
                new StackFrame(0x004ffe04, 0x00121c7d, "McFly_Samples_Console_HelloWorld", null, 0x11df8),

            };

            // act                                                                           
            // assert
            StackFacade.ExtractStackFrames(stackTrace).Should().Equal(expected);
        }
    }
}