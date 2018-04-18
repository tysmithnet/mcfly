namespace McFly.Core.Registers
{
    public class EdxRegister : Register
    {
        public override string Name { get; } = "edx";
        public override int NumBits { get; } = 32;
        public override int? X64Index { get; } = 280;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 7;
        public override int? X86NumBits { get; } = 32;
    }
}