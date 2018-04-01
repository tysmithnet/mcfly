using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Effort;
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
            FrameEntity frame = new FrameEntity()
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
            FrameEntity frame = new FrameEntity()
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
    }


}
