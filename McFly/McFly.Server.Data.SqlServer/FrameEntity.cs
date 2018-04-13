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

        [Column("brfrom")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Brfrom { get; set; }

        [Column("brto")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Brto { get; set; }

        [Column("cs")]
        [MaxLength(4)]
        [MinLength(4)]
        public string Cs { get; set; }

        [Column("dr0")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Dr0 { get; set; }

        [Column("dr1")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Dr1 { get; set; }

        [Column("dr2")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Dr2 { get; set; }

        [Column("dr3")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Dr3 { get; set; }

        [Column("dr6")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Dr6 { get; set; }

        [Column("dr7")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Dr7 { get; set; }

        [Column("ds")]
        [MaxLength(4)]
        [MinLength(4)]
        public string Ds { get; set; }

        [Column("efl")]
        [MaxLength(8)]
        [MinLength(8)]
        public string Efl { get; set; }

        [Column("es")]
        [MaxLength(4)]
        [MinLength(4)]
        public string Es { get; set; }

        [Column("exfrom")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Exfrom { get; set; }

        [Column("exto")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Exto { get; set; }

        [Column("fpcw")]
        [MaxLength(4)]
        [MinLength(4)]
        public string Fpcw { get; set; }

        [Column("fpsw")]
        [MaxLength(4)]
        [MinLength(4)]
        public string Fpsw { get; set; }

        [Column("fptw")]
        [MaxLength(4)]
        [MinLength(4)]
        public string Fptw { get; set; }

        [Column("fopcode")]
        [MaxLength(4)]
        [MinLength(4)]
        public string Fopcode { get; set; }

        [Column("fpip")]
        [MaxLength(4)]
        [MinLength(4)]
        public string Fpip { get; set; }

        [Column("fpipsel")]
        [MaxLength(4)]
        [MinLength(4)]
        public string Fpipsel { get; set; }

        [Column("fpdp")]
        [MaxLength(4)]
        [MinLength(4)]
        public string Fpdp { get; set; }

        [Column("fpdpsel")]
        [MaxLength(4)]
        [MinLength(4)]
        public string Fpdpsel { get; set; }

        [Column("fs")]
        [MaxLength(4)]
        [MinLength(4)]
        public string Fs { get; set; }

        [Column("gs")]
        [MaxLength(4)]
        [MinLength(4)]
        public string Gs { get; set; }

        [Column("mm0")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Mm0 { get; set; }

        [Column("mm1")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Mm1 { get; set; }

        [Column("mm2")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Mm2 { get; set; }

        [Column("mm3")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Mm3 { get; set; }

        [Column("mm4")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Mm4 { get; set; }

        [Column("mm5")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Mm5 { get; set; }

        [Column("mm6")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Mm6 { get; set; }

        [Column("mm7")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Mm7 { get; set; }

        [Column("mxcsr")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Mxcsr { get; set; }

        [Column("st0")]
        [MaxLength(20)]
        [MinLength(20)]
        public string St0 { get; set; }

        [Column("st1")]
        [MaxLength(20)]
        [MinLength(20)]
        public string St1 { get; set; }

        [Column("st2")]
        [MaxLength(20)]
        [MinLength(20)]
        public string St2 { get; set; }

        [Column("st3")]
        [MaxLength(20)]
        [MinLength(20)]
        public string St3 { get; set; }

        [Column("st4")]
        [MaxLength(20)]
        [MinLength(20)]
        public string St4 { get; set; }

        [Column("st5")]
        [MaxLength(20)]
        [MinLength(20)]
        public string St5 { get; set; }

        [Column("st6")]
        [MaxLength(20)]
        [MinLength(20)]
        public string St6 { get; set; }

        [Column("st7")]
        [MaxLength(20)]
        [MinLength(20)]
        public string St7 { get; set; }

        [Column("r10")]
        [MaxLength(16)]
        [MinLength(16)]
        public string R10 { get; set; }

        [Column("r11")]
        [MaxLength(16)]
        [MinLength(16)]
        public string R11 { get; set; }

        [Column("r12")]
        [MaxLength(16)]
        [MinLength(16)]
        public string R12 { get; set; }

        [Column("r13")]
        [MaxLength(16)]
        [MinLength(16)]
        public string R13 { get; set; }

        [Column("r14")]
        [MaxLength(16)]
        [MinLength(16)]
        public string R14 { get; set; }

        [Column("r15")]
        [MaxLength(16)]
        [MinLength(16)]
        public string R15 { get; set; }

        [Column("r8")]
        [MaxLength(16)]
        [MinLength(16)]
        public string R8 { get; set; }

        [Column("r9")]
        [MaxLength(16)]
        [MinLength(16)]
        public string R9 { get; set; }

        [Column("rax")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Rax { get; set; }

        [Column("rbp")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Rbp { get; set; }

        [Column("rbx")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Rbx { get; set; }

        [Column("rcx")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Rcx { get; set; }

        [Column("rdi")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Rdi { get; set; }

        [Column("rdx")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Rdx { get; set; }

        [Column("rip")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Rip { get; set; }

        [Column("rsi")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Rsi { get; set; }

        [Column("rsp")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Rsp { get; set; }

        [Column("ss")]
        [MaxLength(4)]
        [MinLength(4)]
        public string Ss { get; set; }

        [Column("ymm0")]
        [MaxLength(32)]
        [MinLength(32)]
        public string Ymm0 { get; set; }

        [Column("ymm1")]
        [MaxLength(32)]
        [MinLength(32)]
        public string Ymm1 { get; set; }

        [Column("ymm2")]
        [MaxLength(32)]
        [MinLength(32)]
        public string Ymm2 { get; set; }

        [Column("ymm3")]
        [MaxLength(32)]
        [MinLength(32)]
        public string Ymm3 { get; set; }

        [Column("ymm4")]
        [MaxLength(32)]
        [MinLength(32)]
        public string Ymm4 { get; set; }

        [Column("ymm5")]
        [MaxLength(32)]
        [MinLength(32)]
        public string Ymm5 { get; set; }

        [Column("ymm6")]
        [MaxLength(32)]
        [MinLength(32)]
        public string Ymm6 { get; set; }

        [Column("ymm7")]
        [MaxLength(32)]
        [MinLength(32)]
        public string Ymm7 { get; set; }

        [Column("ymm8")]
        [MaxLength(32)]
        [MinLength(32)]
        public string Ymm8 { get; set; }

        [Column("ymm9")]
        [MaxLength(32)]
        [MinLength(32)]
        public string Ymm9 { get; set; }

        [Column("ymm10")]
        [MaxLength(32)]
        [MinLength(32)]
        public string Ymm10 { get; set; }

        [Column("ymm11")]
        [MaxLength(32)]
        [MinLength(32)]
        public string Ymm11 { get; set; }

        [Column("ymm12")]
        [MaxLength(32)]
        [MinLength(32)]
        public string Ymm12 { get; set; }

        [Column("ymm13")]
        [MaxLength(32)]
        [MinLength(32)]
        public string Ymm13 { get; set; }

        [Column("ymm14")]
        [MaxLength(32)]
        [MinLength(32)]
        public string Ymm14 { get; set; }

        [Column("ymm15")]
        [MaxLength(32)]
        [MinLength(32)]
        public string Ymm15 { get; set; }
        

        /// <summary>
        ///     Gets or sets the op code.
        /// </summary>
        /// <value>The op code.</value>
        [Column("opcode")]
        public string OpCode { get; set; }

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