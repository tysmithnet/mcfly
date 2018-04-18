namespace McFly.Core.Registers
{
    public class DfRegister : Register
    {
        public override string Name { get; } = "df";
        public override int NumBits { get; } = 1;
        public override int? X64Index { get; } = 335;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 75;
        public override int? X86NumBits { get; } = 32;
    }
}