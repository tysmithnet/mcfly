// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer
// Author           : @tysmithnet
// Created          : 04-01-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-01-2018
// ***********************************************************************
// <copyright file="TagEntity.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     Entity that represents a tag taken at a particular point in time
    /// </summary>
    [Table("tag")]
    internal class TagEntity
    {
        /// <summary>
        ///     Gets or sets the create date.
        /// </summary>
        /// <value>The create date.</value>
        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        /// <summary>
        ///     Gets or sets the frame.
        /// </summary>
        /// <value>The frame.</value>
        [ForeignKey("FrameId")]
        public FrameEntity Frame { get; set; }

        // todo: add title/description

        /// <summary>
        ///     Gets or sets the frame identifier.
        /// </summary>
        /// <value>The frame identifier.</value>
        [Column("frame_id")]
        public long FrameId { get; set; }

        /// <summary>
        ///     Gets or sets the tag identifier.
        /// </summary>
        /// <value>The tag identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tag_id")]
        public long TagId { get; set; }

        /// <summary>
        ///     Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [Column("text")]
        public string Text { get; set; }
    }
}