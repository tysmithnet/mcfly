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
        [Column("create_date_utc")]
        public DateTime CreateDateUtc { get; set; }

        /// <summary>
        ///     Gets or sets the tag identifier.
        /// </summary>
        /// <value>The tag identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tag_id")]
        public long TagId { get; set; }

        /// <summary>
        ///     Gets or sets the title of the tag
        /// </summary>
        /// <value>The text.</value>
        [Column("title")]
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets the body of the tag
        /// </summary>
        /// <value>The body.</value>
        [Column("body")]
        public string Body { get; set; }
    }
}