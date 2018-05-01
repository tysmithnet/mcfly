// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer
// Author           : @tysmithnet
// Created          : 04-01-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-21-2018
// ***********************************************************************
// <copyright file="FrameEntity.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the brfrom.
        /// </summary>
        /// <value>The brfrom.</value>
        [Column("brfrom")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Brfrom { get; set; }

        /// <summary>
        ///     Gets or sets the brto.
        /// </summary>
        /// <value>The brto.</value>
        [Column("brto")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Brto { get; set; }

        /// <summary>
        ///     Gets or sets the cs.
        /// </summary>
        /// <value>The cs.</value>
        [Column("cs")]
        [MaxLength(4)]
        [MinLength(4)]
        public string Cs { get; set; }

        /// <summary>
        ///     Gets or sets the disassembly note.
        /// </summary>
        /// <value>The disassembly note.</value>
        [Column("disassembly_note")]
        public string DisassemblyNote { get; set; }

        /// <summary>
        ///     Gets or sets the DR0.
        /// </summary>
        /// <value>The DR0.</value>
        [Column("dr0")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Dr0 { get; set; }

        /// <summary>
        ///     Gets or sets the DR1.
        /// </summary>
        /// <value>The DR1.</value>
        [Column("dr1")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Dr1 { get; set; }

        /// <summary>
        ///     Gets or sets the DR2.
        /// </summary>
        /// <value>The DR2.</value>
        [Column("dr2")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Dr2 { get; set; }

        /// <summary>
        ///     Gets or sets the DR3.
        /// </summary>
        /// <value>The DR3.</value>
        [Column("dr3")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Dr3 { get; set; }

        /// <summary>
        ///     Gets or sets the DR6.
        /// </summary>
        /// <value>The DR6.</value>
        [Column("dr6")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Dr6 { get; set; }

        /// <summary>
        ///     Gets or sets the DR7.
        /// </summary>
        /// <value>The DR7.</value>
        [Column("dr7")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Dr7 { get; set; }

        /// <summary>
        ///     Gets or sets the ds.
        /// </summary>
        /// <value>The ds.</value>
        [Column("ds")]
        [MaxLength(4)]
        [MinLength(4)]
        public string Ds { get; set; }

        /// <summary>
        ///     Gets or sets the efl.
        /// </summary>
        /// <value>The efl.</value>
        [Column("efl")]
        [MaxLength(8)]
        [MinLength(8)]
        public string Efl { get; set; }

        /// <summary>
        ///     Gets or sets the es.
        /// </summary>
        /// <value>The es.</value>
        [Column("es")]
        [MaxLength(4)]
        [MinLength(4)]
        public string Es { get; set; }

        /// <summary>
        ///     Gets or sets the exfrom.
        /// </summary>
        /// <value>The exfrom.</value>
        [Column("exfrom")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Exfrom { get; set; }

        /// <summary>
        ///     Gets or sets the exto.
        /// </summary>
        /// <value>The exto.</value>
        [Column("exto")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Exto { get; set; }

        /// <summary>
        ///     Gets or sets the fopcode.
        /// </summary>
        /// <value>The fopcode.</value>
        [Column("fopcode")]
        [MaxLength(4)]
        [MinLength(4)]
        public string Fopcode { get; set; }

        /// <summary>
        ///     Gets or sets the FPCW.
        /// </summary>
        /// <value>The FPCW.</value>
        [Column("fpcw")]
        [MaxLength(4)]
        [MinLength(4)]
        public string Fpcw { get; set; }

        /// <summary>
        ///     Gets or sets the FPDP.
        /// </summary>
        /// <value>The FPDP.</value>
        [Column("fpdp")]
        [MaxLength(8)]
        [MinLength(8)]
        public string Fpdp { get; set; }

        /// <summary>
        ///     Gets or sets the fpdpsel.
        /// </summary>
        /// <value>The fpdpsel.</value>
        [Column("fpdpsel")]
        [MaxLength(8)]
        [MinLength(8)]
        public string Fpdpsel { get; set; }

        /// <summary>
        ///     Gets or sets the fpip.
        /// </summary>
        /// <value>The fpip.</value>
        [Column("fpip")]
        [MaxLength(8)]
        [MinLength(8)]
        public string Fpip { get; set; }

        /// <summary>
        ///     Gets or sets the fpipsel.
        /// </summary>
        /// <value>The fpipsel.</value>
        [Column("fpipsel")]
        [MaxLength(8)]
        [MinLength(8)]
        public string Fpipsel { get; set; }

        /// <summary>
        ///     Gets or sets the FPSW.
        /// </summary>
        /// <value>The FPSW.</value>
        [Column("fpsw")]
        [MaxLength(4)]
        [MinLength(4)]
        public string Fpsw { get; set; }

        /// <summary>
        ///     Gets or sets the FPTW.
        /// </summary>
        /// <value>The FPTW.</value>
        [Column("fptw")]
        [MaxLength(4)]
        [MinLength(4)]
        public string Fptw { get; set; }

        /// <summary>
        ///     Gets or sets the fs.
        /// </summary>
        /// <value>The fs.</value>
        [Column("fs")]
        [MaxLength(4)]
        [MinLength(4)]
        public string Fs { get; set; }

        /// <summary>
        ///     Gets or sets the gs.
        /// </summary>
        /// <value>The gs.</value>
        [Column("gs")]
        [MaxLength(4)]
        [MinLength(4)]
        public string Gs { get; set; }

        /// <summary>
        ///     Gets or sets the MM0.
        /// </summary>
        /// <value>The MM0.</value>
        [Column("mm0")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Mm0 { get; set; }

        /// <summary>
        ///     Gets or sets the MM1.
        /// </summary>
        /// <value>The MM1.</value>
        [Column("mm1")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Mm1 { get; set; }

        /// <summary>
        ///     Gets or sets the MM2.
        /// </summary>
        /// <value>The MM2.</value>
        [Column("mm2")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Mm2 { get; set; }

        /// <summary>
        ///     Gets or sets the MM3.
        /// </summary>
        /// <value>The MM3.</value>
        [Column("mm3")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Mm3 { get; set; }

        /// <summary>
        ///     Gets or sets the MM4.
        /// </summary>
        /// <value>The MM4.</value>
        [Column("mm4")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Mm4 { get; set; }

        /// <summary>
        ///     Gets or sets the MM5.
        /// </summary>
        /// <value>The MM5.</value>
        [Column("mm5")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Mm5 { get; set; }

        /// <summary>
        ///     Gets or sets the MM6.
        /// </summary>
        /// <value>The MM6.</value>
        [Column("mm6")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Mm6 { get; set; }

        /// <summary>
        ///     Gets or sets the MM7.
        /// </summary>
        /// <value>The MM7.</value>
        [Column("mm7")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Mm7 { get; set; }

        /// <summary>
        ///     Gets or sets the MXCSR.
        /// </summary>
        /// <value>The MXCSR.</value>
        [Column("mxcsr")]
        [MaxLength(8)]
        [MinLength(8)]
        public string Mxcsr { get; set; }

        /// <summary>
        ///     Gets or sets the tags.
        /// </summary>
        /// <value>The tags.</value>
        public virtual List<TagEntity> Tags { get; set; } = new List<TagEntity>();

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
        ///     Gets or sets the R10.
        /// </summary>
        /// <value>The R10.</value>
        [Column("r10")]
        [MaxLength(16)]
        [MinLength(16)]
        public string R10 { get; set; }

        /// <summary>
        ///     Gets or sets the R11.
        /// </summary>
        /// <value>The R11.</value>
        [Column("r11")]
        [MaxLength(16)]
        [MinLength(16)]
        public string R11 { get; set; }

        /// <summary>
        ///     Gets or sets the R12.
        /// </summary>
        /// <value>The R12.</value>
        [Column("r12")]
        [MaxLength(16)]
        [MinLength(16)]
        public string R12 { get; set; }

        /// <summary>
        ///     Gets or sets the R13.
        /// </summary>
        /// <value>The R13.</value>
        [Column("r13")]
        [MaxLength(16)]
        [MinLength(16)]
        public string R13 { get; set; }

        /// <summary>
        ///     Gets or sets the R14.
        /// </summary>
        /// <value>The R14.</value>
        [Column("r14")]
        [MaxLength(16)]
        [MinLength(16)]
        public string R14 { get; set; }

        /// <summary>
        ///     Gets or sets the R15.
        /// </summary>
        /// <value>The R15.</value>
        [Column("r15")]
        [MaxLength(16)]
        [MinLength(16)]
        public string R15 { get; set; }

        /// <summary>
        ///     Gets or sets the r8.
        /// </summary>
        /// <value>The r8.</value>
        [Column("r8")]
        [MaxLength(16)]
        [MinLength(16)]
        public string R8 { get; set; }

        /// <summary>
        ///     Gets or sets the r9.
        /// </summary>
        /// <value>The r9.</value>
        [Column("r9")]
        [MaxLength(16)]
        [MinLength(16)]
        public string R9 { get; set; }

        /// <summary>
        ///     Gets or sets the rax.
        /// </summary>
        /// <value>The rax.</value>
        [Column("rax")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Rax { get; set; }

        /// <summary>
        ///     Gets or sets the RBP.
        /// </summary>
        /// <value>The RBP.</value>
        [Column("rbp")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Rbp { get; set; }

        /// <summary>
        ///     Gets or sets the RBX.
        /// </summary>
        /// <value>The RBX.</value>
        [Column("rbx")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Rbx { get; set; }

        /// <summary>
        ///     Gets or sets the RCX.
        /// </summary>
        /// <value>The RCX.</value>
        [Column("rcx")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Rcx { get; set; }

        /// <summary>
        ///     Gets or sets the rdi.
        /// </summary>
        /// <value>The rdi.</value>
        [Column("rdi")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Rdi { get; set; }

        /// <summary>
        ///     Gets or sets the RDX.
        /// </summary>
        /// <value>The RDX.</value>
        [Column("rdx")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Rdx { get; set; }

        /// <summary>
        ///     Gets or sets the rip.
        /// </summary>
        /// <value>The rip.</value>
        [Column("rip")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Rip { get; set; }

        /// <summary>
        ///     Gets or sets the rsi.
        /// </summary>
        /// <value>The rsi.</value>
        [Column("rsi")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Rsi { get; set; }

        /// <summary>
        ///     Gets or sets the RSP.
        /// </summary>
        /// <value>The RSP.</value>
        [Column("rsp")]
        [MaxLength(16)]
        [MinLength(16)]
        public string Rsp { get; set; }

        /// <summary>
        ///     Gets or sets the ss.
        /// </summary>
        /// <value>The ss.</value>
        [Column("ss")]
        [MaxLength(4)]
        [MinLength(4)]
        public string Ss { get; set; }

        /// <summary>
        ///     Gets or sets the ST0.
        /// </summary>
        /// <value>The ST0.</value>
        [Column("st0")]
        [MaxLength(20)]
        [MinLength(20)]
        public string St0 { get; set; }

        /// <summary>
        ///     Gets or sets the ST1.
        /// </summary>
        /// <value>The ST1.</value>
        [Column("st1")]
        [MaxLength(20)]
        [MinLength(20)]
        public string St1 { get; set; }

        /// <summary>
        ///     Gets or sets the ST2.
        /// </summary>
        /// <value>The ST2.</value>
        [Column("st2")]
        [MaxLength(20)]
        [MinLength(20)]
        public string St2 { get; set; }

        /// <summary>
        ///     Gets or sets the ST3.
        /// </summary>
        /// <value>The ST3.</value>
        [Column("st3")]
        [MaxLength(20)]
        [MinLength(20)]
        public string St3 { get; set; }

        /// <summary>
        ///     Gets or sets the ST4.
        /// </summary>
        /// <value>The ST4.</value>
        [Column("st4")]
        [MaxLength(20)]
        [MinLength(20)]
        public string St4 { get; set; }

        /// <summary>
        ///     Gets or sets the ST5.
        /// </summary>
        /// <value>The ST5.</value>
        [Column("st5")]
        [MaxLength(20)]
        [MinLength(20)]
        public string St5 { get; set; }

        /// <summary>
        ///     Gets or sets the ST6.
        /// </summary>
        /// <value>The ST6.</value>
        [Column("st6")]
        [MaxLength(20)]
        [MinLength(20)]
        public string St6 { get; set; }

        /// <summary>
        ///     Gets or sets the ST7.
        /// </summary>
        /// <value>The ST7.</value>
        [Column("st7")]
        [MaxLength(20)]
        [MinLength(20)]
        public string St7 { get; set; }

        /// <summary>
        ///     Gets or sets the stack frames.
        /// </summary>
        /// <value>The stack frames.</value>
        public virtual List<StackFrameEntity> StackFrames { get; set; } = new List<StackFrameEntity>();

        /// <summary>
        ///     Gets or sets the thread identifier.
        /// </summary>
        /// <value>The thread identifier.</value>
        [Column("thread_id")]
        public int ThreadId { get; set; }

        /// <summary>
        ///     Gets or sets the ymm0.
        /// </summary>
        /// <value>The ymm0.</value>
        [Column("ymm0")]
        [MaxLength(64)]
        [MinLength(64)]
        public string Ymm0 { get; set; }

        /// <summary>
        ///     Gets or sets the ymm1.
        /// </summary>
        /// <value>The ymm1.</value>
        [Column("ymm1")]
        [MaxLength(64)]
        [MinLength(64)]
        public string Ymm1 { get; set; }

        /// <summary>
        ///     Gets or sets the ymm10.
        /// </summary>
        /// <value>The ymm10.</value>
        [Column("ymm10")]
        [MaxLength(64)]
        [MinLength(64)]
        public string Ymm10 { get; set; }

        /// <summary>
        ///     Gets or sets the ymm11.
        /// </summary>
        /// <value>The ymm11.</value>
        [Column("ymm11")]
        [MaxLength(64)]
        [MinLength(64)]
        public string Ymm11 { get; set; }

        /// <summary>
        ///     Gets or sets the ymm12.
        /// </summary>
        /// <value>The ymm12.</value>
        [Column("ymm12")]
        [MaxLength(64)]
        [MinLength(64)]
        public string Ymm12 { get; set; }

        /// <summary>
        ///     Gets or sets the ymm13.
        /// </summary>
        /// <value>The ymm13.</value>
        [Column("ymm13")]
        [MaxLength(64)]
        [MinLength(64)]
        public string Ymm13 { get; set; }

        /// <summary>
        ///     Gets or sets the ymm14.
        /// </summary>
        /// <value>The ymm14.</value>
        [Column("ymm14")]
        [MaxLength(64)]
        [MinLength(64)]
        public string Ymm14 { get; set; }

        /// <summary>
        ///     Gets or sets the ymm15.
        /// </summary>
        /// <value>The ymm15.</value>
        [Column("ymm15")]
        [MaxLength(64)]
        [MinLength(64)]
        public string Ymm15 { get; set; }

        /// <summary>
        ///     Gets or sets the ymm2.
        /// </summary>
        /// <value>The ymm2.</value>
        [Column("ymm2")]
        [MaxLength(64)]
        [MinLength(64)]
        public string Ymm2 { get; set; }

        /// <summary>
        ///     Gets or sets the ymm3.
        /// </summary>
        /// <value>The ymm3.</value>
        [Column("ymm3")]
        [MaxLength(64)]
        [MinLength(64)]
        public string Ymm3 { get; set; }

        /// <summary>
        ///     Gets or sets the ymm4.
        /// </summary>
        /// <value>The ymm4.</value>
        [Column("ymm4")]
        [MaxLength(64)]
        [MinLength(64)]
        public string Ymm4 { get; set; }

        /// <summary>
        ///     Gets or sets the ymm5.
        /// </summary>
        /// <value>The ymm5.</value>
        [Column("ymm5")]
        [MaxLength(64)]
        [MinLength(64)]
        public string Ymm5 { get; set; }

        /// <summary>
        ///     Gets or sets the ymm6.
        /// </summary>
        /// <value>The ymm6.</value>
        [Column("ymm6")]
        [MaxLength(64)]
        [MinLength(64)]
        public string Ymm6 { get; set; }

        /// <summary>
        ///     Gets or sets the ymm7.
        /// </summary>
        /// <value>The ymm7.</value>
        [Column("ymm7")]
        [MaxLength(64)]
        [MinLength(64)]
        public string Ymm7 { get; set; }

        /// <summary>
        ///     Gets or sets the ymm8.
        /// </summary>
        /// <value>The ymm8.</value>
        [Column("ymm8")]
        [MaxLength(64)]
        [MinLength(64)]
        public string Ymm8 { get; set; }

        /// <summary>
        ///     Gets or sets the ymm9.
        /// </summary>
        /// <value>The ymm9.</value>
        [Column("ymm9")]
        [MaxLength(64)]
        [MinLength(64)]
        public string Ymm9 { get; set; }
    }
}