// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer.Test
// Author           : @tysmithnet
// Created          : 04-28-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-28-2018
// ***********************************************************************
// <copyright file="ContextBuilder.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Moq;

namespace McFly.Server.Data.SqlServer.Test.Builders
{
    /// <summary>
    ///     Builder for <see cref="IMcFlyContext"/>
    /// </summary>
    internal class ContextBuilder
    {
        /// <summary>
        ///     Setups SaveChanges() to throw an exception
        /// </summary>
        /// <param name="e">The e.</param>
        /// <returns>ContextBuilder.</returns>
        public ContextBuilder WithSaveChanges(Exception e)
        {
            Mock.Setup(context => context.SaveChanges()).Throws(e);
            return this;
        }

        /// <summary>
        ///     Gets or sets the mock.
        /// </summary>
        /// <value>The mock.</value>
        public Mock<IMcFlyContext> Mock { get; set; } = new Mock<IMcFlyContext>();
    }
}