// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer
// Author           : @tysmithnet
// Created          : 04-21-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-25-2018
// ***********************************************************************
// <copyright file="MemoryChunkEntity.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     Entity that represents a slice of memory at a point in time
    /// </summary>
    [Table("memory_chunk")]
    internal class MemoryChunkEntity
    {
        /// <summary>
        ///     Gets or sets the byte range for this entity
        /// </summary>
        /// <value>The byte range.</value>
        [ForeignKey("ByteRangeId")]
        public virtual ByteRangeEntity ByteRange { get; set; }

        /// <summary>
        ///     Gets or sets the byte range identifier.
        /// </summary>
        /// <value>The byte range identifier.</value>
        [Column("byte_range_id")]
        public long ByteRangeId { get; set; }

        /// <summary>
        ///     Gets or sets the high address of the position
        /// </summary>
        /// <value>The high address.</value>
        [MaxLength(16)]
        [RegularExpression("^[a-fA-F0-9]+$")]
        [Column("high_address")]
        public string HighAddress { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        ///     Gets or sets the low address.
        /// </summary>
        /// <value>The low address.</value>
        [MaxLength(16)]
        [RegularExpression("^[a-fA-F0-9]+$")]
        [Column("low_address")]
        public string LowAddress { get; set; }

        /// <summary>
        ///     Gets or sets the position hi.
        /// </summary>
        /// <value>The position hi.</value>
        [Column("pos_hi")]
        public int PosHi { get; set; } // todo: index over position columns

        /// <summary>
        ///     Gets or sets the position lo.
        /// </summary>
        /// <value>The position lo.</value>
        [Column("pos_lo")]
        public int PosLo { get; set; }

        /// <summary>
        ///     Gets or sets the length of the subsection.
        /// </summary>
        /// <value>The length of the subsection.</value>
        [Column("subsection_length")]
        public long SubsectionLength { get; set; }

        /// <summary>
        ///     Gets or sets the start index of the subsection. This should be used
        ///     in conjunction with the byte range to get the memory chunks bytes.
        ///     memoryChunkBytes = entity.Bytes.Substring(SubsectionStartIndex, SubsectionLength)
        /// </summary>
        /// <value>The start index of the subsection.</value>
        [Column("subsection_start_index")]
        public long SubsectionStartIndex { get; set; }
    }
}