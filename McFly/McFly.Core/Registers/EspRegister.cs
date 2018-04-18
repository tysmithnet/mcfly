namespace McFly.Core.Registers
{
    public class EspRegister : Register
    {
        public override string Name { get; } = "esp";
        public override int NumBits { get; } = 32;
        public override int? X64Index { get; } = 282;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 14;
        public override int? X86NumBits { get; } = 32;
    }
}