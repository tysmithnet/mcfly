// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer
// Author           : @tysmithnet
// Created          : 04-01-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-01-2018
// ***********************************************************************
// <copyright file="McFlyContext.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Data.Entity;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     Class McFlyContext.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    /// <seealso cref="McFly.Server.Data.SqlServer.IMcFlyContext" />
    internal class McFlyContext : DbContext, IMcFlyContext
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="McFlyContext" /> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public McFlyContext(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        ///     Gets or sets the frame entities.
        /// </summary>
        /// <value>The frame entities.</value>
        public DbSet<FrameEntity> FrameEntities { get; set; }

        /// <summary>
        ///     Gets or sets the note entities.
        /// </summary>
        /// <value>The note entities.</value>
        public DbSet<NoteEntity> NoteEntities { get; set; }

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

        /// <inheritdoc />
        public DbSet<MemoryChunkEntity> MemoryChunkEntities { get; set; }

        /// <inheritdoc />
        public DbSet<ByteRangeEntity> ByteRangeEntities { get; set; }

        /// <summary>
        ///     This method is called when the model for a derived context has been initialized, but
        ///     before the model has been locked down and used to initialize the context.  The default
        ///     implementation of this method does nothing, but it can be overridden in a derived class
        ///     such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        ///     Typically, this method is called only once when the first instance of a derived context
        ///     is created.  The model for that context is then cached and is for all further instances of
        ///     the context in the app domain.  This caching can be disabled by setting the ModelCaching
        ///     property on the given ModelBuidler, but note that this can seriously degrade performance.
        ///     More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        ///     classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FrameEntity>()
                .HasIndex(entity => new
                {
                    entity.PosHi,
                    entity.PosLo,
                    entity.ThreadId
                }).IsUnique(true);

            modelBuilder.Entity<TraceInfoEntity>()
                .HasIndex(entity => entity.Lock)
                .IsUnique(true);
        }
    }
}