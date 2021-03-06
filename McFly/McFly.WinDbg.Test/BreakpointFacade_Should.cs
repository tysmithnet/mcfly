﻿using System;
using FluentAssertions;
using McFly.WinDbg.Test.Builders;
using Moq;
using Xunit;

namespace McFly.WinDbg.Test
{
    public class BreakpointFacade_Should
    {
        [Fact]
        public void Clear_Breakpoints()
        {
            // arrange
            var facade = new BreakpointFacade();
            var builder = new DebugEngineProxyBuilder();
            builder.WithExecuteResult("");
            facade.DebugEngineProxy = builder.Build();

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
            var builder = new DebugEngineProxyBuilder();
            builder.WithExecuteResult("");
            facade.DebugEngineProxy = builder.Build();
            Action shouldThrow = () => facade.SetReadAccessBreakpoint(10, 0x100);
            Action shouldThrow2 = () => facade.SetWriteAccessBreakpoint(10, 0x100);

            // act
            // assert
            shouldThrow.Should().Throw<ArgumentOutOfRangeException>();
            shouldThrow2.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Set_Breakpoint_By_Mask_Correctly()
        {
            // arrange
            var facade = new BreakpointFacade();
            var builder = new DebugEngineProxyBuilder();
            facade.DebugEngineProxy = builder.Build();

            // act
            facade.SetBreakpointByMask("kernel32", "createprocess*");

            // assert
            builder.Mock.Verify(proxy => proxy.Execute("bm kernel32!createprocess*"), Times.Once);
        }

        [Fact]
        public void Set_Read_Breakpoint_Correctly()
        {
            // arrange
            var facade = new BreakpointFacade();
            var builder = new DebugEngineProxyBuilder();
            builder.WithExecuteResult("");
            facade.DebugEngineProxy = builder.Build();

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
            var builder = new DebugEngineProxyBuilder();
            builder.WithExecuteResult("");
            facade.DebugEngineProxy = builder.Build();

            // act
            facade.SetWriteAccessBreakpoint(8, 0x100);

            // assert
            builder.Mock.Verify(proxy => proxy.Execute("ba w8 100"), Times.Once);
        }
    }
}