﻿namespace McFly.Core.Registers
{
    public class R13wRegister : Register
    {
        public override string Name { get; } = "r13w";
        public override int NumBits { get; } = 16;
        public override int? X64Index { get; } = 308;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}