// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer
// Author           : @tysmithnet
// Created          : 04-29-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-29-2018
// ***********************************************************************
// <copyright file="FrameTagMapping.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.DataAnnotations.Schema;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     Linking table between Frame and Tag
    /// </summary>
    [Table("frame_tag")]
    internal class FrameTagMapping
    {
        /// <summary>
        ///     Gets or sets the frame.
        /// </summary>
        /// <value>The frame.</value>
        public virtual FrameEntity Frame { get; set; }

        /// <summary>
        ///     Gets or sets the frame identifier.
        /// </summary>
        /// <value>The frame identifier.</value>
        [Column("frame_id")]
        public long FrameId { get; set; }

        /// <summary>
        ///     Gets or sets the tag.
        /// </summary>
        /// <value>The tag.</value>
        public virtual TagEntity Tag { get; set; }

        /// <summary>
        ///     Gets or sets the tag identifier.
        /// </summary>
        /// <value>The tag identifier.</value>
        [Column("tag_id")]
        public long TagId { get; set; }
    }
}