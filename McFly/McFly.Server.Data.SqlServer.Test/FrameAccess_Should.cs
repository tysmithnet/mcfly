using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Effort;
using Effort.DataLoaders;
using FluentAssertions;
using McFly.Core;
using Moq;
using Xunit;

namespace McFly.Server.Data.SqlServer.Test
{
    public class FrameAccess_Should
    {
        [Fact]
        public void Update_An_Existing_Frame_If_One_Exists()
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
    }

    internal class ContextFactoryBuilder
    {
        public Mock<IContextFactory> Mock = new Mock<IContextFactory>();
        private McFlyContext _context;

        public ContextFactoryBuilder()
        {
            var loader = new EmptyDataLoader();
            var connection = Effort.DbConnectionFactory.CreateTransient(loader);
            _context = new McFlyContext(connection);
        }

        public ContextFactoryBuilder WithFrame(FrameEntity frame)
        {
            _context.FrameEntities.Add(frame);
            return this;
        }

        public IContextFactory Build()
        {
            return Mock.Object;
        }
    }
}
