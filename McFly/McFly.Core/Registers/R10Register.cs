namespace McFly.Core.Registers
{
    public class R10Register : Register
    {
        public override string Name { get; } = "r10";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 10;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}