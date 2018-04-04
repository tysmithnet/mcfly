using McFly.Server.Data;
using Moq;

namespace McFly.Server.Test.Builders
{
    public class NoteAccessBuilder
    {
        public Mock<INoteAccess> Mock = new Mock<INoteAccess>();

        public INoteAccess Build()
        {
            return Mock.Object;
        }
    }
}