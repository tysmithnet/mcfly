using System;
using FluentAssertions;
using Xunit;

namespace McFly.Core.Tests
{
    public class RegisterSet_Should
    {
        [Theory]
        [InlineData("rax", "10", 16, 0x10, "Base 16 means the input is interpretted as hex chars")]
        [InlineData("rbx", "10", 10, 10, "Base 10 means the input is interpretted as dec chars")]
        [InlineData("rcx", "10", 8, 8, "Base 8 means the input is interpretted as oct chars")]
        [InlineData("rdx", "10", 2, 2, "Base 2 means the input is interpretted as bin chars")]
        public void Process_Input_Correctly(string register, string input, int radix, ulong expected, string because)
        {
            // arrange
            var registerSet = new RegisterSet();

            // act
            registerSet.Process(register, input, radix);

            // assert
            switch (register)
            {
                case "rax":
                    registerSet.Rax.Should().Be(expected, because);
                    break;
                case "rbx":
                    registerSet.Rbx.Should().Be(expected, because);
                    break;
                case "rcx":
                    registerSet.Rcx.Should().Be(expected, because);
                    break;
                case "rdx":
                    registerSet.Rdx.Should().Be(expected, because);
                    break;
            }
        }

        [Fact]
        public void Throw_If_Passed_Bad_Values_To_Process()
        {
            // arrange
            var registerSet = new RegisterSet();
            Action throws = () => registerSet.Process(null, "0", 16);
            Action throws2 = () => registerSet.Process("rax", "hello", 16);
            
            // act
            // assert
            throws.Should().Throw<ArgumentNullException>("Register cannot be null");
            throws2.Should().Throw<FormatException>("hello is not a valid hex string");
        }

        [Fact]
        public void Have_Correct_Register_Num_Bits()
        {
            Register.Rax.NumBits.Should().Be(64);
            Register.Rbx.NumBits.Should().Be(64);
            Register.Rcx.NumBits.Should().Be(64);
            Register.Rdx.NumBits.Should().Be(64);
        }
    }
}