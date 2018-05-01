using System;
using FluentAssertions;
using McFly.WinDbg.Test.Builders;
using Moq;
using Xunit;

namespace McFly.WinDbg.Test
{
    public class AccessBreakpoint_Should
    {
        [Fact]
        public void Exhibit_Value_Equality()
        {
            var a1 = new AccessBreakpoint(0, 4, true, false);
            var a2 = new AccessBreakpoint(0, 4, true, false);

            a1.Equals(null).Should().BeFalse();
            a1.Equals((object) null).Should().BeFalse();
            a1.Equals(a1).Should().BeTrue();
            a1.Equals((object) a1).Should().BeTrue();
            a1.Equals(new object()).Should().BeFalse();
            a1.Equals(a2).Should().BeTrue();
            a1.Equals((object) a2).Should().BeTrue();
            a1.GetHashCode().Should().Be(a2.GetHashCode());
        }

        [Fact]
        public void Only_Allow_Lengths_Of_1_2_4_8()
        {
            Action a = () => new AccessBreakpoint(1, 0);
            a.Should().Throw<ArgumentOutOfRangeException>();
            a = () => new AccessBreakpoint(0, 3);
            a.Should().Throw<ArgumentOutOfRangeException>();
            a = () => new AccessBreakpoint(0, 1, false, false);
            a.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Parse_Input_Correctly()
        {
            Action a = () => AccessBreakpoint.Parse(null);
            a.Should().Throw<ArgumentNullException>();
            a = () => AccessBreakpoint.Parse("gibberish");
            a.Should().Throw<FormatException>();
            var bp = AccessBreakpoint.Parse("rw8:abc678");
            bp.Address.Should().Be(0xabc678);
            bp.IsRead.Should().BeTrue();
            bp.IsWrite.Should().BeTrue();
            bp.Length.Should().Be(8);
        }

        [Fact]
        public void Set_Breakpoint_Correctly()
        {
            var bp = AccessBreakpoint.Parse("rw8:abc000");
            var builder = new BreakpointFacadeBuilder();
            var facade = builder
                .WithSetReadAccessBreakpoint()
                .WithSetWriteAccessBreakpoint()
                .Build();
            bp.SetBreakpoint(facade);   
            builder.Mock.Verify(breakpointFacade => breakpointFacade.SetReadAccessBreakpoint(8, 0xabc000), Times.Once);
            builder.Mock.Verify(breakpointFacade => breakpointFacade.SetWriteAccessBreakpoint(8, 0xabc000), Times.Once);

        }
    }
}