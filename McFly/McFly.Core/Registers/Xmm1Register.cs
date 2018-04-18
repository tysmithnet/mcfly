namespace McFly.Core.Registers
{
    public class Xmm1Register : Register
    {
        public override string Name { get; } = "xmm1";
        public override int NumBits { get; } = 128;
        public override int? X64Index { get; } = 51;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 66;
        public override int? X86NumBits { get; } = 128;
    }
}