﻿namespace McFly.Core.Registers
{
    public class RipRegister : Register
    {
        public override string Name { get; } = "rip";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 16;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}