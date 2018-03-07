// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tsmithnet
// Created          : 02-20-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="DataAccess.cs" company="McFly.Server.Data">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace McFly.Server.Data
{
    /// <summary>
    ///     Class DataAccess.
    /// </summary>
    public abstract class DataAccess
    {
        /// <summary>
        ///     Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public static string ConnectionString { get; set; }

        /// <summary>
        ///     Executes the stored procedure reader.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="procName">Name of the proc.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>SqlDataReader.</returns>
        protected virtual SqlDataReader ExecuteStoredProcedureReader(string projectName, string procName,
            IEnumerable<SqlParameter> parameters)
        {
            using (var conn = new SqlConnection(GetProjectConnectionString(projectName)))
            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = procName;
                command.CommandType = CommandType.StoredProcedure;
                foreach (var sqlParameter in parameters)
                    command.Parameters.Add(sqlParameter);
                return command.ExecuteReader();
            }
        }

        /// <summary>
        ///     Gets the project connection string.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <returns>System.String.</returns>
        protected string GetProjectConnectionString(string projectName)
        {
            var sb = new SqlConnectionStringBuilder(ConnectionString) {InitialCatalog = projectName};
            return sb.ToString();
        }
    }
}