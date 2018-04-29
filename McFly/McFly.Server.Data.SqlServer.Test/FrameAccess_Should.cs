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
            {
                frame = new Frame();
                frame.RegisterSet.Ah = byte.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Ah.Should().Be(byte.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Al = byte.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Al.Should().Be(byte.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Bh = byte.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Bh.Should().Be(byte.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Bl = byte.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Bl.Should().Be(byte.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Bpl = byte.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Bpl.Should().Be(byte.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Ch = byte.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Ch.Should().Be(byte.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Cl = byte.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Cl.Should().Be(byte.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Dh = byte.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Dh.Should().Be(byte.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Dil = byte.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Dil.Should().Be(byte.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Dl = byte.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Dl.Should().Be(byte.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Iopl = 0x03;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Iopl.Should().Be(0x03);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R10b = byte.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R10b.Should().Be(byte.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R11b = byte.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R11b.Should().Be(byte.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R12b = byte.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R12b.Should().Be(byte.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R13b = byte.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R13b.Should().Be(byte.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R14b = byte.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R14b.Should().Be(byte.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R15b = byte.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R15b.Should().Be(byte.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R8b = byte.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R8b.Should().Be(byte.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R9b = byte.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R9b.Should().Be(byte.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Sil = byte.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Sil.Should().Be(byte.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Spl = byte.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Spl.Should().Be(byte.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Ax = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Ax.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Bp = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Bp.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Bx = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Bx.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Cs = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Cs.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Cx = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Cx.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Di = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Di.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Ds = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Ds.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Dx = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Dx.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Es = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Es.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Fl = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Fl.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Fopcode = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Fopcode.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Fpcw = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Fpcw.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Fpsw = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Fpsw.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Fptw = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Fptw.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Fs = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Fs.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Gs = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Gs.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Ip = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Ip.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R10w = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R10w.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R11w = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R11w.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R12w = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R12w.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R13w = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R13w.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R14w = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R14w.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R15w = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R15w.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R8w = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R8w.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R9w = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R9w.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Si = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Si.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Sp = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Sp.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Ss = ushort.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Ss.Should().Be(ushort.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Eax = uint.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Eax.Should().Be(uint.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Ebp = uint.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Ebp.Should().Be(uint.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Ebx = uint.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Ebx.Should().Be(uint.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Ecx = uint.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Ecx.Should().Be(uint.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Edi = uint.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Edi.Should().Be(uint.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Edx = uint.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Edx.Should().Be(uint.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Efl = uint.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Efl.Should().Be(uint.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Eip = uint.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Eip.Should().Be(uint.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Esi = uint.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Esi.Should().Be(uint.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Esp = uint.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Esp.Should().Be(uint.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Fpdp = uint.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Fpdp.Should().Be(uint.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Fpdpsel = uint.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Fpdpsel.Should().Be(uint.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Fpip = uint.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Fpip.Should().Be(uint.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Fpipsel = uint.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Fpipsel.Should().Be(uint.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Mxcsr = uint.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Mxcsr.Should().Be(uint.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R10d = uint.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R10d.Should().Be(uint.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R11d = uint.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R11d.Should().Be(uint.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R12d = uint.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R12d.Should().Be(uint.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R13d = uint.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R13d.Should().Be(uint.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R14d = uint.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R14d.Should().Be(uint.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R15d = uint.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R15d.Should().Be(uint.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R8d = uint.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R8d.Should().Be(uint.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R9d = uint.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R9d.Should().Be(uint.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Brfrom = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Brfrom.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Brto = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Brto.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Dr0 = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Dr0.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Dr1 = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Dr1.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Dr2 = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Dr2.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Dr3 = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Dr3.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Dr6 = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Dr6.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Dr7 = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Dr7.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Exfrom = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Exfrom.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Exto = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Exto.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Mm0 = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Mm0.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Mm1 = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Mm1.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Mm2 = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Mm2.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Mm3 = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Mm3.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Mm4 = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Mm4.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Mm5 = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Mm5.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Mm6 = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Mm6.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Mm7 = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Mm7.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R10 = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R10.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R11 = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R11.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R12 = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R12.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R13 = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R13.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R14 = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R14.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R15 = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R15.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R8 = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R8.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.R9 = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.R9.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Rax = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Rax.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Rbp = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Rbp.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Rbx = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Rbx.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Rcx = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Rcx.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Rdi = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Rdi.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Rdx = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Rdx.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Rip = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Rip.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Rsi = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Rsi.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Rsp = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Rsp.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm0h = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm0h.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm0l = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm0l.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm10h = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm10h.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm10l = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm10l.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm11h = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm11h.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm11l = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm11l.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm12h = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm12h.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm12l = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm12l.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm13h = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm13h.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm13l = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm13l.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm14h = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm14h.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm14l = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm14l.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm15h = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm15h.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm15l = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm15l.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm1h = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm1h.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm1l = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm1l.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm2h = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm2h.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm2l = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm2l.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm3h = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm3h.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm3l = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm3l.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm4h = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm4h.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm4l = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm4l.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm5h = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm5h.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm5l = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm5l.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm6h = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm6h.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm6l = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm6l.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm7h = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm7h.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm7l = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm7l.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm8h = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm8h.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm8l = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm8l.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm9h = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm9h.Should().Be(ulong.MaxValue);
            }
            {
                frame = new Frame();
                frame.RegisterSet.Xmm9l = ulong.MaxValue;
                var entity = frame.ToFrameEntity();
                var convertedBack = entity.ToFrame();
                convertedBack.RegisterSet.Xmm9l.Should().Be(ulong.MaxValue);
            }
        }
    }
}