using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using McFly.Core;
using McFly.WinDbg.Test.Builders;
using Moq;
using Xunit;

namespace McFly.WinDbg.Test
{
    public class IndexMethod_Should
    {
        [Fact]
        public void Identify_32_And_64_Bit_Arch()
        {
            // Arrange
            var builder = new DebugEngineProxyBuilder();
            builder.WithExecuteResult("!peb", @"PEB at 00000000003b9000
    InheritedAddressSpace:    No
    ReadImageFileExecOptions: No
    BeingDebugged:            No
    ...
    ImageBaseAddress:         0000000140000000        _NT_SYMBOL_PATH=SRV*c:\symbols*http://msdl.microsoft.com/download/symbols");

            // Act
            var indexMethod = new IndexMethod();
            indexMethod.DebugEngineProxy = builder.Build();
            var is32 = indexMethod.Is32Bit();

            // Assert
            is32.Should().BeFalse("00000000003b9000 is 16 characters and thus 64bit");
        }

        [Fact]
        public void Identify_Correct_Ending_Position()
        {
            // Arrange                             
            var options = new IndexOptions
            {
                End = new Position(0x35, 0x1)
            };

            var indexMethod = new IndexMethod();
            var builder = new TimeTravelFacadeBuilder();
            builder.WithLastPosition(new Position(0x35, 5));
            indexMethod.TimeTravelFacade = builder.Build();

            // Act
            var endingPosition = indexMethod.GetEndingPosition(options);

            // Assert
            endingPosition.Should().Be(new Position(0x35, 1),
                "35:1 means that the high portion is 35 and the low portion is 1");
        }

        [Fact]
        public void Identify_Correct_Starting_Position()
        {
            // Arrange                             
            var options = new IndexOptions
            {
                Start = new Position(0x35, 0x1)
            };

            var indexMethod = new IndexMethod();
            var builder = new TimeTravelFacadeBuilder();
            builder.WithFirstPosition(new Position(0x35, 0));
            indexMethod.TimeTravelFacade = builder.Build();

            // Act
            var startingPosition = indexMethod.GetStartingPosition(options);

            // Assert
            startingPosition.Should().Be(new Position(0x35, 1),
                "35:1 means that the high portion is 35 and the low portion is 1");
        }

        [Fact]
        public void Properly_Parse_Args_Into_Options()
        {
            // arrange
            var args0 =
                "--start abc:123 --end def:456 --bm kernel32!*create* user32!* --ba rw8:10000 w4:30000 -m abcl100 abc:def"
                    .Split(' ');
            var options0 = new IndexOptions
            {
                Start = new Position(0xabc, 0x123),
                End = new Position(0xdef, 0x456),
                BreakpointMasks = new[]
                {
                    new BreakpointMask("kernel32", "*create*"),
                    new BreakpointMask("user32", "*")
                },
                AccessBreakpoints = new[]
                {
                    new AccessBreakpoint(0x10000, 8, true, true),
                    new AccessBreakpoint(0x30000, 4, false, true)
                },
                MemoryRanges = new[]
                {
                    new MemoryRange(0xabc, 0xbbc),
                    new MemoryRange(0xabc, 0xdef)
                }
            };
            var index = new IndexMethod();

            // act
            // assert
            index.ExtractIndexOptions(args0).Should().Be(options0);
        }

        [Fact]
        public void Set_Breakpoints_If_They_Are_Provided_In_The_Options()
        {
            // arrange
            var indexMethod = new IndexMethod();
            var indexOptions = new IndexOptions
            {
                AccessBreakpoints = new[]
                {
                    AccessBreakpoint.Parse("r8:100"),
                    AccessBreakpoint.Parse("w8:200"),
                    AccessBreakpoint.Parse("rw4:300")
                },
                BreakpointMasks = new[]
                {
                    BreakpointMask.Parse("kernel32!createprocess*"),
                    BreakpointMask.Parse("user32!*"),
                    BreakpointMask.Parse("mycustommod!myfancyfunction")
                }
            };
            var builder = new BreakpointFacadeBuilder();
            indexMethod.BreakpointFacade = builder.Build();

            // act
            indexMethod.SetBreakpoints(indexOptions);

            // assert
            builder.Mock.Verify(proxy => proxy.SetBreakpointByMask("kernel32", "createprocess*"), Times.Once);
            builder.Mock.Verify(proxy => proxy.SetBreakpointByMask("user32", "*"), Times.Once);
            builder.Mock.Verify(proxy => proxy.SetBreakpointByMask("mycustommod", "myfancyfunction"), Times.Once);

            builder.Mock.Verify(proxy => proxy.SetReadAccessBreakpoint(0x8, 0x100), Times.Once);
            builder.Mock.Verify(proxy => proxy.SetReadAccessBreakpoint(0x4, 0x300), Times.Once);
            builder.Mock.Verify(proxy => proxy.SetWriteAccessBreakpoint(0x8, 0x200), Times.Once);
            builder.Mock.Verify(proxy => proxy.SetWriteAccessBreakpoint(0x4, 0x300), Times.Once);
        }

        [Fact]
        public void Upsert_Frames_From_Breaks()
        {
            throw new NotImplementedException();
        }
    }
}