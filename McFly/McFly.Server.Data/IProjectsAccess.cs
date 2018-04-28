// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tsmithnet
// Created          : 02-20-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-12-2018
// ***********************************************************************
// <copyright file="IProjectsAccess.cs" company="McFly.Server.Data">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using McFly.Core;

namespace McFly.Server.Data
{
    /// <summary>
    ///     Represents an object is capable of handing the data access to the project domain
    /// </summary>
    public interface IProjectsAccess
    {
        /// <summary>
        ///     Gets the databases.
        /// </summary>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        IEnumerable<string> GetProjects();

        /// <summary>
        ///     Creates the project.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        void CreateProject(string projectName, Position start, Position end);
    }
}