namespace McFly.Core.Registers
{
    public class R9Register : Register
    {
        public override string Name { get; } = "r9";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 9;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}