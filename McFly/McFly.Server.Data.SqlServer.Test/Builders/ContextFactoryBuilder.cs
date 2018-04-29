// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer.Test
// Author           : @tysmithnet
// Created          : 04-28-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-28-2018
// ***********************************************************************
// <copyright file="ContextFactoryBuilder.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using Moq;

namespace McFly.Server.Data.SqlServer.Test.Builders
{
    /// <summary>
    ///     Builder for <see cref="IContextFactory" />
    /// </summary>
    internal class ContextFactoryBuilder
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ContextFactoryBuilder" /> class.
        /// </summary>
        public ContextFactoryBuilder()
        {
            Mock.Setup(factory => factory.GetContext(It.IsAny<string>())).Returns(_context);
        }

        /// <summary>
        ///     The mock
        /// </summary>
        public Mock<IContextFactory> Mock = new Mock<IContextFactory>();

        /// <summary>
        ///     The context
        /// </summary>
        private readonly TestMcFlyContext _context = new TestMcFlyContext();

        /// <summary>
        ///     Builds this instance.
        /// </summary>
        /// <returns>IContextFactory.</returns>
        public IContextFactory Build()
        {
            return Mock.Object;
        }

        /// <summary>
        ///     Adds a frame to the collection of frames
        /// </summary>
        /// <param name="frame">The frame.</param>
        /// <returns>ContextFactoryBuilder.</returns>
        public ContextFactoryBuilder WithFrame(FrameEntity frame)
        {
            _context.FrameEntities.Add(frame);
            return this;
        }
    }
}