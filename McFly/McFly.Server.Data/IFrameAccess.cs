// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tysmithnet
// Created          : 02-20-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 05-09-2018
// ***********************************************************************
// <copyright file="IFrameAccess.cs" company="McFly.Server.Data">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using McFly.Core;
using McFly.Server.Core;
using McFly.Server.Data.Search;

namespace McFly.Server.Data
{
    /// <summary>
    ///     Represents an object that is capable of managing the data access for the frame domain
    /// </summary>
    public interface IFrameAccess
    {
        /// <summary>
        ///     Creates the search.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="request">The request.</param>
        /// <returns>Guid.</returns>
        Guid CreateSearch(string projectName, CreateFrameSearchRequest request);

        /// <summary>
        ///     Gets the frame.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="position">The position.</param>
        /// <param name="threadId">The thread identifier.</param>
        /// <returns>Frame.</returns>
        Frame GetFrame(string projectName, Position position, int threadId);

        /// <summary>
        ///     Gets the search results.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="searchId">The search identifier.</param>
        /// <returns>IEnumerable&lt;Frame&gt;.</returns>
        IEnumerable<Frame> GetSearchResults(string projectName, Guid searchId);

        /// <summary>
        ///     Searches the specified project name.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="criterion">The criterion.</param>
        /// <returns>IEnumerable&lt;Frame&gt;.</returns>
        IEnumerable<Frame> Search(string projectName, ICriterion criterion);

        /// <summary>
        ///     Upserts the frame.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="frames">The frames.</param>
        void UpsertFrames(string projectName, IEnumerable<Frame> frames);
    }
}