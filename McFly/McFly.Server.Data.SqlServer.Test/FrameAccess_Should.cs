using System;
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
                Rax = 10
            });
            var newFrames = new[]
            {
                new Frame()
                {
                    Position = new Position(0, 0),
                    ThreadId = 1,
                    RegisterSet = new RegisterSet()
                    {
                        Rax = 11,
                        Rbx = 2
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
            access.GetFrame("", new Position(0, 0), 1).RegisterSet.Rax.Should().Be(11);
            access.GetFrame("", new Position(0, 0), 1).RegisterSet.Rbx.Should().Be(2);
            access.GetFrame("", new Position(1, 0), 1).RegisterSet.Rax.Should().Be(13);
            access.GetFrame("", new Position(1, 0), 1).RegisterSet.Rbx.Should().Be(4);
        }
    }
}