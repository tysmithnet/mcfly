using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using FluentAssertions;
using McFly.Core;
using McFly.Core.Registers;
using McFly.Server.Data.Search;
using McFly.Server.Data.SqlServer.Test.Builders;
using Xunit;

namespace McFly.Server.Data.SqlServer.Test
{
    public class FrameAccess_Should
    {
        private class CantSaveContext : TestMcFlyContext
        {
            /// <inheritdoc />
            public override int SaveChanges()
            {
                throw new DbEntityValidationException("fail", new List<DbEntityValidationResult>());
            }
        }

        [Fact]
        public void Find_Matching_Frames_By_Register_values()
        {
            var frameAccess = new FrameAccess();
            var builder = new ContextFactoryBuilder();
            builder.WithFrame(new FrameEntity
            {
                PosHi = 0,
                PosLo = 0,
                ThreadId = 1,
                Rax = ((ulong) 0).ToHexString(),
                Rbx = ((ulong) 1).ToHexString(),
                Rcx = ((ulong) 2).ToHexString(),
                Rdx = ((ulong) 3).ToHexString()
            }).WithFrame(new FrameEntity
            {
                PosHi = 0,
                PosLo = 0,
                ThreadId = 2,
                Rax = ((ulong) 0).ToHexString(),
                Rbx = ((ulong) 2).ToHexString(),
                Rcx = ((ulong) 4).ToHexString(),
                Rdx = ((ulong) 6).ToHexString()
            }).WithFrame(new FrameEntity
            {
                PosHi = 1,
                PosLo = 0,
                ThreadId = 2
            }).WithFrame(new FrameEntity
            {
                PosHi = 1,
                PosLo = 1,
                ThreadId = 2,
                Rax = ((ulong) 0).ToHexString(),
                Rbx = ((ulong) 1).ToHexString(),
                Rcx = ((ulong) 2).ToHexString(),
                Rdx = ((ulong) 3).ToHexString()
            });
            frameAccess.ContextFactory = builder.Build();

            var between =
                new RegisterBetweenCriterion(Register.Rax, ((ulong) 0).ToHexString(), ((ulong) 2).ToHexString());
            var notBetween = new NotCriterion(between);

            var betweenResults = frameAccess.Search("", between);
            var notBetweenResults = frameAccess.Search("", notBetween);

            betweenResults.Should().HaveCount(3);
            notBetweenResults.Should().HaveCount(1);
        }

        [Fact]
        public void Find_Matching_Frames_Complex()
        {
            var frameAccess = new FrameAccess();
            var builder = new ContextFactoryBuilder();
            builder.WithFrame(new FrameEntity
            {
                PosHi = 0,
                PosLo = 0,
                ThreadId = 1,
                Rax = ((ulong) 1).ToHexString()
            }).WithFrame(new FrameEntity
            {
                PosHi = 0,
                PosLo = 0,
                ThreadId = 2,
                Rax = ((ulong) 2).ToHexString()
            }).WithFrame(new FrameEntity
            {
                PosHi = 1,
                PosLo = 0,
                ThreadId = 2,
                Rax = ((ulong) 2).ToHexString()
            }).WithFrame(new FrameEntity
            {
                PosHi = 1,
                PosLo = 1,
                ThreadId = 2,
                Rax = ((ulong) 1).ToHexString(),
                Rbx = ((ulong) 2).ToHexString()
            });
            frameAccess.ContextFactory = builder.Build();

            var rax = new RegisterEqualsCriterion(Register.Rax, ((ulong) 1).ToHexString());
            var rbx = new RegisterEqualsCriterion(Register.Rbx, ((ulong) 2).ToHexString());
            var and = new AndCriterion(new[] {rax, rbx});
            var or = new OrCriterion(new[] {rax, rbx});
            var not = new NotCriterion(rax);
            var all = new OrCriterion(new ICriterion[] {not, rax});
            var none = new AndCriterion(new ICriterion[] {not, rax});
            var andAll = new AndCriterion(new ICriterion[] {and, all});
            var andResults = frameAccess.Search("", and);
            var orResults = frameAccess.Search("", or);
            var notResults = frameAccess.Search("", not);
            var allResults = frameAccess.Search("", all);
            var noneResults = frameAccess.Search("", none);
            var andAllResults = frameAccess.Search("", andAll);
            andResults.Single().RegisterSet.Rax.Should().Be(1);
            andResults.Single().RegisterSet.Rbx.Should().Be(2);

            orResults.Should().HaveCount(2);
            notResults.Should().HaveCount(2);
            allResults.Should().HaveCount(4);
            noneResults.Should().HaveCount(0);
            andAllResults.Should().HaveCount(1);
        }

        [Fact]
        public void Find_Matching_Frames_When_Searched_For_Basic()
        {
            var frameAccess = new FrameAccess();
            var builder = new ContextFactoryBuilder();
            builder.WithFrame(new FrameEntity
            {
                PosHi = 0,
                PosLo = 0,
                ThreadId = 1,
                Rax = ((ulong) 1).ToHexString()
            }).WithFrame(new FrameEntity
            {
                PosHi = 0,
                PosLo = 0,
                ThreadId = 2,
                Rax = ((ulong) 2).ToHexString()
            });
            frameAccess.ContextFactory = builder.Build();

            var results = frameAccess.Search("", new RegisterEqualsCriterion(Register.Rax, ((ulong) 1).ToHexString()));
            results.Single().RegisterSet.Rax.Should().Be(1);
        }

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
        public void Throw_Application_Exception_If_Save_Fails()
        {
            var frameAccess = new FrameAccess();
            var builder = new ContextFactoryBuilder();
            builder.WithContext(new CantSaveContext());
            frameAccess.ContextFactory = builder.Build();
            Action a = () => frameAccess.UpsertFrames("", new List<Frame>());
            a.Should().Throw<ApplicationException>();
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
            builder.WithFrame(new FrameEntity
            {
                PosHi = 0,
                PosLo = 0,
                ThreadId = 1,
                Rax = ((ulong) 1).ToHexString(),
                Rbx = ((ulong) 2).ToHexString(),
                Rcx = ((ulong) 3).ToHexString(),
                Rdx = ((ulong) 4).ToHexString(),
                DisassemblyNote = "r9,r8",
                Rip = ((ulong) 90).ToHexString(),
                OpCode = "1020",
                OpCodeMnemonic = "mov",
                StackFrames = new List<StackFrameEntity>
                {
                    new StackFrameEntity
                    {
                        StackPointer = ((ulong) 100).ToHexString(),
                        ReturnAddress = ((ulong) 700).ToHexString(),
                        ModuleName = "mymod",
                        Function = "myfun",
                        Offset = 30
                    }
                },
                Notes = new List<NoteEntity>
                {
                    new NoteEntity
                    {
                        CreateDate = DateTime.MinValue,
                        Text = "note"
                    }
                }
            });
            var newFrames = new[]
            {
                new Frame
                {
                    Position = new Position(0, 0),
                    ThreadId = 1,
                    RegisterSet = new RegisterSet
                    {
                        Rax = 2,
                        Rbx = 4,
                        Rcx = 6,
                        Rdx = 8,
                        Rip = 0x90
                    },
                    DisassemblyLine = new DisassemblyLine(90, new byte[] {0x10, 0x20}, "mov", "r9,r8"),
                    StackTrace = new StackTrace(new[]
                    {
                        new StackFrame(100, 700, "mymod", "myfun", 30),
                        new StackFrame(200, 900, "mymod", "myfun2", 20)
                    })
                },
                new Frame
                {
                    Position = new Position(1, 0),
                    ThreadId = 1,
                    RegisterSet = new RegisterSet
                    {
                        Rax = 13,
                        Rbx = 4
                    }
                }
            };
            access.ContextFactory = builder.Build();
            access.UpsertFrames("", newFrames);
            access.GetFrame("", new Position(0, 0), 1).RegisterSet.Rax.Should().Be(2);
            access.GetFrame("", new Position(0, 0), 1).RegisterSet.Rbx.Should().Be(4);
            access.GetFrame("", new Position(1, 0), 1).RegisterSet.Rax.Should().Be(13);
            access.GetFrame("", new Position(1, 0), 1).RegisterSet.Rbx.Should().Be(4);
            // todo: need more complete testing
        }

        [Fact]
        public void Convert_Between_Frame_And_FrameEntity_Correctly()
        {
            var frame = new Frame();

            {
                frame = new Frame();
                frame.RegisterSet.Af = true;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Af.Should().BeTrue();
            }
            {
                frame = new Frame();
                frame.RegisterSet.Cf = true;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Cf.Should().BeTrue();
            }
            {
                frame = new Frame();
                frame.RegisterSet.Df = true;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Df.Should().BeTrue();
            }
            {
                frame = new Frame();
                frame.RegisterSet.If = true;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.If.Should().BeTrue();
            }
            {
                frame = new Frame();
                frame.RegisterSet.Of = true;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Of.Should().BeTrue();
            }
            {
                frame = new Frame();
                frame.RegisterSet.Pf = true;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Pf.Should().BeTrue();
            }
            {
                frame = new Frame();
                frame.RegisterSet.Sf = true;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Sf.Should().BeTrue();
            }
            {
                frame = new Frame();
                frame.RegisterSet.Tf = true;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Tf.Should().BeTrue();
            }
            {
                frame = new Frame();
                frame.RegisterSet.Vif = true;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Vif.Should().BeTrue();
            }
            {
                frame = new Frame();
                frame.RegisterSet.Vip = true;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Vip.Should().BeTrue();
            }
            {
                frame = new Frame();
                frame.RegisterSet.Zf = true;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Zf.Should().BeTrue();
            }



        }
    }
}