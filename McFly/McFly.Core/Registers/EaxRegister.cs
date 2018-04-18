namespace McFly.Core.Registers
{
    public class EaxRegister : Register
    {
        public override string Name { get; } = "eax";
        public override int NumBits { get; } = 32;
        public override int? X64Index { get; } = 278;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 9;
        public override int? X86NumBits { get; } = 32;
    }
}