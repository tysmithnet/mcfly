using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace McFly.Server.Data
{
    public class ProjectsAccess : IProjectsAccess
    {
        public IEnumerable<string> GetDatabases()
        {
            using (var conn = new SqlConnection(DataAccess.ConnectionString))
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = "SELECT NAME FROM sys.databases WHERE NAME NOT IN('master', 'tempdb', 'model', 'msdb')";
                List<string> databases = new List<string>();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    databases.Add(reader.GetFieldValue<string>(0));
                }
                return databases;
            }
        }
    }
}
