﻿namespace McFly.Core.Registers
{
    public class Ymm4Register : Register
    {
        public override string Name { get; } = "ymm4";
        public override int NumBits { get; } = 256;
        public override int? X64Index { get; } = 166;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 137;
        public override int? X86NumBits { get; } = 128;
    }
}