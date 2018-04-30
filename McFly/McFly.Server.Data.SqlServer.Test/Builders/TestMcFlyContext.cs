// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer.Test
// Author           : @tysmithnet
// Created          : 04-28-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-28-2018
// ***********************************************************************
// <copyright file="TestMcFlyContext.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Data.Entity;

namespace McFly.Server.Data.SqlServer.Test.Builders
{
    /// <summary>
    ///     Test class for IMcFlyContext
    /// </summary>
    /// <seealso cref="McFly.Server.Data.SqlServer.IMcFlyContext" />
    internal class TestMcFlyContext : IMcFlyContext
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TestMcFlyContext" /> class.
        /// </summary>
        public TestMcFlyContext()
        {
            FrameEntities = new TestDbSet<FrameEntity>();
            TagEntities = new TestDbSet<TagEntity>();
            StackFrameEntities = new TestDbSet<StackFrameEntity>();
            TraceInfoEntities = new TestDbSet<TraceInfoEntity>();
            MemoryChunkEntities = new TestDbSet<MemoryChunkEntity>();
            ByteRangeEntities = new TestDbSet<ByteRangeEntity>();
            FrameTagMappings = new TestDbSet<FrameTagMapping>();
        }

        /// <summary>
        ///     Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            ;
        }

        /// <summary>
        ///     Saves the changes.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public virtual int SaveChanges()
        {
            return 0;
        }

        /// <summary>
        ///     Gets or sets the byte range entities.
        /// </summary>
        /// <value>The byte range entities.</value>
        /// <inheritdoc />
        public DbSet<ByteRangeEntity> ByteRangeEntities { get; set; }

        /// <summary>
        ///     Gets or sets the frame entities.
        /// </summary>
        /// <value>The frame entities.</value>
        public DbSet<FrameEntity> FrameEntities { get; set; }

        /// <inheritdoc />
        public DbSet<FrameTagMapping> FrameTagMappings { get; set; }

        /// <summary>
        ///     Gets or sets the memory chunk entities.
        /// </summary>
        /// <value>The memory chunk entities.</value>
        /// <inheritdoc />
        public DbSet<MemoryChunkEntity> MemoryChunkEntities { get; set; }

        /// <summary>
        ///     Gets or sets the tag entities.
        /// </summary>
        /// <value>The tag entities.</value>
        public DbSet<TagEntity> TagEntities { get; set; }

        /// <summary>
        ///     Gets or sets the stack frame entities.
        /// </summary>
        /// <value>The stack frame entities.</value>
        public DbSet<StackFrameEntity> StackFrameEntities { get; set; }

        /// <summary>
        ///     Gets or sets the trace information entities.
        /// </summary>
        /// <value>The trace information entities.</value>
        public DbSet<TraceInfoEntity> TraceInfoEntities { get; set; }
    }
}