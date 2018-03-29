using FluentAssertions;
using Xunit;

namespace McFly.Core.Tests
{
    public class PrimitiveExtensions_Should
    {
        [Fact]
        public void Convert_Between_UInt_And_Int()
        {
            uint.MaxValue.ToInt().Should().Be(-1, "All F's is -1 in 2's compliment");
            int.MaxValue.ToUInt().Should().Be(uint.MaxValue / 2, "int.MaxValue will be uint.MaxValue >> 1");
        }

        [Fact]
        public void Convert_Between_ULong_And_Long()
        {
            ulong.MaxValue.ToLong().Should().Be(-1, "All F's is -1 in 2's compliment");
            long.MaxValue.ToULong().Should().Be(ulong.MaxValue / 2, "long.MaxValue will be ulong.MaxValue >> 1");
        }

        [Fact]
        public void Return_Halves_Correctly()
        {
            // arrange                                                                     
            ulong random = 0x0123456789abcdef;

            // act
            // assert
            random.Hi32().Should().Be(0x01234567, "The high 32 bits of 0x0123456798abcdef is 0x01234567");
            random.Lo32().Should().Be(0x89abcdef, "The low 32 bits of 0x0123456798abcdef is 0x89abcdef");
        }

        [Fact]
        public void Set_Halves_Correctly()
        {
            // arrange                                                                     
            ulong random = 0x0123456789abcdef;

            // act
            // assert                      
            random.Hi32(0).Should().Be(0x0000000089abcdef,
                "The high 32 bits of 0x0123456798abcdef zeroed out is is 0x0000000089abcdef");
            random.Lo32(0).Should().Be(0x0123456700000000,
                "The low 32 bits of 0x0123456798abcdef zeroed out is 0x0123456700000000");
        }
    }
}