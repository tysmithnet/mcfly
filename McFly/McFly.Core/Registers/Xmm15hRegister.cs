namespace McFly.Core.Registers
{
    public class Xmm15hRegister : Register
    {
        public override string Name { get; } = "xmm15h";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 161;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}