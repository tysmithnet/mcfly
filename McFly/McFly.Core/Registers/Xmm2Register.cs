namespace McFly.Core.Registers
{
    public class Xmm2Register : Register
    {
        public override string Name { get; } = "xmm2";
        public override int NumBits { get; } = 128;
        public override int? X64Index { get; } = 52;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 67;
        public override int? X86NumBits { get; } = 128;
    }
}