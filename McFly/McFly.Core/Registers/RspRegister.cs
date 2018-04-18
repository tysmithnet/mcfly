namespace McFly.Core.Registers
{
    public class RspRegister : Register
    {
        public override string Name { get; } = "rsp";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 4;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}