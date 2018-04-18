namespace McFly.Core.Registers
{
    public class R11Register : Register
    {
        public override string Name { get; } = "r11";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 11;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}