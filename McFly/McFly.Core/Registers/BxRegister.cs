namespace McFly.Core.Registers
{
    public class BxRegister : Register
    {
        public override string Name { get; } = "bx";
        public override int NumBits { get; } = 16;
        public override int? X64Index { get; } = 298;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 24;
        public override int? X86NumBits { get; } = 32;
    }
}