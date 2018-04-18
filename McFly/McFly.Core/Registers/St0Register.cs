namespace McFly.Core.Registers
{
    public class St0Register : Register
    {
        public override string Name { get; } = "st0";
        public override int NumBits { get; } = 80;
        public override int? X64Index { get; } = 33;
        public override int? X64NumBits { get; } = 80;
        public override int? X86Index { get; } = 48;
        public override int? X86NumBits { get; } = 80;
    }
}