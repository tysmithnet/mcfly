using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace McFly.Core.Test
{
    public class PrimitiveExtensions_Should
    {
        [Fact]
        public void Convert_Between_ByteArray_And_Int()
        {
            int random = 0x01234567;
            random.ToByteArray().SequenceEqual(new byte[] {0x67, 0x45, 0x23, 0x01}).Should()
                .BeTrue();

            var bytes = new byte[] {0x23, 0xc1, 0xab, 0x00};
            var bad = new byte[0];
            byte[] bad2 = null;
            bytes.ToInt().Should().Be(0xabc123);
            Action a = () => bad.ToInt();
            Action a2 = () => bad2.ToInt();
            a.Should().Throw<ArgumentOutOfRangeException>();
            a2.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Convert_Between_ByteArray_And_Long()
        {
            long random = 0x0123456789abcdef;
            random.ToByteArray().SequenceEqual(new byte[] {0xef, 0xcd, 0xab, 0x89, 0x67, 0x45, 0x23, 0x01}).Should()
                .BeTrue();
            var bytes = BitConverter.GetBytes(random);
            bytes.ToLong().Should().Be(random);
            byte[] nullBytes = null;
            Action a = () => nullBytes.ToLong();
            a.Should().Throw<ArgumentNullException>();
            var empty = new byte[0];
            Action a2 = () => empty.ToLong();
            a2.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Convert_Between_ByteArray_And_Short()
        {
            short random = 0x0123;
            random.ToByteArray().SequenceEqual(new byte[] { 0x23, 0x01 }).Should()
                .BeTrue();
            var bytes = BitConverter.GetBytes((short) 0x1234);
            bytes.ToShort().Should().Be((short)0x1234);
            byte[] nullBytes = null;
            Action a = () => nullBytes.ToShort();
            a.Should().Throw<ArgumentNullException>();
            var empty = new byte[0];
            Action a2 = () => empty.ToShort();
            a2.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Convert_Between_ByteArray_And_UShort()
        {
            ushort random = 0x0123;
            random.ToByteArray().SequenceEqual(new byte[] { 0x23, 0x01 }).Should()
                .BeTrue();
            var bytes = BitConverter.GetBytes((ushort)0x1234);
            bytes.ToUShort().Should().Be((ushort)0x1234);
            byte[] nullBytes = null;
            Action a = () => nullBytes.ToUShort();
            a.Should().Throw<ArgumentNullException>();
            var empty = new byte[0];
            Action a2 = () => empty.ToUShort();
            a2.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Convert_Between_ByteArray_And_UInt()
        {
            uint random = 0x01234567;
            random.ToByteArray().SequenceEqual(new byte[] {0x67, 0x45, 0x23, 0x01}).Should()
                .BeTrue();
            new byte[] {0x67, 0x45, 0x23, 0x01}.ToUInt().Should().Be(random);
            byte[] nullBytes = null;
            byte[] emptyBytes = new byte[0];

            Action a = () => nullBytes.ToUInt();
            Action a2 = () => emptyBytes.ToUInt();

            a.Should().Throw<ArgumentNullException>();
            a2.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Convert_Between_ByteArray_And_ULong()
        {
            ulong random = 0x0123456789abcdef;
            random.ToByteArray().SequenceEqual(new byte[] {0xef, 0xcd, 0xab, 0x89, 0x67, 0x45, 0x23, 0x01}).Should()
                .BeTrue();

            byte[] nullBytes = null;
            byte[] emptyBytes = new byte[0];

            Action a = () => nullBytes.ToULong();
            Action a2 = () => emptyBytes.ToULong();

            a.Should().Throw<ArgumentNullException>();
            a2.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Convert_Between_HexString_And_ByteArray()
        {
            var random = new byte[] {0xef, 0xcd, 0xab, 0x89, 0x67, 0x45, 0x23, 0x01};
            random.ToHexString(true).Should().Be("0123456789ABCDEF");
            random.Reverse().ToArray().ToHexString().Should().Be("0123456789ABCDEF");
        }

        [Fact]
        public void Convert_Between_HexString_And_Int()
        {
            "23c1ab00".ToInt().Should().Be(0xabc123);
            Convert.ToInt32(0xabc123).ToHexString().Should().Be("23C1AB00");
        }

        [Fact]
        public void Convert_Between_HexString_And_Long()
        {
            var random = 0x0123456789abcdef;
            long? random2 = 0x0123456789abcdef;
            random.ToHexString().Should().Be("EFCDAB8967452301");
            random2.ToHexString().Should().Be("EFCDAB8967452301");

            "EFCDAB8967452301".ToLong().Should().Be(0x0123456789abcdef);
        }

        [Fact]
        public void Convert_Between_HexString_And_UInt()
        {
            uint random = 0x01234567;
            uint? random2 = 0x01234567;
            random.ToHexString().Should().Be("67452301");
            random2.ToHexString().Should().Be("67452301");
            "67452301".ToUInt().Should().Be(random);
        }

        [Fact]
        public void Convert_Between_HexString_And_ULong()
        {
            ulong random = 0x0123456789abcdef;
            ulong? random2 = 0x0123456789abcdef;
            random.ToHexString().ToLower().Should().Be("efcdab8967452301");
            random2.ToHexString().ToLower().Should().Be("efcdab8967452301");
        }

        [Fact]
        public void Convert_Between_HexString_And_UShort()
        {
            ushort random = 0x0123;
            ushort? random2 = 0x0123;
            random.ToHexString().Should().Be("2301");
            random2.ToHexString().Should().Be("2301");
            "2301".ToUShort().Should().Be(0x0123);
        }

        [Fact]
        public void Convert_Between_HexString_And_Short()
        {
            short s = 0x1234;
            string hex = "3412";
            hex.ToShort().Should().Be(s);
            s.ToHexString().Should().Be(hex);
        }

        [Fact]
        public void Convert_Between_Int_And_Ulong()
        {
            int.MaxValue.ToULong().Should().Be(int.MaxValue);
        }

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