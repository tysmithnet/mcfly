using FluentAssertions;
using McFly.Core;
using McFly.Server.Contract;
using McFly.Server.Controllers;
using Moq;
using Xunit;

namespace McFly.Server.Test
{
    public class ProjectController_Should
    {
        [Fact]
        public void Create_Project_From_Request()
        {
            // arrange
            var builder = new ProjectAccessBuilder();
            var controller = new ProjectController();
            controller.ProjectsAccess = builder.Build();
            var request = new NewProjectRequest("testing", "0:0", "1:1");

            // act
            var actionResult = controller.Post(request);

            // assert
            builder.Mock.Verify(access => access.CreateProject("testing", new Position(0, 0), new Position(1, 1)),
                Times.Once);
        }

        [Fact]
        public void Get_Return_The_Available_Database_Names()
        {
            // arrange
            var builder = new ProjectAccessBuilder();
            string[] dbs = {"test", "ABC", "015"};
            builder.WhenGetDatabases(dbs);
            var access = builder.Build();
            var controller = new ProjectController {ProjectsAccess = access};

            // act
            var databases = controller.Get();

            // assert
            databases.Content.Should().Equal(dbs);
        }
    }
}