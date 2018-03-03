using System.Collections.Generic;
using McFly.Core;

namespace McFly.Server.Data
{
    public interface IProjectsAccess
    {
        IEnumerable<string> GetDatabases();
        void CreateProject(string projectName, Position start, Position end);
    }
}