// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer
// Author           : @tysmithnet
// Created          : 04-01-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-01-2018
// ***********************************************************************
// <copyright file="FrameEntity.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     Class FrameEntity.
    /// </summary>
    [Table("frame")]
    internal class FrameEntity
    {
        /// <summary>
        ///     Gets or sets the frame identifier.
        /// </summary>
        /// <value>The frame identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("frame_id")]
        public long FrameId { get; set; }

        /// <summary>
        ///     Gets or sets the position hi.
        /// </summary>
        /// <value>The position hi.</value>
        [Column("pos_hi")]
        public int PosHi { get; set; }

        /// <summary>
        ///     Gets or sets the position lo.
        /// </summary>
        /// <value>The position lo.</value>
        [Column("pos_lo")]
        public int PosLo { get; set; }

        /// <summary>
        ///     Gets or sets the thread identifier.
        /// </summary>
        /// <value>The thread identifier.</value>
        [Column("thread_id")]
        public int ThreadId { get; set; }

        /// <summary>
        ///     Gets or sets the rax.
        /// </summary>
        /// <value>The rax.</value>
        [Column("rax", TypeName = "binary")]
        [MaxLength(8)]
        [MinLength(8)]
        public byte[] Rax { get; set; }

        /// <summary>
        ///     Gets or sets the RBX.
        /// </summary>
        /// <value>The RBX.</value>
        [Column("rbx", TypeName = "binary")]
        [MaxLength(8)]
        [MinLength(8)]
        public byte[] Rbx { get; set; }

        /// <summary>
        ///     Gets or sets the RCX.
        /// </summary>
        /// <value>The RCX.</value>
        [Column("rcx", TypeName = "binary")]
        [MaxLength(8)]
        [MinLength(8)]
        public byte[] Rcx { get; set; }

        /// <summary>
        ///     Gets or sets the RDX.
        /// </summary>
        /// <value>The RDX.</value>
        [Column("rdx", TypeName = "binary")]
        [MaxLength(8)]
        [MinLength(8)]
        public byte[] Rdx { get; set; }

        /// <summary>
        ///     Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        [Column("address", TypeName = "binary")]
        [MaxLength(8)]
        [MinLength(8)]
        public byte[] Rip { get; set; }

        /// <summary>
        ///     Gets or sets the op code.
        /// </summary>
        /// <value>The op code.</value>
        [Column("opcode")]
        public byte[] OpCode { get; set; }

        /// <summary>
        ///     Gets or sets the op code mnemonic.
        /// </summary>
        /// <value>The op code mnemonic.</value>
        [Column("opcode_mnemonic")]
        public string OpCodeMnemonic { get; set; }

        /// <summary>
        ///     Gets or sets the disassembly note.
        /// </summary>
        /// <value>The disassembly note.</value>
        [Column("disassembly_note")]
        public string DisassemblyNote { get; set; }

        /// <summary>
        ///     Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        public virtual List<NoteEntity> Notes { get; set; } = new List<NoteEntity>();

        /// <summary>
        ///     Gets or sets the stack frames.
        /// </summary>
        /// <value>The stack frames.</value>
        public virtual List<StackFrameEntity> StackFrames { get; set; } = new List<StackFrameEntity>();
    }
}