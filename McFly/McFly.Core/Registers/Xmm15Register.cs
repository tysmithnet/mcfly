namespace McFly.Core.Registers
{
    public class Xmm15Register : Register
    {
        public override string Name { get; } = "xmm15";
        public override int NumBits { get; } = 128;
        public override int? X64Index { get; } = 65;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}