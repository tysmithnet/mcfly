namespace McFly.Core.Registers
{
    public class Xmm14Register : Register
    {
        public override string Name { get; } = "xmm14";
        public override int NumBits { get; } = 128;
        public override int? X64Index { get; } = 64;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}