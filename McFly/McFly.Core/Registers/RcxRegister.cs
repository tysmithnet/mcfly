namespace McFly.Core.Registers
{
    public class RcxRegister : Register
    {
        public override string Name { get; } = "rcx";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 1;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}