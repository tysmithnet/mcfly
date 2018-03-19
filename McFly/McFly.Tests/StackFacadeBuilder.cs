using McFly.Core;
using Moq;

namespace McFly.Tests
{
    internal class StackFacadeBuilder
    {
        public Mock<IStackFacade> Mock = new Mock<IStackFacade>();

        public StackFacadeBuilder WithGetCurrentStackTrace(StackTrace stackTrace)
        {
            Mock.Setup(facade => facade.GetCurrentStackTrace()).Returns(stackTrace);
            return this;
        }

        public StackFacadeBuilder WithGetCurrentStackTrace(int threadId, StackTrace stackTrace)
        {
            Mock.Setup(facade => facade.GetCurrentStackTrace(threadId)).Returns(stackTrace);
            return this;
        }

        public IStackFacade Build()
        {
            return Mock.Object;
        }
    }
}