namespace McFly.Core.Registers
{
    public class OfRegister : Register
    {
        public override string Name { get; } = "of";
        public override int NumBits { get; } = 1;
        public override int? X64Index { get; } = 334;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 74;
        public override int? X86NumBits { get; } = 32;
    }
}