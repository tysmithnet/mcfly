namespace McFly.Core.Registers
{
    public class Xmm10Register : Register
    {
        public override string Name { get; } = "xmm10";
        public override int NumBits { get; } = 128;
        public override int? X64Index { get; } = 60;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}