using System;
using FluentAssertions;
using McFly.Core;
using McFly.WinDbg;
using McFly.WinDbg.Test.Builders;
using Xunit;

namespace McFly.WinDbg.Test
{
    public class DisassemblyFacade_Should
    {

        // todo: add this
        // ntdll!_LdrpInitialize+0x39:
        // 00007ffb`98873189 f00fb13527920e00 lock cmpxchg dword ptr[ntdll!LdrpProcessInitialized(00007ffb`9895c3b8)],esi ds:00007ffb`9895c3b8=00000002
        [Fact]
        public void Disassemble_The_Correct_Number_Of_Instructions()
        {
            // arrange
            var builder = new DebugEngineProxyBuilder();
            builder.With32Bit(false);
            builder.WithExecuteResult("u rip L2", @"KERNEL32!GetTimeFormatWWorker+0xc43:
00007ffa`51315543 6645898632010000 mov     word ptr [r14+132h],r8w
00007ffa`5131554b 498d8630010000  lea     rax,[r14+130h]
");
            var facade = new DisassemblyFacade {DebugEngineProxy = builder.Build()};
            var expected = new[]
            {
                new DisassemblyLine(0x00007ffa51315543, ByteArrayBuilder.StringToByteArray("6645898632010000"), "mov",
                    "word ptr [r14+132h],r8w"),
                new DisassemblyLine(0x00007ffa5131554b, ByteArrayBuilder.StringToByteArray("498d8630010000"), "lea",
                    "rax,[r14+130h]")
            };

            // act
            var lines = facade.GetDisassemblyLines(2);

            // assert
            lines.Should().Equal(expected);
        }

        [Fact]
        public void Not_Allow_Negative_Values()
        {
            // arrange
            var facade = new DisassemblyFacade();
            Action shouldThrow = () => facade.GetDisassemblyLines(1, -1);

            // act
            // assert
            shouldThrow.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}