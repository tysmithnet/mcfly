namespace McFly.Core.Registers
{
    public class AhRegister : Register
    {
        public override string Name { get; } = "ah";
        public override int NumBits { get; } = 8;
        public override int? X64Index { get; } = 329;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 39;
        public override int? X86NumBits { get; } = 32;
    }
}