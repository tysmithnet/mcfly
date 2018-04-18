namespace McFly.Core.Registers
{
    public class MxcsrRegister : Register
    {
        public override string Name { get; } = "mxcsr";
        public override int NumBits { get; } = 32;
        public override int? X64Index { get; } = 49;
        public override int? X64NumBits { get; } = 32;
        public override int? X86Index { get; } = 64;
        public override int? X86NumBits { get; } = 32;
    }
}