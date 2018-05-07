// ***********************************************************************
// Assembly         : McFly.Tests
// Author           : @tysmithnet
// Created          : 03-15-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 05-01-2018
// ***********************************************************************
// <copyright file="ServerClientBuilder.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using McFly.Core;
using Moq;

namespace McFly.WinDbg.Test
{
    /// <summary>
    ///     Builder clas for <see cref="ServerClient"/>
    /// </summary>
    internal class ServerClientBuilder
    {
        /// <summary>
        ///     The mock
        /// </summary>
        public Mock<IServerClient> Mock = new Mock<IServerClient>();

        /// <summary>
        ///     Builds this instance.
        /// </summary>
        /// <returns>IServerClient.</returns>
        public IServerClient Build()
        {
            return Mock.Object;
        }

        /// <summary>
        ///     Withes the add tag.
        /// </summary>
        /// <returns>ServerClientBuilder.</returns>
        public ServerClientBuilder WithAddTag()
        {
            Mock.Setup(client =>
                client.AddTag(It.IsAny<Position>(), It.IsAny<IEnumerable<int>>(), It.IsAny<Tag>()));
            return this;
        }

        /// <summary>
        ///     Withes the add tag.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="threadIds">The thread ids.</param>
        /// <param name="tag">The tag.</param>
        /// <returns>ServerClientBuilder.</returns>
        public ServerClientBuilder WithAddTag(Position position, IEnumerable<int> threadIds, Tag tag)
        {
            var it = It.Is<IEnumerable<int>>(e => e.SequenceEqual(threadIds));
            Mock.Setup(client => client.AddTag(position, it, tag));
            return this;
        }

        /// <summary>
        ///     Withes the get recent tags.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>ServerClientBuilder.</returns>
        public ServerClientBuilder WithGetRecentTags(IEnumerable<Tag> result)
        {
            Mock.Setup(client => client.GetRecentTags(10)).Returns(result);
            return this;
        }

        /// <summary>
        ///     Withes the upsert frames.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>ServerClientBuilder.</returns>
        public ServerClientBuilder WithUpsertFrames(Action result)
        {
            Mock.Setup(client => client.UpsertFrames(It.IsAny<IEnumerable<Frame>>())).Callback(result);
            return this;
        }

        /// <summary>
        ///     Withes the upsert frames.
        /// </summary>
        /// <param name="frames">The frames.</param>
        /// <param name="result">The result.</param>
        /// <returns>ServerClientBuilder.</returns>
        public ServerClientBuilder WithUpsertFrames(IEnumerable<Frame> frames, Action result)
        {
            var list = frames.ToList();
            Mock.Setup(client =>
                client.UpsertFrames(It.Is<IEnumerable<Frame>>(enumerable => enumerable.SequenceEqual(list))));
            return this;
        }

        public ServerClientBuilder WithAddMemoryRange()
        {
            Mock.Setup(client => client.AddMemoryRange(It.IsAny<MemoryChunk>()));
            return this;
        }
    }
}