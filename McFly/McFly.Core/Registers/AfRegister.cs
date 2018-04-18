namespace McFly.Core.Registers
{
    public class AfRegister : Register
    {
        public override string Name { get; } = "af";
        public override int NumBits { get; } = 1;
        public override int? X64Index { get; } = 340;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 80;
        public override int? X86NumBits { get; } = 32;
    }
}