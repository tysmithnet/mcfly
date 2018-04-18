namespace McFly.Core.Registers
{
    public class FptwRegister : Register
    {
        public override string Name { get; } = "fptw";
        public override int NumBits { get; } = 16;
        public override int? X64Index { get; } = 32;
        public override int? X64NumBits { get; } = 16;
        public override int? X86Index { get; } = 42;
        public override int? X86NumBits { get; } = 32;
    }
}