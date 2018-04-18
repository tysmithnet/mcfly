// ***********************************************************************
// Assembly         : McFly.Tests
// Author           : @tysmithnet
// Created          : 03-18-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="TimeTravelFacadeBuilder.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using McFly.Core;
using Moq;
using MoreLinq;

namespace McFly.Test.Builders
{
    /// <summary>
    ///     Class TimeTravelFacadeBuilder.
    /// </summary>
    internal class TimeTravelFacadeBuilder
    {
        /// <summary>
        ///     The debug eng proxy builder
        /// </summary>
        private readonly DebugEngineProxyBuilder _debugEngineProxyBuilder;

        /// <summary>
        ///     The frames
        /// </summary>
        private readonly List<Frame> _frames = new List<Frame>();

        /// <summary>
        ///     The current position
        /// </summary>
        private Position _currentPosition = new Position(0, 0);

        /// <summary>
        ///     The mock
        /// </summary>
        public Mock<ITimeTravelFacade> Mock = new Mock<ITimeTravelFacade>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="TimeTravelFacadeBuilder" /> class.
        /// </summary>
        /// <param name="debugEngineProxyBuilder">The debug eng proxy builder.</param>
        public TimeTravelFacadeBuilder(DebugEngineProxyBuilder debugEngineProxyBuilder)
        {
            _debugEngineProxyBuilder = debugEngineProxyBuilder;
            Mock.Setup(facade => facade.GetCurrentFrame(It.IsAny<int>())).Returns((int i) =>
            {
                return _frames.Single(x => x.Position == _currentPosition && x.ThreadId == i);
            });
        }

        /// <summary>
        ///     Gets the current frames.
        /// </summary>
        /// <value>The current frames.</value>
        public IEnumerable<Frame> CurrentFrames => _frames.Where(x => x.Position == _currentPosition);

        /// <summary>
        ///     Withes the get current position.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>TimeTravelFacadeBuilder.</returns>
        public TimeTravelFacadeBuilder WithGetCurrentPosition(Position result)
        {
            Mock.Setup(facade => facade.GetCurrentPosition()).Returns(result);
            return this;
        }

        /// <summary>
        ///     Withes the get current position.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="result">The result.</param>
        /// <returns>TimeTravelFacadeBuilder.</returns>
        public TimeTravelFacadeBuilder WithGetCurrentPosition(int threadId, Position result)
        {
            _currentPosition = result;
            Mock.Setup(facade => facade.GetCurrentPosition(threadId)).Returns(result);
            return this;
        }

        /// <summary>
        ///     Withes the get starting position.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>TimeTravelFacadeBuilder.</returns>
        public TimeTravelFacadeBuilder WithGetStartingPosition(Position result)
        {
            Mock.Setup(facade => facade.GetStartingPosition()).Returns(result);
            return this;
        }

        /// <summary>
        ///     Withes the get ending position.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>TimeTravelFacadeBuilder.</returns>
        public TimeTravelFacadeBuilder WithGetEndingPosition(Position result)
        {
            Mock.Setup(facade => facade.GetEndingPosition()).Returns(result);
            return this;
        }

        /// <summary>
        ///     Withes the positions.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>TimeTravelFacadeBuilder.</returns>
        public TimeTravelFacadeBuilder WithPositions(PositionsResult result)
        {
            Mock.Setup(facade => facade.Positions()).Returns(result);
            return this;
        }

        /// <summary>
        ///     Withes the frames.
        /// </summary>
        /// <param name="frames">The frames.</param>
        /// <returns>TimeTravelFacadeBuilder.</returns>
        public TimeTravelFacadeBuilder WithFrames(IEnumerable<Frame> frames)
        {
            _frames.AddRange(frames ?? new Frame[0]);
            _frames.Sort();
            if (!_frames.Any())
                return this;
            WithGetStartingPosition(_frames.MinBy(x => x.Position).Position);
            WithGetEndingPosition(_frames.MaxBy(x => x.Position).Position);
            _currentPosition = new Position(0, 0);
            AdvanceToNextPosition();
            return this;
        }

        /// <summary>
        ///     Positionses this instance.
        /// </summary>
        /// <returns>PositionsResult.</returns>
        /// <exception cref="InvalidOperationException">
        ///     There needs to be exactly 1 positions record with the current thread tag at
        ///     any given position
        /// </exception>
        public PositionsResult Positions()
        {
            var thread = _debugEngineProxyBuilder.CurrentThreadId;
            var positions = _frames.Where(x => x.Position == _currentPosition)
                .Select(x => new PositionsRecord(x.ThreadId, x.Position, thread == x.ThreadId)).ToList();
            if (positions.Count(x => x.IsCurrentThread) != 1)
                throw new InvalidOperationException(
                    "There needs to be exactly 1 positions record with the current thread tag at any given position");
            return new PositionsResult(positions);
        }

        /// <summary>
        ///     Advances to next position.
        /// </summary>
        /// <returns>TimeTravelFacadeBuilder.</returns>
        public TimeTravelFacadeBuilder AdvanceToNextPosition()
        {
            if (!_frames.Any()) return this;
            var first = _frames.OrderBy(x => x.Position).FirstOrDefault(x => x.Position > _currentPosition);
            _currentPosition = first != null ? first.Position : _frames.Max(x => x.Position);
            WithGetCurrentPosition(_currentPosition);
            WithPositions(Positions());
            return this;
        }

        /// <summary>
        ///     Builds this instance.
        /// </summary>
        /// <returns>ITimeTravelFacade.</returns>
        public ITimeTravelFacade Build()
        {
            return Mock.Object;
        }

        /// <summary>
        ///     Withes the set position.
        /// </summary>
        /// <returns>TimeTravelFacadeBuilder.</returns>
        public TimeTravelFacadeBuilder WithSetPosition()
        {
            Mock.Setup(facade => facade.SetPosition(It.IsAny<Position>()));
            return this;
        }
    }
}