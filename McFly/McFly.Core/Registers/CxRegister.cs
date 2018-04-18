namespace McFly.Core.Registers
{
    public class CxRegister : Register
    {
        public override string Name { get; } = "cx";
        public override int NumBits { get; } = 16;
        public override int? X64Index { get; } = 296;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 26;
        public override int? X86NumBits { get; } = 32;
    }
}