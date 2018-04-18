namespace McFly.Core.Registers
{
    public class Mm6Register : Register
    {
        public override string Name { get; } = "mm6";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 47;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 62;
        public override int? X86NumBits { get; } = 64;
    }
}