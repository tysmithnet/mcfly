using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using McFly.Core;
using Moq;
using Xunit;
using Xunit.Sdk;

namespace McFly.Tests
{
    public class IndexMethod_Should
    {
        [Fact]
        public void Identify_32_And_64_Bit_Arch()
        {
            // Arrange
            var builder = new DbgEngProxyBuilder();
            builder.WithExecuteResult("!peb", @"PEB at 00000000003b9000
    InheritedAddressSpace:    No
    ReadImageFileExecOptions: No
    BeingDebugged:            No
    ...
    ImageBaseAddress:         0000000140000000        _NT_SYMBOL_PATH=SRV*c:\symbols*http://msdl.microsoft.com/download/symbols");
            var proxy = builder.Build();

            // Act
            var indexMethod = new IndexMethod();
            indexMethod.DbgEngProxy = builder.Build();
            bool is32 = indexMethod.Is32Bit();

            // Assert
            is32.Should().BeFalse("00000000003b9000 is 16 characters and thus 64bit");
        }

        [Fact]
        public void Identify_Correct_Starting_Position()
        {
            // Arrange                             
            var options = new IndexOptions
            {
                Start = "35:1"
            };
            var invalidStartOptions = new IndexOptions
            {
                Start = "hello there"
            };
                                       
            // Act
            var startingPosition = IndexMethod.GetStartingPosition(options);
            var nullPosition = IndexMethod.GetStartingPosition(null);
            var invalidStartPosition = IndexMethod.GetStartingPosition(invalidStartOptions);

            // Assert
            startingPosition.Should().Be(new Position(0x35, 1),
                "35:1 means that the high portion is 35 and the low portion is 1");
            nullPosition.Should().Be(new Position(0, 0), "Null is an invalid input and should result in a default position of 0:0");
            invalidStartPosition.Should().Be(new Position(0, 0),
                "Any invalid input should result in a default position of 0:0");
        }
    }
}
