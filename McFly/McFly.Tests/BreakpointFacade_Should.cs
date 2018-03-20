using Moq;
using Xunit;

namespace McFly.Tests
{
    public class BreakpointFacade_Should
    {
        [Fact]
        public void Set_Breakpoint_By_Mask_Correctly()
        {
            // arrange
            var facade = new BreakpointFacade();
            var builder = new DbgEngProxyBuilder();
            facade.DbgEngProxy = builder.Build();
            
            // act
            facade.SetBreakpointByMask("kernel32!createprocess*");

            // assert
            builder.Mock.Verify(proxy => proxy.Execute("bm kernel32!createprocess*"), Times.Once);
        }

        [Fact]
        public void Set_Read_Breakpoint_Correctly()
        {
            // arrange
            var facade = new BreakpointFacade();
            var builder = new DbgEngProxyBuilder();
            builder.WithExecuteResult("");
            facade.DbgEngProxy = builder.Build();

            // act
            facade.SetReadAccessBreakpoint(8, 0x100);

            // assert
            builder.Mock.Verify(proxy => proxy.Execute("ba r8 100"), Times.Once);
        }

        [Fact]
        public void Set_Write_Breakpoint_Correctly()
        {
            // arrange
            var facade = new BreakpointFacade();
            var builder = new DbgEngProxyBuilder();
            builder.WithExecuteResult("");
            facade.DbgEngProxy = builder.Build();

            // act
            facade.SetWriteAccessBreakpoint(8, 0x100);

            // assert
            builder.Mock.Verify(proxy => proxy.Execute("ba w8 100"), Times.Once);
        }      
    }
}