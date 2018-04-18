namespace McFly.Core.Registers
{
    public class ZfRegister : Register
    {
        public override string Name { get; } = "zf";
        public override int NumBits { get; } = 1;
        public override int? X64Index { get; } = 339;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 79;
        public override int? X86NumBits { get; } = 32;
    }
}