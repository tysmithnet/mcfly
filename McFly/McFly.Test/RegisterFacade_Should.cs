using System.Linq;
using FluentAssertions;
using McFly.Core;
using McFly.Test.Builders;
using Xunit;
using static McFly.Core.Registers.Register;

namespace McFly.Test
{
    public class RegisterFacade_Should
    {
        [Fact]
        public void Set_RegisterSet_Values_Correctly()
        {
            var facade = new RegisterFacade();
            facade.DebugEngineProxy = new DebugEngineProxyBuilder()
                .WithGetRegisterValue(Enumerable.Repeat(0xff, 32).Select(x => (byte) x).ToArray())
                .Build();

            var r = facade.GetCurrentRegisterSet(X64);
            r.Af.Should().BeTrue();
            r.Ah.Should().Be(byte.MaxValue);
            r.Al.Should().Be(byte.MaxValue);
            r.Ax.Should().Be(ushort.MaxValue);
        }
    }
}