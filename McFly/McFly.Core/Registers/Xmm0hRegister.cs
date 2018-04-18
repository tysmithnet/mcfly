namespace McFly.Core.Registers
{
    public class Xmm0hRegister : Register
    {
        public override string Name { get; } = "xmm0h";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 146;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 93;
        public override int? X86NumBits { get; } = 64;
    }
}