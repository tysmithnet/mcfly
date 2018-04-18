namespace McFly.Core.Registers
{
    public class St6Register : Register
    {
        public override string Name { get; } = "st6";
        public override int NumBits { get; } = 80;
        public override int? X64Index { get; } = 39;
        public override int? X64NumBits { get; } = 80;
        public override int? X86Index { get; } = 54;
        public override int? X86NumBits { get; } = 80;
    }
}