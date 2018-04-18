﻿namespace McFly.Core.Registers
{
    public class Ymm6lRegister : Register
    {
        public override string Name { get; } = "ymm6l";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 248;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 147;
        public override int? X86NumBits { get; } = 128;
    }
}