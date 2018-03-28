using System.Web.Http;
using McFly.Core;
using McFly.Server.Controllers;
using Moq;
using Xunit;

namespace McFly.Server.Test
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

            // act
            // assert
            controller.Post("testing", new Position(0, 0), 1, "hi world");

            builder.Mock.Verify(access => access.AddNote("testing", new Position(0,0), 1, "hi world"), Times.Once);
        }
    }
}