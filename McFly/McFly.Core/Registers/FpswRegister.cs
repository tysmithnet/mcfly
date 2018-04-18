namespace McFly.Core.Registers
{
    public class FpswRegister : Register
    {
        public override string Name { get; } = "fpsw";
        public override int NumBits { get; } = 16;
        public override int? X64Index { get; } = 31;
        public override int? X64NumBits { get; } = 16;
        public override int? X86Index { get; } = 41;
        public override int? X86NumBits { get; } = 32;
    }
}