namespace McFly.Core.Registers
{
    public class Xmm5Register : Register
    {
        public override string Name { get; } = "xmm5";
        public override int NumBits { get; } = 128;
        public override int? X64Index { get; } = 55;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 70;
        public override int? X86NumBits { get; } = 128;
    }
}