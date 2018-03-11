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

        [Fact]
        public void Get_Thread_Positions_Correctly()
        {
            // arrange
            var indexMethod = new IndexMethod();
            var builder = new DbgEngProxyBuilder();
            builder.WithExecuteResult("!positions", @">Thread ID=0x7590 - Position: 168CC:0
 Thread ID=0x12A0 - Position: 211F5:0
 Thread ID=0x6CDC - Position: 21D59:0");
            indexMethod.DbgEngProxy = builder.Build();
            var expected = new[]
            {
                new PositionsRecord(0x7590, new Position(0x168CC, 0), true),
                new PositionsRecord(0x12A0, new Position(0x211F5, 0), false),
                new PositionsRecord(0x6CDC, new Position(0x21D59, 0), false),
            };

            // act
            var actual = indexMethod.GetPositions();

            // assert
            actual.SequenceEqual(expected).Should()
                .BeTrue("This is the pattern: >Thread ID=0x7590 - Position: 168CC:0");
        }

        [Fact]
        public void Get_Stack_Frames_Correctly()
        {
            // arrange
            var stackTrace = @"00000000`0014d1d0 00007ffa`513138e6 KERNEL32!GetTimeFormatWWorker+0x7ed
00000000`0014d220 00007ffa`513165ee KERNEL32!QuirkIsEnabledForPackageWorker";

            var expected = new[]
            {
                new StackFrame(0x014d1d0, 0x0007ffa513138e6, "KERNEL32", "GetTimeFormatWWorker", 0x7ed),
                new StackFrame(0x014d220, 0x0007ffa513165ee, "KERNEL32", "QuirkIsEnabledForPackageWorker", 0),
            };

            // act                                                                           
            // assert
            IndexMethod.GetStackFrames(stackTrace).Should().Equal(expected);
        }

        [Fact]
        public void Create_Frame_Correctly()
        {
            // arrange
            var builder = new DbgEngProxyBuilder();
            builder.WithExecuteResult("u rip L1", "00007ffa`51315543 6645898632010000 mov     word ptr [r14+132h],r8w");
            var indexMethod = new IndexMethod {DbgEngProxy = builder.Build()};

            // act
            var frame = indexMethod.CreateFrame(false, new PositionsRecord(1, new Position(0, 0), true),
                new RegisterSet(), new List<StackFrame>());

            // assert
        }

        [Fact]
        public void Get_Current_Instruction_Disassembly()
        {
             var builder = new DbgEngProxyBuilder();
            builder.WithExecuteResult("u rip L1",
                "00007ffa`51315543 6645898632010000 mov     word ptr [r14+132h],r8w ds:00000000`1e042252=00c2");

        }
    }
}
