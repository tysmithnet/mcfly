namespace McFly.Core.Registers
{
    public class Xmm6hRegister : Register
    {
        public override string Name { get; } = "xmm6h";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 152;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 99;
        public override int? X86NumBits { get; } = 64;
    }
}