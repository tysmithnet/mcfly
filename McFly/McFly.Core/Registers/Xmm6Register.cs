namespace McFly.Core.Registers
{
    public class Xmm6Register : Register
    {
        public override string Name { get; } = "xmm6";
        public override int NumBits { get; } = 128;
        public override int? X64Index { get; } = 56;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 71;
        public override int? X86NumBits { get; } = 128;
    }
}