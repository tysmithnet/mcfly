namespace McFly.Core.Registers
{
    public class SsRegister : Register
    {
        public override string Name { get; } = "ss";
        public override int NumBits { get; } = 16;
        public override int? X64Index { get; } = 23;
        public override int? X64NumBits { get; } = 16;
        public override int? X86Index { get; } = 15;
        public override int? X86NumBits { get; } = 32;
    }
}