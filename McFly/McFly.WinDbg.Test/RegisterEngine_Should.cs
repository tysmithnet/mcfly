using McFly.Core.Registers;
using McFly.WinDbg.Debugger;
using Moq;
using Xunit;

namespace McFly.WinDbg.Test
{
    public class RegisterEngine_Should
    {
        [Fact]
        public void Get_The_Appropriate_Kind_Of_Register()
        {
            {
                var regMock = new Mock<IDebugRegisters2>();
                var dbgMock = new Mock<IDebugEngineProxy>();
                var engMock = new Mock<RegisterEngine>();

                dbgMock.Setup(d => d.GetCurrentThreadId()).Returns(1);
                dbgMock.Setup(d => d.Is32Bit).Returns(true);

                engMock.Object.GetRegisterValue(1, Register.Ymm0, regMock.Object, dbgMock.Object);
                engMock.Verify(e => e.GetRegisterValue32(Register.Ymm0, regMock.Object));
            }

            {
                var regMock = new Mock<IDebugRegisters2>();
                var dbgMock = new Mock<IDebugEngineProxy>();
                var engMock = new Mock<RegisterEngine>();

                dbgMock.Setup(d => d.GetCurrentThreadId()).Returns(1);
                dbgMock.Setup(d => d.Is32Bit).Returns(false);

                engMock.Object.GetRegisterValue(1, Register.Ymm0, regMock.Object, dbgMock.Object);
                engMock.Verify(e => e.GetRegisterValue64(Register.Ymm0, regMock.Object));
            }
        }
    }
}