namespace McFly.Core.Registers
{
    public class TfRegister : Register
    {
        public override string Name { get; } = "tf";
        public override int NumBits { get; } = 1;
        public override int? X64Index { get; } = 337;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 77;
        public override int? X86NumBits { get; } = 32;
    }
}