﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace McFly.Server.Data
{
    public class ProjectsAccess : DataAccess, IProjectsAccess
    {
        public IEnumerable<string> GetDatabases()
        {
            using (var conn = new SqlConnection(ConnectionString))
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

        public void CreateProject(string projectName)
        {
            using (var conn = new SqlConnection(ConnectionString))
            using (var createDbCommand = conn.CreateCommand())
            {
                conn.Open();
                createDbCommand.CommandText = $"CREATE DATABASE {projectName}";
                createDbCommand.ExecuteNonQuery();

                try
                {
                    var initScript = File.ReadAllText("Scripts/create_database.sql");
                    IEnumerable<string> commandStrings = Regex.Split(initScript, @"^\s*GO\s*$",
                        RegexOptions.Multiline | RegexOptions.IgnoreCase);
                    foreach (var commandString in commandStrings)
                    {
                        if (string.IsNullOrWhiteSpace(commandString))
                            continue;
                        using (var command = conn.CreateCommand())
                        {
                            command.CommandText = commandString;
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (SqlException e)
                {
                    using (var deleteCommand = conn.CreateCommand())
                    {
                        deleteCommand.CommandText = $"DROP DATABASE {projectName}";
                        deleteCommand.ExecuteNonQuery();
                        throw;
                    }
                }
            }
        }
    }
}
