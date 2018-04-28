using McFly.WinDbg;
using McFly.WinDbg.Debugger;
using Moq;

namespace McFly.WinDbg.Test
{
    internal class MemoryEngineBuilder
    {
        public Mock<WinDbg.IMemoryEngine> Mock = new Mock<WinDbg.IMemoryEngine>();

        public MemoryEngineBuilder WithReadMemory(byte[] bytes)
        {
            Mock.Setup(engine => engine.ReadMemory(It.IsAny<ulong>(), It.IsAny<ulong>(), It.IsAny<IDebugDataSpaces>())).Returns(bytes);
            return this;
        }

        public MemoryEngineBuilder WithReadMemory(ulong start, ulong end, IDebugDataSpaces spaces, bool is32Bit, byte[] bytes)
        {
            Mock.Setup(engine => engine.ReadMemory(start, end, spaces)).Returns(bytes);
            return this;
        }

        public IMemoryEngine Build()
        {
            return Mock.Object;
        }
    }
}