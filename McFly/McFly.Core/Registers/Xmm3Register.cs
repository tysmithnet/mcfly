namespace McFly.Core.Registers
{
    public class Xmm3Register : Register
    {
        public override string Name { get; } = "xmm3";
        public override int NumBits { get; } = 128;
        public override int? X64Index { get; } = 53;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 68;
        public override int? X86NumBits { get; } = 128;
    }
}