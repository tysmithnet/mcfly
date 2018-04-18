namespace McFly.Core.Registers
{
    public class Xmm3hRegister : Register
    {
        public override string Name { get; } = "xmm3h";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 149;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 96;
        public override int? X86NumBits { get; } = 64;
    }
}