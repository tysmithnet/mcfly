using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using McFly.Core;
using Moq;
using Xunit;

namespace McFly.Tests
{
    public class IndexMethod_Should
    {
        [Fact]
        public void Set_Breakpoints_If_They_Are_Provided_In_The_Options()
        {
            // arrange
            var indexMethod = new IndexMethod();
            var indexOptions = new IndexOptions()
            {
                AccessBreakpoints = new []{"r8:100", "w10:200", "rw10:300"},
                BreakpointMasks = new[] {"kernel32!createprocess*", "user32!*", "mycustommod!myfancyfunction"}
            };
            var builder = new BreakpointFacadeBuilder();
            indexMethod.BreakpointFacade = builder.Build();

            // act
            indexMethod.SetBreakpoints(indexOptions);
            
            // assert
            builder.Mock.Verify(proxy => proxy.SetBreakpointByMask("kernel32!createprocess*"), Times.Once);
            builder.Mock.Verify(proxy => proxy.SetBreakpointByMask("user32!*"), Times.Once);
            builder.Mock.Verify(proxy => proxy.SetBreakpointByMask("mycustommod!myfancyfunction"), Times.Once);

            builder.Mock.Verify(proxy => proxy.SetReadAccessBreakpoint(0x8, 0x100), Times.Once);
            builder.Mock.Verify(proxy => proxy.SetReadAccessBreakpoint(0x10, 0x300), Times.Once);
            builder.Mock.Verify(proxy => proxy.SetWriteAccessBreakpoint(0x10, 0x200), Times.Once);
            builder.Mock.Verify(proxy => proxy.SetWriteAccessBreakpoint(0x10, 0x300), Times.Once);
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
            var builder = new TimeTravelFacadeBuilder();
            builder.WithGetStartingPosition(new Position(0x35, 0));
            indexMethod.TimeTravelFacade = builder.Build();
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