namespace McFly.Core.Registers
{
    public class Xmm11lRegister : Register
    {
        public override string Name { get; } = "xmm11l";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 141;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}