using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace McFly.Server.Data.SqlServer.Test
{
    public class FrameAccess_Should
    {
        public void Update_An_Existing_Frame_If_One_Exists()
        {
            var access = new FrameAccess();
            var contextBuilder = new McFlyContextBuilder();
            
        }
    }

    internal class ContextFactoryBuilder
    {
        public Mock<IContextFactory> Mock = new Mock<IContextFactory>();

        public ContextFactoryBuilder WithContext(McFlyContext context)
        {
            Mock.Setup(factory => factory.GetContext(It.IsAny<string>())).Returns(context);
            return this;
        }

        public ContextFactoryBuilder WithContext(McFlyContextBuilder builder)
        {
            Mock.Setup(factory => factory.GetContext(It.IsAny<string>())).Returns(builder.Build());
            return this;
        }

        public IContextFactory Build()
        {
            return Mock.Object;
        }
    }

    internal class McFlyContextBuilder
    {
        public Mock<McFlyContext> Mock = new Mock<McFlyContext>();

        public McFlyContextBuilder WithFrameEntities(IEnumerable<FrameEntity> frameEntities)
        {
            Mock<DbSet<FrameEntity>> mock = new Mock<DbSet<FrameEntity>>();
            return this;
        }

        public McFlyContext Build()
        {
            return Mock.Object;
        }
    }
}
