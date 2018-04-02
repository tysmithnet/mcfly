// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer
// Author           : @tysmithnet
// Created          : 04-01-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-01-2018
// ***********************************************************************
// <copyright file="IMcFlyContext.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data.Entity;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     Interface IMcFlyContext
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    internal interface IMcFlyContext : IDisposable
    {
        /// <summary>
        ///     Gets or sets the frame entities.
        /// </summary>
        /// <value>The frame entities.</value>
        DbSet<FrameEntity> FrameEntities { get; set; }

        /// <summary>
        ///     Gets or sets the note entities.
        /// </summary>
        /// <value>The note entities.</value>
        DbSet<NoteEntity> NoteEntities { get; set; }

        /// <summary>
        ///     Gets or sets the stack frame entities.
        /// </summary>
        /// <value>The stack frame entities.</value>
        DbSet<StackFrameEntity> StackFrameEntities { get; set; }

        /// <summary>
        ///     Gets or sets the trace information entities.
        /// </summary>
        /// <value>The trace information entities.</value>
        DbSet<TraceInfoEntity> TraceInfoEntities { get; set; }

        /// <summary>
        ///     Saves the changes.
        /// </summary>
        /// <returns>System.Int32.</returns>
        int SaveChanges();
    }
}