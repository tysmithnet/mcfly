namespace McFly.Core.Registers
{
    public class Xmm2lRegister : Register
    {
        public override string Name { get; } = "xmm2l";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 132;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 87;
        public override int? X86NumBits { get; } = 64;
    }
}