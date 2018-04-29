using System;
using Moq;

namespace McFly.Server.Data.SqlServer.Test.Builders
{
    internal class ContextBuilder
    {
        public ContextBuilder WithSaveChanges(Exception e)
        {
            Mock.Setup(context => context.SaveChanges()).Throws(e);
            return this;
        }

        public Mock<IMcFlyContext> Mock { get; set; } = new Mock<IMcFlyContext>();
    }
}