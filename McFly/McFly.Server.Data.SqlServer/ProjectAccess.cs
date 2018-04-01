// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tsmithnet
// Created          : 02-20-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-15-2018
// ***********************************************************************
// <copyright file="ProjectsAccess.cs" company="McFly.Server.Data">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Common.Logging;
using McFly.Core;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     IProjectsAccess implementation that uses SqlServer
    /// </summary>
    /// <seealso cref="DataAccess" />
    /// <seealso cref="McFly.Server.Data.IProjectsAccess" />
    [Export(typeof(IProjectsAccess))]
    [Export(typeof(ProjectsAccess))]
    [ExcludeFromCodeCoverage]
    public class ProjectsAccess : DataAccess, IProjectsAccess
    {
        /// <summary>
        ///     Gets the log.
        /// </summary>
        /// <value>The log.</value>
        private ILog Log { get; } = LogManager.GetLogger<ProjectsAccess>();

        /// <summary>
        ///     Gets the databases.
        /// </summary>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        public IEnumerable<string> GetDatabases()
        {
            using (var conn = new SqlConnection(Settings.ConnectionString))
            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText =
                    "SELECT NAME FROM sys.databases WHERE NAME NOT IN('master', 'tempdb', 'model', 'msdb')";
                var databases = new List<string>();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    databases.Add(reader.GetFieldValue<string>(0));
                return databases;
            }
        }

        /// <summary>
        ///     Creates the project.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        public void CreateProject(string projectName, Position start, Position end)
        {
            var executingAssembly = Assembly.GetExecutingAssembly().Location;

            string scriptFileName;
            try
            {
                scriptFileName = Path.Combine(Path.GetDirectoryName(executingAssembly), "McFly.SqlServer_Create.sql");
            }
            catch (Exception e)
            {
                Log.Error($"Failed opening dacpac.. is the file name correct?: {e.GetType()} - {e.Message}");
                throw;
            }

            using (var conn = new SqlConnection(Settings.ConnectionString))
            {
                try
                {
                    conn.Open();
                    string initScript = null;
                    using (var stream = File.OpenRead(scriptFileName))
                    using (var reader = new StreamReader(stream))
                    {
                        initScript = reader.ReadToEnd();
                    }

                    initScript = Regex.Replace(initScript, @":setvar DatabaseName ""McFly\.SqlServer""",
                        $@":setvar DatabaseName ""{projectName}""");

                    var variableDefinitions = Regex.Matches(initScript, @":setvar (?<name>\w+) ""(?<val>.*)""");

                    foreach (Match match in variableDefinitions)
                        initScript = initScript.Replace($@"$({match.Groups["name"].Value})", match.Groups["val"].Value);

                    initScript = Regex.Replace(initScript, @":.*", "");

                    var batches = Regex.Split(initScript, @"\s*GO\s*", RegexOptions.IgnoreCase)
                        .Where(x => !string.IsNullOrWhiteSpace(x));

                    foreach (var batch in batches)
                        using (var createCommand = conn.CreateCommand())
                        {
                            createCommand.CommandText = batch; // todo: error handling
                            createCommand.ExecuteNonQuery();
                        }

                    using (var infoCommand = conn.CreateCommand())
                    {
                        infoCommand.CommandText =
                            $"INSERT INTO trace_info (start_pos_hi, start_pos_lo, end_pos_hi, end_pos_lo) VALUES ({start.High}, {start.Low}, {end.High}, {end.Low})";
                        infoCommand.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    using (var singleUser = conn.CreateCommand())
                    using (var deleteCommand = conn.CreateCommand())
                    {
                        singleUser.CommandText =
                            $"ALTER DATABASE [{projectName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                        singleUser.ExecuteNonQuery();

                        deleteCommand.CommandText = $"DROP DATABASE {projectName}"; // todo: close connections
                        deleteCommand.ExecuteNonQuery();
                        throw;
                    }
                }
            }
        }
    }
}