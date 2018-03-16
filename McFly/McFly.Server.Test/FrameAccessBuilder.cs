using McFly.Server.Data;
using Moq;

namespace McFly.Server.Test
{
    public class FrameAccessBuilder
    {
        public Mock<IFrameAccess> Mock = new Mock<IFrameAccess>();

        public IFrameAccess Build()
        {
            return Mock.Object;
        }
    }
}