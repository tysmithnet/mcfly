namespace McFly.Core.Registers
{
    public class Mm7Register : Register
    {
        public override string Name { get; } = "mm7";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 48;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 63;
        public override int? X86NumBits { get; } = 64;
    }
}