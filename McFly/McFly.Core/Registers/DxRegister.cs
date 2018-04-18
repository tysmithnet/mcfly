namespace McFly.Core.Registers
{
    public class DxRegister : Register
    {
        public override string Name { get; } = "dx";
        public override int NumBits { get; } = 16;
        public override int? X64Index { get; } = 297;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 25;
        public override int? X86NumBits { get; } = 32;
    }
}