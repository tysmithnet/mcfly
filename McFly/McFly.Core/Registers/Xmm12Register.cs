namespace McFly.Core.Registers
{
    public class Xmm12Register : Register
    {
        public override string Name { get; } = "xmm12";
        public override int NumBits { get; } = 128;
        public override int? X64Index { get; } = 62;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}