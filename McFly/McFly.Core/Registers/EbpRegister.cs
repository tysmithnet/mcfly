﻿namespace McFly.Core.Registers
{
    public class EbpRegister : Register
    {
        public override string Name { get; } = "ebp";
        public override int NumBits { get; } = 32;
        public override int? X64Index { get; } = 283;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 10;
        public override int? X86NumBits { get; } = 32;
    }
}