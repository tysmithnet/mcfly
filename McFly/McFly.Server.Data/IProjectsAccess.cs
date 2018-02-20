using System.Collections.Generic;

namespace McFly.Server.Data
{
    public interface IProjectsAccess
    {
        IEnumerable<string> GetDatabases();
    }
}