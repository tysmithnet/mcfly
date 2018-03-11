// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tsmithnet
// Created          : 02-20-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="NoteAccess.cs" company="McFly.Server.Data">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using McFly.Core;

namespace McFly.Server.Data
{
    /// <summary>
    ///     Class NoteAccess.
    /// </summary>
    /// <seealso cref="McFly.Server.Data.DataAccess" />
    /// <seealso cref="McFly.Server.Data.INoteAccess" />
    public class NoteAccess : DataAccess, INoteAccess
    {
        public void AddNote(Position position, int threadId, string text)
        {
            
        }
    }
}