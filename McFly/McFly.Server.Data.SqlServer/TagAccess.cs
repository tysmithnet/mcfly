// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tysmithnet
// Created          : 02-20-2018
//
// Last Modified By : @tysmithnet
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
        /// <param name="tag">The text.</param>
        public void AddTag(string projectName, Position position, IEnumerable<int> threadIds, Tag tag)
        {
            threadIds = threadIds.ToList();
            using (var ctx = ContextFactory.GetContext(projectName))
            {
                var frames = ctx.FrameEntities.Where(f =>
                    f.PosHi == position.High && f.PosLo == position.Low && threadIds.Contains(f.ThreadId));
                foreach (var frameEntity in frames)
                    frameEntity.Tags.Add(new TagEntity
                    {
                        CreateDateUtc = DateTime.UtcNow,
                        Title = tag.Title,
                        Body = tag.Body,
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
            var converter = new TagDomainEntityConverter();
            using (var context = ContextFactory.GetContext(projectName))
            {
                var frame = context.FrameEntities.FirstOrDefault(entity =>
                    entity.PosHi == position.High && entity.PosLo == position.Low && entity.ThreadId == threadId);
                return frame?.Tags.Select(x => converter.ToDomain(x, context)).ToList() ?? Enumerable.Empty<Tag>();
            }
        }
    }
}