namespace McFly.Core.Registers
{
    public class Mm3Register : Register
    {
        public override string Name { get; } = "mm3";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 44;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 59;
        public override int? X86NumBits { get; } = 64;
    }
}