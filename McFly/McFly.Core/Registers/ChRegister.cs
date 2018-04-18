namespace McFly.Core.Registers
{
    public class ChRegister : Register
    {
        public override string Name { get; } = "ch";
        public override int NumBits { get; } = 8;
        public override int? X64Index { get; } = 330;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 38;
        public override int? X86NumBits { get; } = 32;
    }
}