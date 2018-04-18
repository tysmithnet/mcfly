﻿namespace McFly.Core.Registers
{
    public class Xmm9lRegister : Register
    {
        public override string Name { get; } = "xmm9l";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 139;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}