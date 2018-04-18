namespace McFly.Core.Registers
{
    public class Xmm14lRegister : Register
    {
        public override string Name { get; } = "xmm14l";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 144;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}