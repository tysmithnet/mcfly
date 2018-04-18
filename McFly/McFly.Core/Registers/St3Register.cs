namespace McFly.Core.Registers
{
    public class St3Register : Register
    {
        public override string Name { get; } = "st3";
        public override int NumBits { get; } = 80;
        public override int? X64Index { get; } = 36;
        public override int? X64NumBits { get; } = 80;
        public override int? X86Index { get; } = 51;
        public override int? X86NumBits { get; } = 80;
    }
}