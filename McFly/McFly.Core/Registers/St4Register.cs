namespace McFly.Core.Registers
{
    public class St4Register : Register
    {
        public override string Name { get; } = "st4";
        public override int NumBits { get; } = 80;
        public override int? X64Index { get; } = 37;
        public override int? X64NumBits { get; } = 80;
        public override int? X86Index { get; } = 52;
        public override int? X86NumBits { get; } = 80;
    }
}