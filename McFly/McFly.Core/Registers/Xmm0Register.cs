namespace McFly.Core.Registers
{
    public class Xmm0Register : Register
    {
        public override string Name { get; } = "xmm0";
        public override int NumBits { get; } = 128;
        public override int? X64Index { get; } = 50;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 65;
        public override int? X86NumBits { get; } = 128;
    }
}