// ***********************************************************************
// Assembly         : McFly.Tests
// Author           : @tysmithnet
// Created          : 03-18-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 05-01-2018
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

namespace McFly.WinDbg.Test.Builders
{
    /// <summary>
    ///     Class TimeTravelFacadeBuilder.
    /// </summary>
    internal class TimeTravelFacadeBuilder
    {
        public TimeTravelFacadeBuilder()
        {
            Mock.Setup(facade => facade.GetCurrentFrame(It.IsAny<int>())).Returns((int i) =>
            {
                return _frames.SingleOrDefault(x => x.Position == _currentPosition && x.ThreadId == i);
            });
        }

        /// <summary>
        ///     The mock
        /// </summary>
        public Mock<ITimeTravelFacade> Mock = new Mock<ITimeTravelFacade>();

        /// <summary>
        ///     The current position
        /// </summary>
        private Position _currentPosition = new Position(0, 0);

        /// <summary>
        ///     The frames
        /// </summary>
        private readonly List<Frame> _frames = new List<Frame>();

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
            WithFirstPosition(_frames.Min(x => x.Position));
            WithLastPosition(_frames.Max(x => x.Position));
            _currentPosition = new Position(0, 0);
            AdvanceToNextPosition();
            
            return this;
        }

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
        ///     Withes the get ending position.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>TimeTravelFacadeBuilder.</returns>
        public TimeTravelFacadeBuilder WithLastPosition(Position result)
        {
            Mock.Setup(facade => facade.LastPosition).Returns(result);
            return this;
        }

        /// <summary>
        ///     Withes the get starting position.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>TimeTravelFacadeBuilder.</returns>
        public TimeTravelFacadeBuilder WithFirstPosition(Position result)
        {
            Mock.Setup(facade => facade.FirstPosition).Returns(result);
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
        ///     Withes the set position.
        /// </summary>
        /// <returns>TimeTravelFacadeBuilder.</returns>
        public TimeTravelFacadeBuilder WithSetPosition()
        {
            Mock.Setup(facade => facade.SetPosition(It.IsAny<Position>()));
            return this;
        }

        /// <summary>
        ///     Gets the current frames.
        /// </summary>
        /// <value>The current frames.</value>
        public IEnumerable<Frame> CurrentFrames => _frames.Where(x => x.Position == _currentPosition);

        public TimeTravelFacadeBuilder WithGetCurrentFrame(int threadId, Frame frame)
        {
            Mock.Setup(facade => facade.GetCurrentFrame(threadId)).Returns(frame);
            return this;
        }
    }
}