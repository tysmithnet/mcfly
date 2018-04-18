namespace McFly.Core.Registers
{
    public class GsRegister : Register
    {
        public override string Name { get; } = "gs";
        public override int NumBits { get; } = 16;
        public override int? X64Index { get; } = 22;
        public override int? X64NumBits { get; } = 16;
        public override int? X86Index { get; } = 0;
        public override int? X86NumBits { get; } = 32;
    }
}