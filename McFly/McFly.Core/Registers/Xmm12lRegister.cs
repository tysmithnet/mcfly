namespace McFly.Core.Registers
{
    public class Xmm12lRegister : Register
    {
        public override string Name { get; } = "xmm12l";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 142;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}