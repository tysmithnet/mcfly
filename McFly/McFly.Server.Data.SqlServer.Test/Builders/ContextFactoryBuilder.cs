using Moq;

namespace McFly.Server.Data.SqlServer.Test.Builders
{
    internal class ContextFactoryBuilder
    {
        private readonly TestMcFlyContext _context = new TestMcFlyContext();
        public Mock<IContextFactory> Mock = new Mock<IContextFactory>();

        public ContextFactoryBuilder()
        {
            Mock.Setup(factory => factory.GetContext(It.IsAny<string>())).Returns(_context);
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