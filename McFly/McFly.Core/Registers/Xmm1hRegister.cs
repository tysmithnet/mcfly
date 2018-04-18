namespace McFly.Core.Registers
{
    public class Xmm1hRegister : Register
    {
        public override string Name { get; } = "xmm1h";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 147;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 94;
        public override int? X86NumBits { get; } = 64;
    }
}