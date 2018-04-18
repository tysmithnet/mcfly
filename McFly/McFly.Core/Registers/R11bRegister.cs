namespace McFly.Core.Registers
{
    public class R11bRegister : Register
    {
        public override string Name { get; } = "r11b";
        public override int NumBits { get; } = 8;
        public override int? X64Index { get; } = 324;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}