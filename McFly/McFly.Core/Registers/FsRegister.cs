namespace McFly.Core.Registers
{
    public class FsRegister : Register
    {
        public override string Name { get; } = "fs";
        public override int NumBits { get; } = 16;
        public override int? X64Index { get; } = 21;
        public override int? X64NumBits { get; } = 16;
        public override int? X86Index { get; } = 1;
        public override int? X86NumBits { get; } = 32;
    }
}