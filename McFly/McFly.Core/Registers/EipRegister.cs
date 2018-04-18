namespace McFly.Core.Registers
{
    public class EipRegister : Register
    {
        public override string Name { get; } = "eip";
        public override int NumBits { get; } = 32;
        public override int? X64Index { get; } = 294;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 11;
        public override int? X86NumBits { get; } = 32;
    }
}