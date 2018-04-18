namespace McFly.Core.Registers
{
    public class Ymm15Register : Register
    {
        public override string Name { get; } = "ymm15";
        public override int NumBits { get; } = 256;
        public override int? X64Index { get; } = 177;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}