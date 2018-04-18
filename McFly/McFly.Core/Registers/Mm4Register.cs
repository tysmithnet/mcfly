namespace McFly.Core.Registers
{
    public class Mm4Register : Register
    {
        public override string Name { get; } = "mm4";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 45;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 60;
        public override int? X86NumBits { get; } = 64;
    }
}