// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tsmithnet
// Created          : 02-20-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 04-01-2018
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
using System.Linq;
using Common.Logging;
using McFly.Core;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     IProjectsAccess implementation that uses SqlServer
    /// </summary>
    /// <seealso cref="McFly.Server.Data.SqlServer.DataAccess" />
    /// <seealso cref="DataAccess" />
    /// <seealso cref="McFly.Server.Data.IProjectsAccess" />
    [Export(typeof(IProjectsAccess))]
    [Export(typeof(ProjectsAccess))]
    internal class ProjectsAccess : DataAccess, IProjectsAccess
    {
        /// <summary>
        ///     Creates a new project
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="start">The starting index of the trace.</param>
        /// <param name="end">The ending index of the trace.</param>
        public void CreateProject(string projectName, Position start, Position end)
        {
            using (var context = ContextFactory.GetContext(projectName))
            {
                // forces a new database to be created
                var traceInfo = new TraceInfoEntity
                {
                    Lock = 1,
                    CreateDate = DateTime.UtcNow,
                    StartPosHi = start.High,
                    StartPosLo = start.Low,
                    EndPosHi = end.High,
                    EndPosLo = end.Low
                };
                context.TraceInfoEntities.Add(traceInfo);
                context.SaveChanges(); // todo: error checking
            }
        }

        /// <summary>
        ///     Gets the names of all projects that exist
        /// </summary>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        public IEnumerable<string> GetProjects()
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
                return databases.Where(s => s.StartsWith("mcfly_"));
            }
        }

        /// <summary>
        ///     Gets or sets the context factory.
        /// </summary>
        /// <value>The context factory.</value>
        [Import]
        protected internal IContextFactory ContextFactory { get; set; }

        /// <summary>
        ///     Gets the log.
        /// </summary>
        /// <value>The log.</value>
        private static ILog Log { get; } = LogManager.GetLogger<ProjectsAccess>();
    }
}