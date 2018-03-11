// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tsmithnet
// Created          : 02-20-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="INoteAccess.cs" company="McFly.Server.Data">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using McFly.Core;

namespace McFly.Server.Data
{
    /// <summary>
    ///     Interface INoteAccess
    /// </summary>
    public interface INoteAccess
    {
        /// <summary>
        ///     Adds a note to a thread position
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="text">The text.</param>
        void AddNote(Position position, int threadId, string text);
    }
}