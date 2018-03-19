using System.Collections.Generic;
using McFly.Core;
using Moq;

namespace McFly.Tests
{
    internal class RegisterFacadeBuilder
    {
        public Mock<IRegisterFacade> Mock = new Mock<IRegisterFacade>();

        public RegisterFacadeBuilder WithGetCurrentRegisterSet(int threadId, IEnumerable<Register> registers,
            RegisterSet result)
        {
            Mock.Setup(facade => facade.GetCurrentRegisterSet(threadId, registers)).Returns(result);
            return this;
        }

        public RegisterFacadeBuilder WithGetCurrentRegisterSet(IEnumerable<Register> registers,
            RegisterSet result)
        {
            Mock.Setup(facade => facade.GetCurrentRegisterSet(registers)).Returns(result);
            return this;
        }

        public IRegisterFacade Build()
        {
            return Mock.Object;
        }
    }
}