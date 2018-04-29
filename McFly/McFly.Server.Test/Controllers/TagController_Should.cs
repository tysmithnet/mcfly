using McFly.Core;
using McFly.Server.Contract;
using McFly.Server.Controllers;
using McFly.Server.Test.Builders;
using Moq;
using Xunit;

namespace McFly.Server.Test.Controllers
{
    public class TagController_Should
    {
        [Fact]
        public void Create_Tag_On_Post()
        {
            // arrange
            var controller = new TagController();
            var builder = new TagAccessBuilder();
            controller.TagAccess = builder.Build();
            var request = new AddTagRequest(new Position(0, 0), new[] {1}, "hi world");

            // act
            // assert
            controller.Post("testing", request);

            builder.Mock.Verify(access => access.AddTag("testing", new Position(0, 0), new[] {1}, "hi world"),
                Times.Once);
        }
    }
}