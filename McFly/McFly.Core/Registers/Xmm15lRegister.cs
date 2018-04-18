namespace McFly.Core.Registers
{
    public class Xmm15lRegister : Register
    {
        public override string Name { get; } = "xmm15l";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 145;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}