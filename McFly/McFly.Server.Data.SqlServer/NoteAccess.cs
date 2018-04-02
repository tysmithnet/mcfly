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

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
        [Import]
        internal IContextFactory ContextFactory { get; set; }

        /// <summary>
        ///     Adds a note to a thread position
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="text">The text.</param>
        public void AddNote(string projectName, Position position, IEnumerable<int> threadIds, string text)
        {
            threadIds = threadIds.ToList();
            using (var ctx = ContextFactory.GetContext(projectName))
            {
                var frames = ctx.FrameEntities.Where(f =>
                    f.PosHi == position.High && f.PosLo == position.Low && threadIds.Contains(f.ThreadId));
                foreach (var frameEntity in frames)
                {
                    frameEntity.Notes.Add(new NoteEntity()
                    {
                        CreateDate = DateTime.UtcNow,
                        Text = text
                    });
                }
                ctx.SaveChanges();
            }
        }

        public IEnumerable<Note> GetNotes(string projectName, Position position, int threadId)
        {
            using (var ctx = ContextFactory.GetContext(projectName))
            {
                var frame = ctx.FrameEntities.FirstOrDefault(entity =>
                    entity.PosHi == position.High && entity.PosLo == position.Low && entity.ThreadId == threadId);
                return frame.Notes.Select(x => x.ToNote());
            }
        }
    }
}