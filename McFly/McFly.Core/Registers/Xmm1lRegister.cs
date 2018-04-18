namespace McFly.Core.Registers
{
    public class Xmm1lRegister : Register
    {
        public override string Name { get; } = "xmm1l";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 131;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 86;
        public override int? X86NumBits { get; } = 64;
    }
}