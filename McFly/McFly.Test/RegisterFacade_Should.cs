using FluentAssertions;
using McFly.Core.Registers;
using McFly.Test.Builders;
using Xunit;

namespace McFly.Test
{
    public class RegisterFacade_Should
    {
        [Fact]
        public void Get_Current_RegisterSet_Correctly()
        {
            // arrange
            var builder = new DebugEngineProxyBuilder();
            builder.With32Bit(false);
            var facade = new RegisterFacade();
            builder.WithExecuteResult(
                @"rax=000000003205f31c rbx=000000001e042120 rcx=000000003205f322 rdx=000000003205f2ce");
            builder.WithThreadId(1);
            facade.DebugEngineProxy = builder.Build();

            // act
            var registerSet = facade.GetCurrentRegisterSet(new Register[]{Register.Rax, Register.Rbx, Register.Rcx, Register.Rdx, });
            var emptySet = facade.GetCurrentRegisterSet(new Register[0]);

            // assert
            registerSet.Rax.Should().Be(0x000000003205f31c);
            registerSet.Rbx.Should().Be(0x000000001e042120);
            registerSet.Rcx.Should().Be(0x000000003205f322);
            registerSet.Rdx.Should().Be(0x000000003205f2ce);
            emptySet.Should().Be(new RegisterSet());
        }
    }
}