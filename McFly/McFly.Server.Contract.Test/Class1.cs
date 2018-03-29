using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace McFly.Server.Contract.Test
{
    public class Class1
    {
        [Fact]
        public void Should_Pass()
        {
            true.Should().Be(true);
        }
    }
}
