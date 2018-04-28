using System.Linq;
using FluentAssertions;
using Xunit;

namespace McFly.Core.Test
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

        [Fact]
        public void Convert_Between_Int_And_Ulong()
        {
            int.MaxValue.ToULong().Should().Be(int.MaxValue);
        }

        [Fact]
        public void Convert_Between_Byte_Array_And_ULong()
        {
            ulong random = 0x0123456789abcdef;
            random.ToByteArray().SequenceEqual(new byte[] {0xef, 0xcd, 0xab, 0x89, 0x67, 0x45, 0x23, 0x01}).Should()
                .BeTrue();
        }

        [Fact]
        public void Convert_Between_Byte_Array_And_Long()
        {
            long random = 0x0123456789abcdef;
            random.ToByteArray().SequenceEqual(new byte[] { 0xef, 0xcd, 0xab, 0x89, 0x67, 0x45, 0x23, 0x01 }).Should()
                .BeTrue();
        }

        [Fact]
        public void Convert_Between_Byte_Array_And_UInt()
        {
            uint random = 0x01234567;
            random.ToByteArray().SequenceEqual(new byte[] { 0x67, 0x45, 0x23, 0x01 }).Should()
                .BeTrue();
        }

        [Fact]
        public void Convert_Between_Byte_Array_And_Int()
        {
            int random = 0x01234567;
            random.ToByteArray().SequenceEqual(new byte[] { 0x67, 0x45, 0x23, 0x01 }).Should()
                .BeTrue();
        }

        [Fact]
        public void Convert_Between_HexString_And_ULong()
        {
            ulong random = 0x0123456789abcdef;
            ulong? random2 = 0x0123456789abcdef;
            random.ToHexString().Should().Be("0123456789ABCDEF");
            random2.ToHexString().Should().Be("0123456789ABCDEF");
        }

        [Fact]
        public void Convert_Between_HexString_And_Long()
        {
            long random = 0x0123456789abcdef;
            long? random2 = 0x0123456789abcdef;
            random.ToHexString().Should().Be("0123456789ABCDEF");
            random2.ToHexString().Should().Be("0123456789ABCDEF");
        }

        [Fact]
        public void Convert_Between_HexString_And_Uint()
        {
            uint random = 0x01234567;
            uint? random2 = 0x01234567;
            random.ToHexString().Should().Be("01234567");
            random2.ToHexString().Should().Be("01234567");
        }
    }
}