namespace McFly.Core.Registers
{
    public class EsRegister : Register
    {
        public override string Name { get; } = "es";
        public override int NumBits { get; } = 16;
        public override int? X64Index { get; } = 20;
        public override int? X64NumBits { get; } = 16;
        public override int? X86Index { get; } = 2;
        public override int? X86NumBits { get; } = 32;
    }
}