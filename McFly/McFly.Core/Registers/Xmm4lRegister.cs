﻿namespace McFly.Core.Registers
{
    public class Xmm4lRegister : Register
    {
        public override string Name { get; } = "xmm4l";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 134;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 89;
        public override int? X86NumBits { get; } = 64;
    }
}