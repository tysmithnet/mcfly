using Effort.DataLoaders;
using Moq;

namespace McFly.Server.Data.SqlServer.Test
{
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