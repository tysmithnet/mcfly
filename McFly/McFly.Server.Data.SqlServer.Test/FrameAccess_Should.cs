using System;
using System.Collections.Generic;
using FluentAssertions;
using McFly.Core;
using Xunit;

namespace McFly.Server.Data.SqlServer.Test
{
    public class FrameAccess_Should
    {
        [Fact]
        public void Get_The_Correct_Frame_If_One_Exists()
        {
            var access = new FrameAccess();
            var builder = new ContextFactoryBuilder();
            var frame = new FrameEntity
            {
                PosHi = 0,
                PosLo = 0,
                ThreadId = 1
            };
            builder.WithFrame(frame);
            access.ContextFactory = builder.Build();
            access.GetFrame("anyproject", new Position(0, 0), 1).Should().Be(frame.ToFrame());
        }

        [Fact]
        public void Throw_If_Frame_Cant_Be_Found()
        {
            var access = new FrameAccess();
            var builder = new ContextFactoryBuilder();
            var frame = new FrameEntity
            {
                PosHi = 0,
                PosLo = 0,
                ThreadId = 1
            };
            builder.WithFrame(frame);
            access.ContextFactory = builder.Build();
            Action throws = () => access.GetFrame("test", new Position(1, 0), 1);

            throws.Should().Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void Update_Existing_Frames_And_Insert_New_When_Upserting()
        {
            var access = new FrameAccess();
            var builder = new ContextFactoryBuilder();
            builder.WithFrame(new FrameEntity()
            {
                PosHi = 0,
                PosLo = 0,
                ThreadId = 1,
                Rax = 1,
                Rbx = 2,
                Rcx = 3,
                Rdx = 4,
                DisassemblyNote = "r9,r8",
                Address = 90,
                OpCode = new byte[]{0x10, 0x20},
                OpCodeMnemonic = "mov",
                StackFrames = new List<StackFrameEntity>()
                {
                    new StackFrameEntity
                    {
                        StackPointer = 100,
                        ReturnAddress = 700,
                        ModuleName = "mymod",
                        Function = "myfun",
                        Offset = 30
                    }
                },
                Notes = new List<NoteEntity>()
                {
                    new NoteEntity()
                    {
                        CreateDate = DateTime.MinValue,
                        Text = "note"
                    }
                }
            });
            var newFrames = new[]
            {
                new Frame()
                {
                    Position = new Position(0, 0),
                    ThreadId = 1,
                    RegisterSet = new RegisterSet()
                    {
                        Rax = 2,
                        Rbx = 4,
                        Rcx = 6,
                        Rdx = 8
                    },
                    DisassemblyLine = new DisassemblyLine(90, new byte[]{0x10, 0x20}, "mov", "r9,r8"),
                    StackTrace = new StackTrace(new []
                    {
                        new StackFrame(100, 700, "mymod", "myfun", 30),
                        new StackFrame(200, 900, "mymod", "myfun2", 20),
                    }),
                    Notes = new List<Note>()
                    {
                        new Note()
                        {
                            CreateDate = DateTime.MinValue,
                            Text = "note"
                        }
                    } 
                },
                new Frame()
                {
                    Position = new Position(1, 0),
                    ThreadId = 1,
                    RegisterSet = new RegisterSet()
                    {
                        Rax = 13,
                        Rbx = 4
                    }
                },
            };
            access.ContextFactory = builder.Build();
            access.UpsertFrames("", newFrames);
            access.GetFrame("", new Position(0, 0), 1).RegisterSet.Rax.Should().Be(2);
            access.GetFrame("", new Position(0, 0), 1).RegisterSet.Rbx.Should().Be(4);
            access.GetFrame("", new Position(1, 0), 1).RegisterSet.Rax.Should().Be(13);
            access.GetFrame("", new Position(1, 0), 1).RegisterSet.Rbx.Should().Be(4);
        }
    }
}