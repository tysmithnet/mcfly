﻿using System;
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
            var expected = new byte[] {0x00, 0x11, 0x22, 0x33, 0x44};

            // act
            builder.AppdendHexString("0x001122");
            builder.AppdendHexString("3344");
            builder.AppdendHexString("");
            var bytes = builder.Build();

            // assert
            bytes.Should().Equal(expected);
        }

        [Fact]
        public void Throw_If_Bad_Input()
        {
            // arrange
            var builder = new ByteArrayBuilder();
            Action badInput = () => builder.AppdendHexString("hello");
            Action wrongLength = () => builder.AppdendHexString("0x123");

            // act
            // assert
            badInput.Should().Throw<FormatException>("Only hex characters and x are allowed");
            wrongLength.Should().Throw<FormatException>("Bytes must all come in pairs");

        }
    }
}
