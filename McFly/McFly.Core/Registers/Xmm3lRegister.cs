namespace McFly.Core.Registers
{
    public class Xmm3lRegister : Register
    {
        public override string Name { get; } = "xmm3l";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 133;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 88;
        public override int? X86NumBits { get; } = 64;
    }
}