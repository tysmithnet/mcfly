namespace McFly.Core.Registers
{
    public class SpRegister : Register
    {
        public override string Name { get; } = "sp";
        public override int NumBits { get; } = 16;
        public override int? X64Index { get; } = 299;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 31;
        public override int? X86NumBits { get; } = 32;
    }
}