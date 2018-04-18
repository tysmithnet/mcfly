namespace McFly.Core.Registers
{
    public class Xmm8hRegister : Register
    {
        public override string Name { get; } = "xmm8h";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 154;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}