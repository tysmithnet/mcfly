using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Linq;
using McFly.Core;

namespace McFly.Server.Data.SqlServer
{
    internal static class DomainEntityConversion
    {
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

        public static Frame ToFrame(this FrameEntity entity)
        {
            return new Frame
            {
                Position = new Position(entity.PosHi, entity.PosLo),
                ThreadId = entity.ThreadId,
                DisassemblyLine = new DisassemblyLine(entity.Address?.ToULong(), entity.OpCode, entity.OpCodeMnemonic, entity.DisassemblyNote),
                RegisterSet = new RegisterSet
                {
                    Rax = entity.Rax?.ToULong(),
                    Rbx = entity.Rbx?.ToULong(),
                    Rcx = entity.Rcx?.ToULong(),
                    Rdx = entity.Rdx?.ToULong(),
                },
                Notes = entity.Notes?.Select(x => x.ToNote()).ToList(),
                
            };
        }

        public static Note ToNote(this NoteEntity entity)
        {
            return new Note
            {
                CreateDate = entity.CreateDate,
                Text = entity.Text
            };
        }

        public static NoteEntity ToNoteEntity(this Note note)
        {
            return new NoteEntity
            {
                CreateDate = note.CreateDate,
                Text = note.Text
            };
        }

        public static StackFrame ToStackFrame(this StackFrameEntity entity)
        {
            return new StackFrame(entity.StackPointer.ToULong(), entity.ReturnAddress?.ToULong(), entity.ModuleName, entity.Function, entity.Offset?.ToULong());
        }

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