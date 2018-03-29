using FluentAssertions;
using McFly.Core;
using Xunit;

namespace McFly.Tests
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
    }
}