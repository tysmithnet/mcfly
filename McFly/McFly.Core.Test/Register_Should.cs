using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using McFly.Core.Registers;
using Xunit;

namespace McFly.Core.Test
{
    public class Register_Should
    {
        [Fact]
        public void Not_Have_Duplicates()
        {
            Register.AllRegisters.Should().OnlyHaveUniqueItems();
        }
    }
}
