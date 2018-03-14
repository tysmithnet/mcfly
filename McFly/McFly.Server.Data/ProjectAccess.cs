// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tsmithnet
// Created          : 02-20-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
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
using System.IO;
using System.Reflection;
using Common.Logging;
using McFly.Core;
using Microsoft.Extensions.Logging;
using Microsoft.SqlServer.Dac;

namespace McFly.Server.Data
{
    /// <summary>
    ///     Class ProjectsAccess.
    /// </summary>
    /// <seealso cref="McFly.Server.Data.DataAccess" />
    /// <seealso cref="McFly.Server.Data.IProjectsAccess" />
    [Export(typeof(IProjectsAccess))]
    [Export(typeof(ProjectsAccess))]
    public class ProjectsAccess : DataAccess, IProjectsAccess
    {
        private ILog Log { get; set; } = LogManager.GetLogger<ProjectsAccess>();
          

        /// <summary>
        ///     Gets the databases.
        /// </summary>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        public IEnumerable<string> GetDatabases()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                var command = conn.CreateCommand();
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
            DacPackage dacPac;
            try
            {
                var dacPacFileName = Path.Combine(Path.GetDirectoryName(executingAssembly), "McFly.SqlServer.dacpac");
                dacPac = DacPackage.Load(dacPacFileName);
            }
            catch (Exception e)
            {
                Log.Error($"Failed opening dacpac.. is the file name correct?: {e.GetType()} - {e.Message}");
                throw;
            }

            DacServices dbServices;
            try
            {
                var sb = new SqlConnectionStringBuilder();
                var sb2 = new SqlConnectionStringBuilder(ConnectionString);
                sb.DataSource = sb2.DataSource;
                sb.IntegratedSecurity = true;
                dbServices = new DacServices(sb.ToString());
            }
            catch (Exception e) 
            {
                Log.Error($"Failed creating DAC Services.. is your connection correct?: {e.GetType()} - {e.Message}");
                throw;
            }

            try
            {
                dbServices.Deploy(dacPac, projectName, false, new DacDeployOptions(){});
            }
            catch (Exception e)
            {
                Log.Error($"Failed deploying dacpac.. do you have errors in your scripts? Do you have permission?: {e.GetType()} - {e.Message}");
                throw;
            }
           
            // todo: try to delete database after fail
        }
    }
}