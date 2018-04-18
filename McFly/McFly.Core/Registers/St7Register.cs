namespace McFly.Core.Registers
{
    public class St7Register : Register
    {
        public override string Name { get; } = "st7";
        public override int NumBits { get; } = 80;
        public override int? X64Index { get; } = 40;
        public override int? X64NumBits { get; } = 80;
        public override int? X86Index { get; } = 55;
        public override int? X86NumBits { get; } = 80;
    }
}