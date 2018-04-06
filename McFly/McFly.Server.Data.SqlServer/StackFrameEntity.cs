// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer
// Author           : @tysmithnet
// Created          : 04-01-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-01-2018
// ***********************************************************************
// <copyright file="StackFrameEntity.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     Class StackFrameEntity.
    /// </summary>
    [Table("stack_frame")]
    internal class StackFrameEntity
    {
        /// <summary>
        ///     Gets or sets the stack frame identifier.
        /// </summary>
        /// <value>The stack frame identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long StackFrameId { get; set; }

        /// <summary>
        ///     Gets or sets the stack pointer.
        /// </summary>
        /// <value>The stack pointer.</value>
        [Column("stack_pointer")]
        [MinLength(8)]
        [MaxLength(16)]
        public string StackPointer { get; set; }

        /// <summary>
        ///     Gets or sets the return address.
        /// </summary>
        /// <value>The return address.</value>
        [Column("return_address")]
        [MinLength(8)]
        [MaxLength(16)]
        public string ReturnAddress { get; set; }

        /// <summary>
        ///     Gets or sets the name of the module.
        /// </summary>
        /// <value>The name of the module.</value>
        [Column("module_name")]
        public string ModuleName { get; set; }

        /// <summary>
        ///     Gets or sets the function.
        /// </summary>
        /// <value>The function.</value>
        [Column("function")]
        public string Function { get; set; }

        /// <summary>
        ///     Gets or sets the offset.
        /// </summary>
        /// <value>The offset.</value>
        [Column("offset")]
        public long Offset { get; set; }

        /// <summary>
        ///     Gets or sets the frame identifier.
        /// </summary>
        /// <value>The frame identifier.</value>
        [Column("frame_id")]
        public long FrameId { get; set; }

        /// <summary>
        ///     Gets or sets the frame.
        /// </summary>
        /// <value>The frame.</value>
        [ForeignKey("FrameId")]
        public FrameEntity Frame { get; set; }
    }
}