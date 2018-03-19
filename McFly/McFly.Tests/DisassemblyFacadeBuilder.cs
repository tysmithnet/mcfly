using System.Collections.Generic;
using Moq;

namespace McFly.Tests
{
    internal class DisassemblyFacadeBuilder
    {
        public Mock<IDisassemblyFacade> Mock = new Mock<IDisassemblyFacade>();

        public DisassemblyFacadeBuilder WithGetDisassemblyLines(int num, IEnumerable<DisassemblyLine> result)
        {
            Mock.Setup(facade => facade.GetDisassemblyLines(num)).Returns(result);
            return this;
        }

        public DisassemblyFacadeBuilder WithGetDisassemblyLines(int threadId, int num, IEnumerable<DisassemblyLine> result)
        {
            Mock.Setup(facade => facade.GetDisassemblyLines(threadId, num)).Returns(result);
            return this;
        }

        public IDisassemblyFacade Build()
        {
            return Mock.Object;
        }
    }
}