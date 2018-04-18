namespace McFly.Core.Registers
{
    public class Ymm6Register : Register
    {
        public override string Name { get; } = "ymm6";
        public override int NumBits { get; } = 256;
        public override int? X64Index { get; } = 168;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 139;
        public override int? X86NumBits { get; } = 128;
    }
}