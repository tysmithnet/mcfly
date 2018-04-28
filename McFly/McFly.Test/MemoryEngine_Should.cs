using McFly.WinDbg;
using McFly.WinDbg.Debugger;
using Moq;
using Xunit;

namespace McFly.Test
{
    public class MemoryEngine_Should
    {
        [Fact]
        public void Use_High_To_Low()
        {
            var memEng = new MemoryEngine();
            var mock = new Mock<IDebugDataSpaces>();
            uint bytesRead = 100;
            mock.Setup(spaces =>
                spaces.ReadVirtual(It.IsAny<ulong>(), It.IsAny<byte[]>(), It.IsAny<uint>(), out bytesRead));
            var res = memEng.ReadMemory(0x100, 0, mock.Object);
            mock.Verify(spaces => spaces.ReadVirtual(0x100, It.IsAny<byte[]>(), 0x100, out bytesRead), Times.Once);
        }
    }
}