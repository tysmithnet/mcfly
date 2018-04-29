// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer
// Author           : @tysmithnet
// Created          : 04-29-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-29-2018
// ***********************************************************************
// <copyright file="FrameDomainEntityConverter.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Linq;
using McFly.Core;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     Domain entity converter for frames and frameenities
    /// </summary>
    /// <seealso
    ///     cref="FrameEntity" />
    internal sealed class FrameDomainEntityConverter : IDomainEntityConverter<Frame, FrameEntity>
    {
        /// <summary>
        ///     Convert a frame entity to a frame domain object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="context">The context.</param>
        /// <returns>The corresponding domain object for the provided entity</returns>
        /// <inheritdoc />
        public Frame ToDomain(FrameEntity entity, IMcFlyContext context)
        {
            var frame = new Frame();
            frame.Position = new Position(entity.PosHi, entity.PosLo);
            frame.ThreadId = entity.ThreadId;
            frame.DisassemblyLine = new DisassemblyLine(entity.Rip?.ToULong(),
                ByteArrayBuilder.StringToByteArray(entity.OpCode), entity.OpCodeMnemonic,
                entity.DisassemblyNote);
            frame.RegisterSet = new RegisterSet();
            frame.RegisterSet.Brfrom = entity.Brfrom?.ToULong();
            frame.RegisterSet.Brto = entity.Brto?.ToULong();
            frame.RegisterSet.Cs = entity.Cs?.ToUShort();
            frame.RegisterSet.Dr0 = entity.Dr0?.ToULong();
            frame.RegisterSet.Dr1 = entity.Dr1?.ToULong();
            frame.RegisterSet.Dr2 = entity.Dr2?.ToULong();
            frame.RegisterSet.Dr3 = entity.Dr3?.ToULong();
            frame.RegisterSet.Dr6 = entity.Dr6?.ToULong();
            frame.RegisterSet.Dr7 = entity.Dr7?.ToULong();
            frame.RegisterSet.Ds = entity.Ds?.ToUShort();
            frame.RegisterSet.Efl = entity.Efl?.ToUInt();
            frame.RegisterSet.Es = entity.Es?.ToUShort();
            frame.RegisterSet.Exfrom = entity.Exfrom?.ToULong();
            frame.RegisterSet.Exto = entity.Exto?.ToULong();
            frame.RegisterSet.Fpcw = entity.Fpcw?.ToUShort();
            frame.RegisterSet.Fpsw = entity.Fpsw?.ToUShort();
            frame.RegisterSet.Fptw = entity.Fptw?.ToUShort();
            frame.RegisterSet.Fopcode = entity.Fopcode?.ToUShort();
            frame.RegisterSet.Fpip = entity.Fpip?.ToUInt();
            frame.RegisterSet.Fpipsel = entity.Fpipsel?.ToUInt();
            frame.RegisterSet.Fpdp = entity.Fpdp?.ToUInt();
            frame.RegisterSet.Fpdpsel = entity.Fpdpsel?.ToUInt();
            frame.RegisterSet.Fs = entity.Fs?.ToUShort();
            frame.RegisterSet.Gs = entity.Gs?.ToUShort();
            frame.RegisterSet.Mm0 = entity.Mm0?.ToULong();
            frame.RegisterSet.Mm1 = entity.Mm1?.ToULong();
            frame.RegisterSet.Mm2 = entity.Mm2?.ToULong();
            frame.RegisterSet.Mm3 = entity.Mm3?.ToULong();
            frame.RegisterSet.Mm4 = entity.Mm4?.ToULong();
            frame.RegisterSet.Mm5 = entity.Mm5?.ToULong();
            frame.RegisterSet.Mm6 = entity.Mm6?.ToULong();
            frame.RegisterSet.Mm7 = entity.Mm7?.ToULong();
            frame.RegisterSet.Mxcsr = entity.Mxcsr?.ToUInt();
            frame.RegisterSet.St0 = ByteArrayBuilder.StringToByteArray(entity.St0, true);
            frame.RegisterSet.St1 = ByteArrayBuilder.StringToByteArray(entity.St1, true);
            frame.RegisterSet.St2 = ByteArrayBuilder.StringToByteArray(entity.St2, true);
            frame.RegisterSet.St3 = ByteArrayBuilder.StringToByteArray(entity.St3, true);
            frame.RegisterSet.St4 = ByteArrayBuilder.StringToByteArray(entity.St4, true);
            frame.RegisterSet.St5 = ByteArrayBuilder.StringToByteArray(entity.St5, true);
            frame.RegisterSet.St6 = ByteArrayBuilder.StringToByteArray(entity.St6, true);
            frame.RegisterSet.St7 = ByteArrayBuilder.StringToByteArray(entity.St7, true);
            frame.RegisterSet.R10 = entity.R10?.ToULong();
            frame.RegisterSet.R11 = entity.R11?.ToULong();
            frame.RegisterSet.R12 = entity.R12?.ToULong();
            frame.RegisterSet.R13 = entity.R13?.ToULong();
            frame.RegisterSet.R14 = entity.R14?.ToULong();
            frame.RegisterSet.R15 = entity.R15?.ToULong();
            frame.RegisterSet.R8 = entity.R8?.ToULong();
            frame.RegisterSet.R9 = entity.R9?.ToULong();
            frame.RegisterSet.Rax = entity.Rax?.ToULong();
            frame.RegisterSet.Rbp = entity.Rbp?.ToULong();
            frame.RegisterSet.Rbx = entity.Rbx?.ToULong();
            frame.RegisterSet.Rcx = entity.Rcx?.ToULong();
            frame.RegisterSet.Rdi = entity.Rdi?.ToULong();
            frame.RegisterSet.Rdx = entity.Rdx?.ToULong();
            frame.RegisterSet.Rip = entity.Rip?.ToULong();
            frame.RegisterSet.Rsi = entity.Rsi?.ToULong();
            frame.RegisterSet.Rsp = entity.Rsp?.ToULong();
            frame.RegisterSet.Ss = entity.Ss?.ToUShort();
            frame.RegisterSet.Ymm0 = ByteArrayBuilder.StringToByteArray(entity.Ymm0, true);
            frame.RegisterSet.Ymm1 = ByteArrayBuilder.StringToByteArray(entity.Ymm1, true);
            frame.RegisterSet.Ymm2 = ByteArrayBuilder.StringToByteArray(entity.Ymm2, true);
            frame.RegisterSet.Ymm3 = ByteArrayBuilder.StringToByteArray(entity.Ymm3, true);
            frame.RegisterSet.Ymm4 = ByteArrayBuilder.StringToByteArray(entity.Ymm4, true);
            frame.RegisterSet.Ymm5 = ByteArrayBuilder.StringToByteArray(entity.Ymm5, true);
            frame.RegisterSet.Ymm6 = ByteArrayBuilder.StringToByteArray(entity.Ymm6, true);
            frame.RegisterSet.Ymm7 = ByteArrayBuilder.StringToByteArray(entity.Ymm7, true);
            frame.RegisterSet.Ymm8 = ByteArrayBuilder.StringToByteArray(entity.Ymm8, true);
            frame.RegisterSet.Ymm9 = ByteArrayBuilder.StringToByteArray(entity.Ymm9, true);
            frame.RegisterSet.Ymm10 = ByteArrayBuilder.StringToByteArray(entity.Ymm10, true);
            frame.RegisterSet.Ymm11 = ByteArrayBuilder.StringToByteArray(entity.Ymm11, true);
            frame.RegisterSet.Ymm12 = ByteArrayBuilder.StringToByteArray(entity.Ymm12, true);
            frame.RegisterSet.Ymm13 = ByteArrayBuilder.StringToByteArray(entity.Ymm13, true);
            frame.RegisterSet.Ymm14 = ByteArrayBuilder.StringToByteArray(entity.Ymm14, true);
            frame.RegisterSet.Ymm15 = ByteArrayBuilder.StringToByteArray(entity.Ymm15, true);
            return frame;
        }

        /// <summary>
        ///     Convert a frame domain object to an entity
        /// </summary>
        /// <param name="frame">The frame.</param>
        /// <param name="context">The context.</param>
        /// <returns>The corresponding database entity for the provided domain object</returns>
        /// <inheritdoc />
        public FrameEntity ToEntity(Frame frame, IMcFlyContext context)
        {
            var entity = new FrameEntity();
            entity.PosHi = frame.Position?.High ?? 0;
            entity.PosLo = frame.Position?.Low ?? 0;
            entity.ThreadId = frame.ThreadId;
            entity.Brfrom = frame.RegisterSet.Brfrom?.ToHexString();
            entity.Brto = frame.RegisterSet.Brto?.ToHexString();
            entity.Cs = frame.RegisterSet.Cs?.ToHexString();
            entity.Dr0 = frame.RegisterSet.Dr0?.ToHexString();
            entity.Dr1 = frame.RegisterSet.Dr1?.ToHexString();
            entity.Dr2 = frame.RegisterSet.Dr2?.ToHexString();
            entity.Dr3 = frame.RegisterSet.Dr3?.ToHexString();
            entity.Dr6 = frame.RegisterSet.Dr6?.ToHexString();
            entity.Dr7 = frame.RegisterSet.Dr7?.ToHexString();
            entity.Ds = frame.RegisterSet.Ds.ToHexString();
            entity.Efl = frame.RegisterSet.Efl?.ToHexString();
            entity.Es = frame.RegisterSet.Es?.ToHexString();
            entity.Exfrom = frame.RegisterSet.Exfrom?.ToHexString();
            entity.Exto = frame.RegisterSet.Exto?.ToHexString();
            entity.Fpcw = frame.RegisterSet.Fpcw?.ToHexString();
            entity.Fpsw = frame.RegisterSet.Fpsw?.ToHexString();
            entity.Fptw = frame.RegisterSet.Fptw?.ToHexString();
            entity.Fopcode = frame.RegisterSet.Fopcode?.ToHexString();
            entity.Fpip = frame.RegisterSet.Fpip?.ToHexString();
            entity.Fpipsel = frame.RegisterSet.Fpipsel?.ToHexString();
            entity.Fpdp = frame.RegisterSet.Fpdp?.ToHexString();
            entity.Fpdpsel = frame.RegisterSet.Fpdpsel?.ToHexString();
            entity.Fs = frame.RegisterSet.Fs?.ToHexString();
            entity.Gs = frame.RegisterSet.Gs?.ToHexString();
            entity.Mm0 = frame.RegisterSet.Mm0?.ToHexString();
            entity.Mm1 = frame.RegisterSet.Mm1?.ToHexString();
            entity.Mm2 = frame.RegisterSet.Mm2?.ToHexString();
            entity.Mm3 = frame.RegisterSet.Mm3?.ToHexString();
            entity.Mm4 = frame.RegisterSet.Mm4?.ToHexString();
            entity.Mm5 = frame.RegisterSet.Mm5?.ToHexString();
            entity.Mm6 = frame.RegisterSet.Mm6?.ToHexString();
            entity.Mm7 = frame.RegisterSet.Mm7?.ToHexString();
            entity.Mxcsr = frame.RegisterSet.Mxcsr?.ToHexString();
            entity.St0 = frame.RegisterSet.St0?.ToHexString(true);
            entity.St1 = frame.RegisterSet.St1?.ToHexString(true);
            entity.St2 = frame.RegisterSet.St2?.ToHexString(true);
            entity.St3 = frame.RegisterSet.St3?.ToHexString(true);
            entity.St4 = frame.RegisterSet.St4?.ToHexString(true);
            entity.St5 = frame.RegisterSet.St5?.ToHexString(true);
            entity.St6 = frame.RegisterSet.St6?.ToHexString(true);
            entity.St7 = frame.RegisterSet.St7?.ToHexString(true);
            entity.R10 = frame.RegisterSet.R10?.ToHexString();
            entity.R11 = frame.RegisterSet.R11?.ToHexString();
            entity.R12 = frame.RegisterSet.R12?.ToHexString();
            entity.R13 = frame.RegisterSet.R13?.ToHexString();
            entity.R14 = frame.RegisterSet.R14?.ToHexString();
            entity.R15 = frame.RegisterSet.R15?.ToHexString();
            entity.R8 = frame.RegisterSet.R8?.ToHexString();
            entity.R9 = frame.RegisterSet.R9?.ToHexString();
            entity.Rax = frame.RegisterSet.Rax?.ToHexString();
            entity.Rbp = frame.RegisterSet.Rbp?.ToHexString();
            entity.Rbx = frame.RegisterSet.Rbx?.ToHexString();
            entity.Rcx = frame.RegisterSet.Rcx?.ToHexString();
            entity.Rdi = frame.RegisterSet.Rdi?.ToHexString();
            entity.Rdx = frame.RegisterSet.Rdx?.ToHexString();
            entity.Rip = frame.RegisterSet.Rip?.ToHexString();
            entity.Rsi = frame.RegisterSet.Rsi?.ToHexString();
            entity.Rsp = frame.RegisterSet.Rsp?.ToHexString();
            entity.Ss = frame.RegisterSet.Ss?.ToHexString();
            entity.Ymm0 = frame.RegisterSet.Ymm0?.ToHexString(true);
            entity.Ymm1 = frame.RegisterSet.Ymm1?.ToHexString(true);
            entity.Ymm2 = frame.RegisterSet.Ymm2?.ToHexString(true);
            entity.Ymm3 = frame.RegisterSet.Ymm3?.ToHexString(true);
            entity.Ymm4 = frame.RegisterSet.Ymm4?.ToHexString(true);
            entity.Ymm5 = frame.RegisterSet.Ymm5?.ToHexString(true);
            entity.Ymm6 = frame.RegisterSet.Ymm6?.ToHexString(true);
            entity.Ymm7 = frame.RegisterSet.Ymm7?.ToHexString(true);
            entity.Ymm8 = frame.RegisterSet.Ymm8?.ToHexString(true);
            entity.Ymm9 = frame.RegisterSet.Ymm9?.ToHexString(true);
            entity.Ymm10 = frame.RegisterSet.Ymm10?.ToHexString(true);
            entity.Ymm11 = frame.RegisterSet.Ymm11?.ToHexString(true);
            entity.Ymm12 = frame.RegisterSet.Ymm12?.ToHexString(true);
            entity.Ymm13 = frame.RegisterSet.Ymm13?.ToHexString(true);
            entity.Ymm14 = frame.RegisterSet.Ymm14?.ToHexString(true);
            entity.Ymm15 = frame.RegisterSet.Ymm15?.ToHexString(true);
            entity.OpCode = frame.DisassemblyLine?.OpCode.ToHexString();
            entity.OpCodeMnemonic = frame.DisassemblyLine?.OpCodeMnemonic;
            entity.DisassemblyNote = frame.DisassemblyLine?.DisassemblyNote;
            entity.StackFrames = frame.StackTrace.StackFrames.Select(x => x.ToStackFrameEntity()).ToList();
            return entity;
        }
    }
}