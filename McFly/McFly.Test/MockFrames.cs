using McFly.Core;
using McFly.Core.Registers;

namespace McFly.Test
{
    public static class MockFrames
    {
        public static Frame[] SingleThreaded0 = // todo: more accurate name
        {
            new Frame
            {
                Position = new Position(0x35, 0),
                RegisterSet = new RegisterSet
                {
                    Rax = 0x1,
                    Rbx = 0x1
                },
                StackTrace = new StackTrace(new[]
                {
                    new StackFrame(0x123, 0x789, "mod0", "helloworld", 0x35),
                    new StackFrame(0x123, 0x790, "mod0", "helloworld", 0x36),
                    new StackFrame(0x123, 0x791, "mod0", "helloworld", 0x37),
                    new StackFrame(0x123, 0x792, "mod0", "helloworld", 0x38),
                    new StackFrame(0x123, 0x797, "mod0", "helloworld", 0x45)
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
                StackTrace = new StackTrace(new[]
                {
                    new StackFrame(0x123, 0x789, "mod0", "helloworld", 0x35),
                    new StackFrame(0x123, 0x790, "mod0", "helloworld", 0x36),
                    new StackFrame(0x123, 0x125, "mod1", "thing", 0x15),
                    new StackFrame(0x123, 0x123, "mod1", "thing", 0x35),
                    new StackFrame(0x123, 0x166, "mod1", "otherthing", 0x55)
                }),
                DisassemblyLine = new DisassemblyLine(0x123, new byte[] {0x00, 0x11}, "xor", "word ptr [r14+132h],r8w"),
                ThreadId = 1
            }
        };
    }
}