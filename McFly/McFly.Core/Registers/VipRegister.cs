﻿namespace McFly.Core.Registers
{
    public class VipRegister : Register
    {
        public override string Name { get; } = "vip";
        public override int NumBits { get; } = 1;
        public override int? X64Index { get; } = 343;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 83;
        public override int? X86NumBits { get; } = 32;
    }
}