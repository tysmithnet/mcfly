using McFly.Core;
using Moq;

namespace McFly.Tests
{
    internal class TimeTravelFacadeBuilder
    {
        public Mock<ITimeTravelFacade> Mock = new Mock<ITimeTravelFacade>();

        public TimeTravelFacadeBuilder WithGetCurrentPosition(Position result)
        {
            Mock.Setup(facade => facade.GetCurrentPosition()).Returns(result);
            return this;
        }

        public TimeTravelFacadeBuilder WithGetCurrentPosition(int threadId, Position result)
        {
            Mock.Setup(facade => facade.GetCurrentPosition(threadId)).Returns(result);
            return this;
        }

        public TimeTravelFacadeBuilder WithGetStartingPosition(Position result)
        {
            Mock.Setup(facade => facade.GetStartingPosition()).Returns(result);
            return this;
        }

        public TimeTravelFacadeBuilder WithGetEndingPosition(Position result)
        {
            Mock.Setup(facade => facade.GetEndingPosition()).Returns(result);
            return this;
        }

        public TimeTravelFacadeBuilder WithPositions(PositionsResult result)
        {
            Mock.Setup(facade => facade.Positions()).Returns(result);
            return this;
        }

        public ITimeTravelFacade Build()
        {
            return Mock.Object;
        }
    }
}