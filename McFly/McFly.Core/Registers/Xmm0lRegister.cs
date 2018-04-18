namespace McFly.Core.Registers
{
    public class Xmm0lRegister : Register
    {
        public override string Name { get; } = "xmm0l";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 130;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 85;
        public override int? X86NumBits { get; } = 64;
    }
}