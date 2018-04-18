namespace McFly.Core.Registers
{
    public class EdiRegister : Register
    {
        public override string Name { get; } = "edi";
        public override int NumBits { get; } = 32;
        public override int? X64Index { get; } = 285;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 4;
        public override int? X86NumBits { get; } = 32;
    }
}