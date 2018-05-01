using McFly.Server.Data;
using Moq;

namespace McFly.Server.Test.Builders
{
    public class TagAccessBuilder
    {
        public Mock<ITagAccess> Mock = new Mock<ITagAccess>();

        public ITagAccess Build()
        {
            return Mock.Object;
        }
    }
}