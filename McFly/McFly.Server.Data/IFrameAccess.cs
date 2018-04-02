// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tsmithnet
// Created          : 02-20-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-12-2018
// ***********************************************************************
// <copyright file="IFrameAccess.cs" company="McFly.Server.Data">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using McFly.Core;
using McFly.Server.Data.Search;

namespace McFly.Server.Data
{
    /// <summary>
    ///     Represents an object that is capable of managing the data access for the frame domain
    /// </summary>
    public interface IFrameAccess
    {
        /// <summary>
        ///     Upserts the frame.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="frames">The frames.</param>
        void UpsertFrames(string projectName, IEnumerable<Frame> frames);

        Frame GetFrame(string projectName, Position position, int threadId);

        IEnumerable<Frame> Search(ICriterion criterion);
    }
}