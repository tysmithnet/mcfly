// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tsmithnet
// Created          : 02-21-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="Options.cs" company="McFly.Server">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using CommandLine;

namespace McFly.Server
{
    /// <summary>
    ///     Class Options.
    /// </summary>
    public class Options
    {
        /// <summary>
        ///     Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        [Option('c', "connectionstring", HelpText = "Connection string for the database to use")]
        public string ConnectionString { get; set; }
    }
}