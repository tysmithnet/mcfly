namespace McFly.Core.Registers
{
    public class FpcwRegister : Register
    {
        public override string Name { get; } = "fpcw";
        public override int NumBits { get; } = 16;
        public override int? X64Index { get; } = 30;
        public override int? X64NumBits { get; } = 16;
        public override int? X86Index { get; } = 40;
        public override int? X86NumBits { get; } = 32;
    }
}