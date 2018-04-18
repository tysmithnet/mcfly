namespace McFly.Core.Registers
{
    public class Ymm2Register : Register
    {
        public override string Name { get; } = "ymm2";
        public override int NumBits { get; } = 256;
        public override int? X64Index { get; } = 164;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 135;
        public override int? X86NumBits { get; } = 128;
    }
}