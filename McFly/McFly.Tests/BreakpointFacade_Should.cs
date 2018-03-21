using System;
using FluentAssertions;
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

        [Fact]
        public void Clear_Breakpoints()
        {
            // arrange
            var facade = new BreakpointFacade();
            var builder = new DbgEngProxyBuilder();
            builder.WithExecuteResult("");
            facade.DbgEngProxy = builder.Build();

            // act
            facade.ClearBreakpoints();

            // assert
            builder.Mock.Verify(proxy => proxy.Execute("bc *"), Times.Once);
        }

        [Fact]
        public void Enforce_Length_Restrictions()
        {
            // arrange
            var facade = new BreakpointFacade();
            var builder = new DbgEngProxyBuilder();
            builder.WithExecuteResult("");
            facade.DbgEngProxy = builder.Build();
            Action shouldThrow = () => facade.SetReadAccessBreakpoint(10, 0x100);
            Action shouldThrow2 = () => facade.SetWriteAccessBreakpoint(10, 0x100);

            // act
            // assert
            shouldThrow.Should().Throw<ArgumentOutOfRangeException>();
            shouldThrow2.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}