using McFly.Core;
using McFly.Server.Contract;
using McFly.Server.Controllers;
using McFly.Server.Test.Builders;
using Moq;
using Xunit;

namespace McFly.Server.Test.Controllers
{
    public class NoteController_Should
    {
        [Fact]
        public void Create_Note_On_Post()
        {
            // arrange
            var controller = new NoteController();
            var builder = new NoteAccessBuilder();
            controller.NoteAccess = builder.Build();
            var request = new AddNoteRequest(new Position(0, 0), new[] {1}, "hi world");

            // act
            // assert
            controller.Post("testing", request);

            builder.Mock.Verify(access => access.AddNote("testing", new Position(0, 0), new[] {1}, "hi world"),
                Times.Once);
        }
    }
}