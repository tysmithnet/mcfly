using System;
using FluentAssertions;
using McFly.WinDbg.Debugger;
using McFly.WinDbg.Test.Builders;
using Moq;
using Xunit;

namespace McFly.WinDbg.Test
{
    public class MemoryEngine_Should
    {
        [Fact]
        public void Read_From_Low_To_High()
        {
            var memEng = new MemoryEngine();
            var mock = new Mock<IDebugDataSpaces>();
            uint bytesRead = 100;
            mock.Setup(spaces =>
                spaces.ReadVirtual(It.IsAny<ulong>(), It.IsAny<byte[]>(), It.IsAny<uint>(), out bytesRead));
            var res = memEng.ReadMemory(0, 0x100, mock.Object);
            mock.Verify(spaces => spaces.ReadVirtual(0, It.IsAny<byte[]>(), 0x100, out bytesRead), Times.Once);
        }

        [Fact]
        public void Throw_If_Bad_Low_High_Provided()
        {
            var memEng = new MemoryEngine();
            var mock = new Mock<IDebugDataSpaces>();
            Action a = () => memEng.ReadMemory(1, 1, mock.Object);
            a.Should().Throw<ArgumentOutOfRangeException>();
            a = () => memEng.ReadMemory(2, 1, mock.Object);
            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Throw_Application_Exception_If_DataSpaces_Fails()
        {
            var builder = new DebugDataSpacesBuilder();
            var spaces = builder.WithReadVirtual(0x8000000).Build();
            var memEng = new MemoryEngine();
            Action a = () => memEng.ReadMemory(0, 1, spaces);
            a.Should().Throw<ApplicationException>();
        }
    }
}