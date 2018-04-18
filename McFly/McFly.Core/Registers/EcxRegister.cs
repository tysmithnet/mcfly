namespace McFly.Core.Registers
{
    public class EcxRegister : Register
    {
        public override string Name { get; } = "ecx";
        public override int NumBits { get; } = 32;
        public override int? X64Index { get; } = 279;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 8;
        public override int? X86NumBits { get; } = 32;
    }
}