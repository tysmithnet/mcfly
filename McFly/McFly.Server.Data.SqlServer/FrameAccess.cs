// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tsmithnet
// Created          : 02-20-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-18-2018
// ***********************************************************************
// <copyright file="FrameAccess.cs" company="McFly.Server.Data">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Common.Logging;
using McFly.Core;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     Represents the data access logic for the frame domain
    /// </summary>
    /// <seealso cref="DataAccess" />
    /// <seealso cref="McFly.Server.Data.IFrameAccess" />
    [Export(typeof(IFrameAccess))]
    [Export(typeof(FrameAccess))]
    internal class FrameAccess : DataAccess, IFrameAccess
    {
        private Common.Logging.ILog Log = LogManager.GetLogger<FrameAccess>(); // todo: fix logging in mcfly

        [Import]
        protected internal IContextFactory ContextFactory { get; set; }

        /// <summary>
        ///     Upserts the frame.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="frames">The frames.</param>
        public void UpsertFrames(string projectName, IEnumerable<Frame> frames)
        {
            frames = frames.ToList();
            using (var context = ContextFactory.GetContext(projectName))
            {
                var existing = context.FrameEntities.Where(e => frames.Any(EntityFrameComparer(e)));
                foreach (var frameEntity in existing)
                {
                    var frame = frames.Single(EntityFrameComparer(frameEntity));
                    var newEntity = frame.ToFrameEntity();
                    CopyValues(newEntity, frameEntity);
                }

                context.SaveChanges();
            }
        }

        private static void CopyValues(FrameEntity newEntity, FrameEntity frameEntity)
        {
            if (newEntity.Rax.HasValue)
                frameEntity.Rax = newEntity.Rax;

            if (newEntity.Rbx.HasValue)
                frameEntity.Rbx = newEntity.Rbx;

            if (newEntity.Rcx.HasValue)
                frameEntity.Rcx = newEntity.Rcx;

            if (newEntity.Rdx.HasValue)
                frameEntity.Rdx = newEntity.Rdx;

            if (newEntity.Address.HasValue)
                frameEntity.Address = newEntity.Address;

            if (newEntity.DisassemblyNote != null)
                frameEntity.DisassemblyNote = newEntity.DisassemblyNote;

            if (newEntity.OpCode != null)
                frameEntity.OpCode = newEntity.OpCode;

            if (newEntity.OpCodeMnemonic != null)
                frameEntity.OpCodeMnemonic = newEntity.DisassemblyNote;

            
        }

        private static Func<Frame, bool> EntityFrameComparer(FrameEntity e)
        {
            return f =>
                f.Position.High == e.PosHi && f.Position.Low == e.PosLo && f.ThreadId == e.ThreadId;
        }
    }
}