namespace McFly.Core.Registers
{
    public class FlRegister : Register
    {
        public override string Name { get; } = "fl";
        public override int NumBits { get; } = 16;
        public override int? X64Index { get; } = 312;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 30;
        public override int? X86NumBits { get; } = 32;
    }
}