namespace McFly.Core.Registers
{
    public class Mm1Register : Register
    {
        public override string Name { get; } = "mm1";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 42;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 57;
        public override int? X86NumBits { get; } = 64;
    }
}