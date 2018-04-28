// ***********************************************************************
// Assembly         : McFly.Tests
// Author           : @tysmithnet
// Created          : 03-15-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-24-2018
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
using McFly.WinDbg;
using Moq;

namespace McFly.Test
{
    /// <summary>
    ///     Class ServerClientBuilder.
    /// </summary>
    internal class ServerClientBuilder
    {
        /// <summary>
        ///     The mock
        /// </summary>
        public Mock<IServerClient> Mock = new Mock<IServerClient>();

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

        /// <summary>
        ///     Builds this instance.
        /// </summary>
        /// <returns>IServerClient.</returns>
        public IServerClient Build()
        {
            return Mock.Object;
        }

        public ServerClientBuilder WithAddNote()
        {
            Mock.Setup(client =>
                client.AddNote(It.IsAny<Position>(), It.IsAny<IEnumerable<int>>(), It.IsAny<string>()));
            return this;
        }

        public ServerClientBuilder WithAddNote(Position position, IEnumerable<int> threadIds, string text)
        {
            var it = It.Is<IEnumerable<int>>(e => e.SequenceEqual(threadIds));
            Mock.Setup(client => client.AddNote(position, it, text));
            return this;
        }
    }
}