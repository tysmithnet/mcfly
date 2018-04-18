namespace McFly.Core.Registers
{
    public class CfRegister : Register
    {
        public override string Name { get; } = "cf";
        public override int NumBits { get; } = 1;
        public override int? X64Index { get; } = 342;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 82;
        public override int? X86NumBits { get; } = 32;
    }
}