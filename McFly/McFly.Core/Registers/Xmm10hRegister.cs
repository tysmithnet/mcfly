namespace McFly.Core.Registers
{
    public class Xmm10hRegister : Register
    {
        public override string Name { get; } = "xmm10h";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 156;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}