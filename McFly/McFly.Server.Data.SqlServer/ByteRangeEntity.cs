// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer
// Author           : @tysmithnet
// Created          : 04-21-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-22-2018
// ***********************************************************************
// <copyright file="ByteRangeEntity.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     Class ByteRangeEntity.
    /// </summary>
    [Table("byte_range")]
    public class ByteRangeEntity
    {
        /// <summary>
        ///     Gets or sets the bytes.
        /// </summary>
        /// <value>The bytes.</value>
        [Column("bytes")]
        public string Bytes { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }
    }
}