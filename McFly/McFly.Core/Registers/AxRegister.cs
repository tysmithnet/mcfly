namespace McFly.Core.Registers
{
    public class AxRegister : Register
    {
        public override string Name { get; } = "ax";
        public override int NumBits { get; } = 16;
        public override int? X64Index { get; } = 295;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 27;
        public override int? X86NumBits { get; } = 32;
    }
}