namespace McFly.Core.Registers
{
    public class ClRegister : Register
    {
        public override string Name { get; } = "cl";
        public override int NumBits { get; } = 8;
        public override int? X64Index { get; } = 314;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 34;
        public override int? X86NumBits { get; } = 32;
    }
}