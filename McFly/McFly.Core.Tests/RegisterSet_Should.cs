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
        public void Process_64_Bit_Register_Input_Correctly(string register, string input, int radix, ulong expected,
            string because)
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
        public void Have_Correct_Register_Num_Bits()
        {
            // arrange
            // act
            // assert
            Register.Rax.NumBits.Should().Be(64);
            Register.Rbx.NumBits.Should().Be(64);
            Register.Rcx.NumBits.Should().Be(64);
            Register.Rdx.NumBits.Should().Be(64);
        }

        [Fact]
        public void Process_32_Bit_Register_Input_Correctly()
        {
            // arrange
            var registerSet = new RegisterSet();
            var ones32 = 0xffffffff;
            var half = 0x00000000ffffffff;

            // act
            // assert
            registerSet.Clear();
            registerSet.Process("eax", "-1", 10);
            registerSet.Eax.Should().Be(ones32);
            registerSet.Rax.Should().Be(half);

            registerSet.Clear();
            registerSet.Process("ebx", "-1", 10);
            registerSet.Ebx.Should().Be(ones32);
            registerSet.Rbx.Should().Be(half);

            registerSet.Clear();
            registerSet.Process("ecx", "-1", 10);
            registerSet.Ecx.Should().Be(ones32);
            registerSet.Rcx.Should().Be(half);

            registerSet.Clear();
            registerSet.Process("edx", "-1", 10);
            registerSet.Edx.Should().Be(ones32);
            registerSet.Rdx.Should().Be(half);
        }

        [Fact]
        public void Properly_Get_And_Set_Sub_Registers()
        {
            // arrange
            var reg = new RegisterSet();

            var low32Before = 0x89abcdef;
            uint high32Before = 0x01234567;
            ulong before = 0x0123456789abcdef;
            ulong after = 0x0123456700000000;
            reg.Rax = reg.Rbx = reg.Rcx = reg.Rdx = before;

            // act
            // assert
            reg.Eax.Should().Be(low32Before);
            reg.Eax = 0x0;
            reg.Eax.Should().Be(0);
            reg.Rax.Should().Be(after);

            reg.Ebx.Should().Be(low32Before);
            reg.Ebx = 0x0;
            reg.Ebx.Should().Be(0);
            reg.Rbx.Should().Be(after);

            reg.Ecx.Should().Be(low32Before);
            reg.Ecx = 0x0;
            reg.Ecx.Should().Be(0);
            reg.Rcx.Should().Be(after);

            reg.Edx.Should().Be(low32Before);
            reg.Edx = 0x0;
            reg.Edx.Should().Be(0);
            reg.Rdx.Should().Be(after);
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
    }
}