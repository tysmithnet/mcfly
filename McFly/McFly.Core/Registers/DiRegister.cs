namespace McFly.Core.Registers
{
    public class DiRegister : Register
    {
        public override string Name { get; } = "di";
        public override int NumBits { get; } = 16;
        public override int? X64Index { get; } = 302;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 22;
        public override int? X86NumBits { get; } = 32;
    }
}