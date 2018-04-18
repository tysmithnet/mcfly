namespace McFly.Core.Registers
{
    public class Ymm5Register : Register
    {
        public override string Name { get; } = "ymm5";
        public override int NumBits { get; } = 256;
        public override int? X64Index { get; } = 167;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 138;
        public override int? X86NumBits { get; } = 128;
    }
}