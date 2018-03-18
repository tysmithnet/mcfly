using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using McFly.Core;
using Xunit;

namespace McFly.Tests
{
    public class IndexMethod_Should
    {
        [Fact]
        public void Create_Frames_From_Position_Records_Correctly()
        {
            // arrange
            var positions = new[]
            {
                new PositionsRecord(1, new Position(0, 0), true),
                new PositionsRecord(2, new Position(1, 0), false),
                new PositionsRecord(3, new Position(2, 0), false)
            };
            var indexMethod = new IndexMethod();

            // act

            // assert
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
                new StackFrame(0x014d220, 0x0007ffa513165ee, "KERNEL32", "QuirkIsEnabledForPackageWorker", 0)
            };

            // act                                                                           
            // assert
            IndexMethod.GetStackFrames(stackTrace).Should().Equal(expected);
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
                new PositionsRecord(0x6CDC, new Position(0x21D59, 0), false)
            };

            // act
            var actual = indexMethod.GetPositions();

            // assert
            actual.SequenceEqual(expected).Should()
                .BeTrue("This is the pattern: >Thread ID=0x7590 - Position: 168CC:0");
        }

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
            var is32 = indexMethod.Is32Bit();

            // Assert
            is32.Should().BeFalse("00000000003b9000 is 16 characters and thus 64bit");
        }

        [Fact]
        public void Identify_Correct_Ending_Position()
        {
            var options = new IndexOptions
            {
                End = "1:0"
            };

            var indexMethod = new IndexMethod();
            var builder = new DbgEngProxyBuilder();
            builder.WithEndingPosition(new Position(0, 0));
            indexMethod.DbgEngProxy = builder.Build();

            var position = indexMethod.GetEndingPosition(options);
            var position2 = indexMethod.GetEndingPosition(new IndexOptions());

            position.Should().Be(new Position(1, 0));
            position2.Should().Be(new Position(0, 0));
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

            var indexMethod = new IndexMethod();
            var builder = new DbgEngProxyBuilder();
            builder.WithStartingPosition(new Position(0x35, 0));
            indexMethod.DbgEngProxy = builder.Build();
            var nullStartingPosition = indexMethod.GetStartingPosition(null);

            // Act
            var startingPosition = indexMethod.GetStartingPosition(options);
            var invalidStartPosition = indexMethod.GetStartingPosition(invalidStartOptions);

            // Assert
            startingPosition.Should().Be(new Position(0x35, 1),
                "35:1 means that the high portion is 35 and the low portion is 1");
            invalidStartPosition.Should().Be(new Position(0, 0),
                "Any invalid input should result in a default position of 0:0");
            nullStartingPosition.Should().Be(new Position(0x35, 0),
                "No starting position in the options means use the proxy's value");
        }
    }
}