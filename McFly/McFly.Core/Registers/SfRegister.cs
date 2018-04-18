﻿namespace McFly.Core.Registers
{
    public class SfRegister : Register
    {
        public override string Name { get; } = "sf";
        public override int NumBits { get; } = 1;
        public override int? X64Index { get; } = 338;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 78;
        public override int? X86NumBits { get; } = 32;
    }
}