// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tsmithnet
// Created          : 02-20-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 04-29-2018
// ***********************************************************************
// <copyright file="ITagAccess.cs" company="McFly.Server.Data">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using McFly.Core;

namespace McFly.Server.Data
{
    /// <summary>
    ///     Represents an object that is capable for managing the data access for the tag domain
    /// </summary>
    public interface ITagAccess
    {
        /// <summary>
        ///     Adds a tag to a thread position
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="position">The position.</param>
        /// <param name="threadIds">The thread ids.</param>
        /// <param name="text">The text.</param>
        void AddTag(string projectName, Position position, IEnumerable<int> threadIds, string text); // todo: title
    }
}