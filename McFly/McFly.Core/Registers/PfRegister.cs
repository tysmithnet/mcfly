namespace McFly.Core.Registers
{
    public class PfRegister : Register
    {
        public override string Name { get; } = "pf";
        public override int NumBits { get; } = 1;
        public override int? X64Index { get; } = 341;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 81;
        public override int? X86NumBits { get; } = 32;
    }
}