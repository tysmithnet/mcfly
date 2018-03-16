using System.Collections.Generic;
using McFly.Server.Data;
using Moq;

namespace McFly.Server.Test
{
    public class ProjectAccessBuilder
    {
        internal Mock<IProjectsAccess> Mock { get; set; }= new Mock<IProjectsAccess>();

        public ProjectAccessBuilder WhenGetDatabases(IEnumerable<string> databases)
        {
            Mock.Setup(access => access.GetDatabases()).Returns(databases);
            return this;
        }

        public IProjectsAccess Build()
        {
            return Mock.Object;
        }
    }
}