using McFly.Debugger;
using Moq;

namespace McFly.Test
{
    public class MemoryEngineBuilder
    {
        public Mock<IMemoryEngine> Mock = new Mock<IMemoryEngine>();

        public MemoryEngineBuilder WithReadMemory(byte[] bytes)
        {
            Mock.Setup(engine => engine.ReadMemory(It.IsAny<ulong>(), It.IsAny<ulong>(), It.IsAny<IDebugDataSpaces>(), It.IsAny<bool>())).Returns(bytes);
            return this;
        }

        public MemoryEngineBuilder WithReadMemory(ulong start, ulong end, IDebugDataSpaces spaces, bool is32Bit, byte[] bytes)
        {
            Mock.Setup(engine => engine.ReadMemory(start, end, spaces, is32Bit)).Returns(bytes);
            return this;
        }

        public IMemoryEngine Build()
        {
            return Mock.Object;
        }
    }
}