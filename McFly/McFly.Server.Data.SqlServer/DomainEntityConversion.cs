// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer
// Author           : @tysmithnet
// Created          : 03-31-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-01-2018
// ***********************************************************************
// <copyright file="DomainEntityConversion.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Linq;
using McFly.Core;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     Class DomainEntityConversion.
    /// </summary>
    internal static class DomainEntityConversion
    {
        
        /// <summary>
        ///     To the frame.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Frame.</returns>
        public static Frame ToFrame(this FrameEntity entity)
        {
            return new Frame
            {
                Position = new Position(entity.PosHi, entity.PosLo),
                ThreadId = entity.ThreadId,
                DisassemblyLine = new DisassemblyLine(entity.Rip?.ToULong(), ByteArrayBuilder.StringToByteArray(entity.OpCode), entity.OpCodeMnemonic,
                    entity.DisassemblyNote),
                RegisterSet = new RegisterSet
                {
                    Brfrom = entity.Brfrom?.ToULong(),
                    Brto = entity.Brto?.ToULong(),
                    Cs = entity.Cs?.ToUShort(),
                    Dr0 = entity.Dr0?.ToULong(),
                    Dr1 = entity.Dr1?.ToULong(),
                    Dr2 = entity.Dr2?.ToULong(),
                    Dr3 = entity.Dr3?.ToULong(),
                    Dr6 = entity.Dr6?.ToULong(),
                    Dr7 = entity.Dr7?.ToULong(),
                    Ds = entity.Ds?.ToUShort(),
                    Efl = entity.Efl?.ToUInt(),
                    Es = entity.Es?.ToUShort(),
                    Exfrom = entity.Exfrom?.ToULong(),
                    Exto = entity.Exto?.ToULong(),
                    Fpcw = entity.Fpcw?.ToUShort(),
                    Fpsw = entity.Fpsw?.ToUShort(),
                    Fptw = entity.Fptw?.ToUShort(),
                    Fopcode = entity.Fopcode?.ToUShort(),
                    Fpip = entity.Fpip?.ToUShort(),
                    Fpipsel = entity.Fpdpsel?.ToUInt(),
                    Fpdp = entity.Fpdp?.ToUShort(),
                    Fpdpsel = entity.Fpdpsel?.ToUInt(),
                    Fs = entity.Fs?.ToUShort(),
                    Gs = entity.Gs?.ToUShort(),
                    Mm0 = entity.Mm0?.ToULong(),
                    Mm1 = entity.Mm1?.ToULong(),
                    Mm2 = entity.Mm2?.ToULong(),
                    Mm3 = entity.Mm3?.ToULong(),
                    Mm4 = entity.Mm4?.ToULong(),
                    Mm5 = entity.Mm5?.ToULong(),
                    Mm6 = entity.Mm6?.ToULong(),
                    Mm7 = entity.Mm7?.ToULong(),
                    Mxcsr = entity.Mxcsr?.ToUShort(),
                    St0 = ByteArrayBuilder.StringToByteArray(entity.St0, true),
                    St1 = ByteArrayBuilder.StringToByteArray(entity.St1, true),
                    St2 = ByteArrayBuilder.StringToByteArray(entity.St2, true),
                    St3 = ByteArrayBuilder.StringToByteArray(entity.St3, true),
                    St4 = ByteArrayBuilder.StringToByteArray(entity.St4, true),
                    St5 = ByteArrayBuilder.StringToByteArray(entity.St5, true),
                    St6 = ByteArrayBuilder.StringToByteArray(entity.St6, true),
                    St7 = ByteArrayBuilder.StringToByteArray(entity.St7, true),
                    R10 = entity.R10?.ToULong(),
                    R11 = entity.R11?.ToULong(),
                    R12 = entity.R12?.ToULong(),
                    R13 = entity.R13?.ToULong(),
                    R14 = entity.R14?.ToULong(),
                    R15 = entity.R15?.ToULong(),
                    R8 = entity.R8?.ToULong(),
                    R9 = entity.R9?.ToULong(),
                    Rax = entity.Rax?.ToULong(),
                    Rbp = entity.Rbp?.ToULong(),
                    Rbx = entity.Rbx?.ToULong(),
                    Rcx = entity.Rcx?.ToULong(),
                    Rdi = entity.Rdi?.ToULong(),
                    Rdx = entity.Rdx?.ToULong(),
                    Rip = entity.Rip?.ToULong(),
                    Rsi = entity.Rsi?.ToULong(),
                    Rsp = entity.Rsp?.ToULong(),
                    Ss = entity.Ss?.ToUShort(),
                    Ymm0 = ByteArrayBuilder.StringToByteArray(entity.Ymm0, true),
                    Ymm1 = ByteArrayBuilder.StringToByteArray(entity.Ymm1, true),
                    Ymm2 = ByteArrayBuilder.StringToByteArray(entity.Ymm2, true),
                    Ymm3 = ByteArrayBuilder.StringToByteArray(entity.Ymm3, true),
                    Ymm4 = ByteArrayBuilder.StringToByteArray(entity.Ymm4, true),
                    Ymm5 = ByteArrayBuilder.StringToByteArray(entity.Ymm5, true),
                    Ymm6 = ByteArrayBuilder.StringToByteArray(entity.Ymm6, true),
                    Ymm7 = ByteArrayBuilder.StringToByteArray(entity.Ymm7, true),
                    Ymm8 = ByteArrayBuilder.StringToByteArray(entity.Ymm8, true),
                    Ymm9 = ByteArrayBuilder.StringToByteArray(entity.Ymm9, true),
                    Ymm10 = ByteArrayBuilder.StringToByteArray(entity.Ymm0, true),
                    Ymm11 = ByteArrayBuilder.StringToByteArray(entity.Ymm11, true),
                    Ymm12 = ByteArrayBuilder.StringToByteArray(entity.Ymm12, true),
                    Ymm13 = ByteArrayBuilder.StringToByteArray(entity.Ymm13, true),
                    Ymm14 = ByteArrayBuilder.StringToByteArray(entity.Ymm14, true),
                    Ymm15 = ByteArrayBuilder.StringToByteArray(entity.Ymm15, true),
                },
            };
        }

        /// <summary>
        ///     To the note.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Note.</returns>
        public static Note ToNote(this NoteEntity entity)
        {
            var note = new Note();
            note.CreateDate = entity.CreateDate;
            note.Text = entity.Text;
            return note;
        }

        /// <summary>
        ///     To the note entity.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <returns>NoteEntity.</returns>
        public static NoteEntity ToNoteEntity(this Note note)
        {
            var entity = new NoteEntity();
            entity.CreateDate = note.CreateDate;
            entity.Text = note.Text;
            return entity;
        }

        /// <summary>
        ///     To the stack frame.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>StackFrame.</returns>
        public static StackFrame ToStackFrame(this StackFrameEntity entity)
        {
            return new StackFrame(entity.StackPointer.ToULong(), entity.ReturnAddress?.ToULong(), entity.ModuleName,
                entity.Function, entity.Offset?.ToULong());
        }

        /// <summary>
        ///     To the frame entity.
        /// </summary>
        /// <param name="frame">The frame.</param>
        /// <param name="context"></param>
        /// <returns>FrameEntity.</returns>
        public static FrameEntity ToFrameEntity(this Frame frame)
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

        /// <summary>
        ///     To the stack frame entity.
        /// </summary>
        /// <param name="stackFrame">The stack frame.</param>
        /// <returns>StackFrameEntity.</returns>
        public static StackFrameEntity ToStackFrameEntity(this StackFrame stackFrame)
        {
            var entity = new StackFrameEntity();
            entity.StackPointer = stackFrame.StackPointer.ToHexString();
            entity.ReturnAddress = stackFrame.ReturnAddress?.ToHexString();
            entity.ModuleName = stackFrame.Module;
            entity.Function = stackFrame.FunctionName;
            entity.Offset = stackFrame.Offset?.ToLong();
            return entity;
        }

        public static MemoryChunkEntity ToMemoryChunkEntity(this MemoryChunk memoryChunk)
        {
             var memoryChunkEntity = new MemoryChunkEntity();

            //memoryChunkEntity.ByteRange  = new ByteRangeEntity();
            //memoryChunkEntity.ByteRange.Bytes = memoryChunk.Bytes.ToHexString();
            //memoryChunkEntity.LowAddress = memoryChunk.MemoryRange.LowAddress.ToHexString();
            //memoryChunkEntity.HighAddress = memoryChunk.MemoryRange.HighAddress.ToHexString();
            //memoryChunkEntity.PosHi = memoryChunk.Position.High;
            //memoryChunkEntity.PosLo = memoryChunk.Position.Low;
            

            return memoryChunkEntity;
        }
    }
}