// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tsmithnet
// Created          : 02-20-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-12-2018
// ***********************************************************************
// <copyright file="DataAccess.cs" company="McFly.Server.Data">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Data.SqlClient;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     Represents the common data access logic for the application
    /// </summary>
    public abstract class DataAccess
    {
        [Import]
        protected internal Settings Settings { get; set; }

        /// <summary>
        ///     Gets the project connection string.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <returns>System.String.</returns>
        protected string GetProjectConnectionString(string projectName)
        {
            var sb = new SqlConnectionStringBuilder(Settings.ConnectionString)
            {
                InitialCatalog = projectName,
                IntegratedSecurity = true
            };
            return sb.ToString();
        }
    }
}