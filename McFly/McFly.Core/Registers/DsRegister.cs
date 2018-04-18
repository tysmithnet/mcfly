namespace McFly.Core.Registers
{
    public class DsRegister : Register
    {
        public override string Name { get; } = "ds";
        public override int NumBits { get; } = 16;
        public override int? X64Index { get; } = 19;
        public override int? X64NumBits { get; } = 16;
        public override int? X86Index { get; } = 3;
        public override int? X86NumBits { get; } = 32;
    }
}