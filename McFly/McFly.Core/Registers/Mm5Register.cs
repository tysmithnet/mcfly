namespace McFly.Core.Registers
{
    public class Mm5Register : Register
    {
        public override string Name { get; } = "mm5";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 46;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 61;
        public override int? X86NumBits { get; } = 64;
    }
}