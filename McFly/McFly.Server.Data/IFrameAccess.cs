// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tsmithnet
// Created          : 02-20-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="IFrameAccess.cs" company="McFly.Server.Data">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using McFly.Core;

namespace McFly.Server.Data
{
    /// <summary>
    ///     Interface IFrameAccess
    /// </summary>
    public interface IFrameAccess
    {
        /// <summary>
        ///     Upserts the frame.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="frame">The frame.</param>
        void UpsertFrames(string projectName, IEnumerable<Frame> frames);
    }
}