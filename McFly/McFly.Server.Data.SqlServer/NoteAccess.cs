// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tsmithnet
// Created          : 02-20-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-12-2018
// ***********************************************************************
// <copyright file="NoteAccess.cs" company="McFly.Server.Data">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Data.SqlClient;
using McFly.Core;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     INoteAccess implementation that uses SQL Server
    /// </summary>
    /// <seealso cref="DataAccess" />
    /// <seealso cref="McFly.Server.Data.INoteAccess" />
    [Export(typeof(INoteAccess))]
    public class NoteAccess : DataAccess, INoteAccess
    {
        /// <summary>
        ///     Adds a note to a thread position
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="text">The text.</param>
        public void AddNote(string projectName, Position position, IEnumerable<int> threadIds, string text)
        {
           
        }
    }
}