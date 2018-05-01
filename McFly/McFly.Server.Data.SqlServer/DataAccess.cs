// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tysmithnet
// Created          : 02-20-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-01-2018
// ***********************************************************************
// <copyright file="DataAccess.cs" company="McFly.Server.Data">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.Composition;
using System.Data.SqlClient;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     Represents the common data access logic for the application
    /// </summary>
    public abstract class DataAccess
    {
        /// <summary>
        ///     Gets or sets the settings.
        /// </summary>
        /// <value>The settings.</value>
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