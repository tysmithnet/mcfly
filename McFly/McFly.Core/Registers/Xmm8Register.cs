namespace McFly.Core.Registers
{
    public class Xmm8Register : Register
    {
        public override string Name { get; } = "xmm8";
        public override int NumBits { get; } = 128;
        public override int? X64Index { get; } = 58;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}