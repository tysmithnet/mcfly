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
        ///     To the frame entity.
        /// </summary>
        /// <param name="frame">The frame.</param>
        /// <returns>FrameEntity.</returns>
        public static FrameEntity ToFrameEntity(this Frame frame)
        {
            return new FrameEntity
            {
                PosHi = frame.Position.High,
                PosLo = frame.Position.Low,
                ThreadId = frame.ThreadId,
                Rax = frame.RegisterSet.Rax?.ToLong(),
                Rbx = frame.RegisterSet.Rbx?.ToLong(),
                Rcx = frame.RegisterSet.Rcx?.ToLong(),
                Rdx = frame.RegisterSet.Rdx?.ToLong(),
                Address = frame.DisassemblyLine?.InstructionAddress?.ToLong(),
                OpCode = frame.DisassemblyLine?.OpCode,
                OpCodeMnemonic = frame.DisassemblyLine?.OpCodeMnemonic,
                DisassemblyNote = frame.DisassemblyLine?.DisassemblyNote,
                StackFrames = frame.StackTrace.StackFrames.Select(x => x.ToStackFrameEntity()).ToList(),
                Notes = frame.Notes.Select(x => x.ToNoteEntity()).ToList()
            };
        }

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
                DisassemblyLine = new DisassemblyLine(entity.Address?.ToULong(), entity.OpCode, entity.OpCodeMnemonic,
                    entity.DisassemblyNote),
                RegisterSet = new RegisterSet
                {
                    Rax = entity.Rax?.ToULong(),
                    Rbx = entity.Rbx?.ToULong(),
                    Rcx = entity.Rcx?.ToULong(),
                    Rdx = entity.Rdx?.ToULong()
                },
                Notes = entity.Notes?.Select(x => x.ToNote()).ToList()
            };
        }

        /// <summary>
        ///     To the note.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Note.</returns>
        public static Note ToNote(this NoteEntity entity)
        {
            return new Note
            {
                CreateDate = entity.CreateDate,
                Text = entity.Text
            };
        }

        /// <summary>
        ///     To the note entity.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <returns>NoteEntity.</returns>
        public static NoteEntity ToNoteEntity(this Note note)
        {
            return new NoteEntity
            {
                CreateDate = note.CreateDate,
                Text = note.Text
            };
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
        ///     To the stack frame entity.
        /// </summary>
        /// <param name="stackFrame">The stack frame.</param>
        /// <returns>StackFrameEntity.</returns>
        public static StackFrameEntity ToStackFrameEntity(this StackFrame stackFrame)
        {
            return new StackFrameEntity
            {
                StackPointer = stackFrame.StackPointer.ToLong(),
                ReturnAddress = stackFrame.ReturnAddress?.ToLong(),
                ModuleName = stackFrame.Module,
                Function = stackFrame.FunctionName,
                Offset = stackFrame.Offset?.ToLong()
            };
        }
    }
}