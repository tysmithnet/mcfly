namespace McFly.Core.Registers
{
    public class Xmm4Register : Register
    {
        public override string Name { get; } = "xmm4";
        public override int NumBits { get; } = 128;
        public override int? X64Index { get; } = 54;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 69;
        public override int? X86NumBits { get; } = 128;
    }
}