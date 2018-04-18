namespace McFly.Core.Registers
{
    public class Mm0Register : Register
    {
        public override string Name { get; } = "mm0";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 41;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 56;
        public override int? X86NumBits { get; } = 64;
    }
}