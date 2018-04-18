namespace McFly.Core.Registers
{
    public class Mm2Register : Register
    {
        public override string Name { get; } = "mm2";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 43;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 58;
        public override int? X86NumBits { get; } = 64;
    }
}