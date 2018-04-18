namespace McFly.Core.Registers
{
    public class R15bRegister : Register
    {
        public override string Name { get; } = "r15b";
        public override int NumBits { get; } = 8;
        public override int? X64Index { get; } = 328;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}