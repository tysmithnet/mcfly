// ***********************************************************************
// Assembly         : McFly.Server.Test
// Author           : @tysmithnet
// Created          : 03-16-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-16-2018
// ***********************************************************************
// <copyright file="FrameAccessBuilder.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using McFly.Core;
using McFly.Server.Data;
using McFly.Server.Data.Search;
using Moq;

namespace McFly.Server.Test.Builders
{
    /// <summary>
    /// Builder for mock frame access
    /// </summary>
    public class FrameAccessBuilder
    {
        /// <summary>
        /// The mock
        /// </summary>
        public Mock<IFrameAccess> Mock = new Mock<IFrameAccess>();

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns>IFrameAccess.</returns>
        public IFrameAccess Build()
        {
            return Mock.Object;
        }

        public FrameAccessBuilder WithUpsertFrames(Exception exception)
        {
            Mock.Setup(access => access.UpsertFrames(It.IsAny<string>(), It.IsAny<IEnumerable<Frame>>()))
                .Throws(exception);
            return this;
        }

        public FrameAccessBuilder WithSearch(IEnumerable<Frame> frames)
        {
            Mock.Setup(access => access.Search(It.IsAny<string>(), It.IsAny<ICriterion>())).Returns(frames);
            return this;
        }
    }
}