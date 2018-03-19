using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace McFly.Tests
{
    public class ByteArrayBuilder_Should
    {
        [Fact]
        public void Append_Hex_String_Appropriately()
        {
            // arrange
            var builder = new ByteArrayBuilder();
            var expected = new byte[] {0x00, 0x11, 0x22};

            // act
            builder.AppdendHexString("0x001122");
            builder.AppdendHexString("");
            var bytes = builder.Build();

            // assert
            bytes.Should().Equal(expected);
        }
    }
}
