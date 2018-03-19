using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace McFly.Tests
{
    internal class BreakpointFacadeBuilder
    {
        public Mock<IBreakpointFacade> Mock = new Mock<IBreakpointFacade>();

        public IBreakpointFacade Build()
        {
            return Mock.Object;
        }
    }
}
