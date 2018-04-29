// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tsmithnet
// Created          : 02-20-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 04-01-2018
// ***********************************************************************
// <copyright file="TagAccess.cs" company="McFly.Server.Data">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using McFly.Core;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     ITagAccess implementation that uses SQL Server
    /// </summary>
    /// <seealso cref="McFly.Server.Data.SqlServer.DataAccess" />
    /// <seealso cref="DataAccess" />
    /// <seealso cref="ITagAccess" />
    [Export(typeof(ITagAccess))]
    internal class TagAccess : DataAccess, ITagAccess
    {
        /// <summary>
        ///     Gets or sets the context factory.
        /// </summary>
        /// <value>The context factory.</value>
        [Import]
        internal IContextFactory ContextFactory { get; set; }

        /// <summary>
        ///     Adds a tag to a thread position
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="position">The position.</param>
        /// <param name="threadIds">The thread ids.</param>
        /// <param name="text">The text.</param>
        public void AddTag(string projectName, Position position, IEnumerable<int> threadIds, string text)
        {
            threadIds = threadIds.ToList();
            using (var ctx = ContextFactory.GetContext(projectName))
            {
                var frames = ctx.FrameEntities.Where(f =>
                    f.PosHi == position.High && f.PosLo == position.Low && threadIds.Contains(f.ThreadId));
                foreach (var frameEntity in frames)
                    frameEntity.Tags.Add(new TagEntity
                    {
                        CreateDate = DateTime.UtcNow,
                        Text = text
                    });
                ctx.SaveChanges();
            }
        }

        /// <summary>
        ///     Gets the tags.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="position">The position.</param>
        /// <param name="threadId">The thread identifier.</param>
        /// <returns>IEnumerable&lt;Tag&gt;.</returns>
        public IEnumerable<Tag> GetTags(string projectName, Position position, int threadId)
        {
            using (var ctx = ContextFactory.GetContext(projectName))
            {
                var frame = ctx.FrameEntities.FirstOrDefault(entity =>
                    entity.PosHi == position.High && entity.PosLo == position.Low && entity.ThreadId == threadId);
                return null;
            }
        }
    }
}