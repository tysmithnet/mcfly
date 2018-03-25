using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using McFly.Core;
using Moq;
using MoreLinq;

namespace McFly.Tests
{
    internal class TimeTravelFacadeBuilder
    {
        private readonly List<Frame> _frames = new List<Frame>();
        private Position _currentPosition = new Position(0, 0);
        public Mock<ITimeTravelFacade> Mock = new Mock<ITimeTravelFacade>();
        private DbgEngProxyBuilder _dbgEngProxyBuilder;

        public IEnumerable<Frame> CurrentFrames => _frames.Where(x => x.Position == _currentPosition);

        public TimeTravelFacadeBuilder(DbgEngProxyBuilder dbgEngProxyBuilder)
        {
            _dbgEngProxyBuilder = dbgEngProxyBuilder;
            Mock.Setup(facade => facade.GetCurrentFrame(It.IsAny<int>())).Returns((int i) =>
            {
                return _frames.Single(x => x.Position == _currentPosition && x.ThreadId == i);
            });
        }

        public TimeTravelFacadeBuilder WithGetCurrentPosition(Position result)
        {
            Mock.Setup(facade => facade.GetCurrentPosition()).Returns(result);
            return this;
        }

        public TimeTravelFacadeBuilder WithGetCurrentPosition(int threadId, Position result)
        {
            _currentPosition = result;
            Mock.Setup(facade => facade.GetCurrentPosition(threadId)).Returns(result);
            return this;
        }

        public TimeTravelFacadeBuilder WithGetStartingPosition(Position result)
        {
            Mock.Setup(facade => facade.GetStartingPosition()).Returns(result);
            return this;
        }

        public TimeTravelFacadeBuilder WithGetEndingPosition(Position result)
        {
            Mock.Setup(facade => facade.GetEndingPosition()).Returns(result);
            return this;
        }

        public TimeTravelFacadeBuilder WithPositions(PositionsResult result)
        {
            Mock.Setup(facade => facade.Positions()).Returns(result);
            return this;
        }

        public TimeTravelFacadeBuilder WithFrames(IEnumerable<Frame> frames)
        {
            _frames.AddRange(frames ?? new Frame[0]);
            _frames.Sort();
            if (!_frames.Any())
                return this;
            WithGetStartingPosition(_frames.MinBy(x => x.Position).Position);
            WithGetEndingPosition(_frames.MaxBy(x => x.Position).Position);
            _currentPosition = new Position(0,0);
            AdvanceToNextPosition();
            return this;
        }

        public PositionsResult Positions()
        {
            int thread = _dbgEngProxyBuilder.CurrentThreadId;
            var positions = _frames.Where(x => x.Position == _currentPosition)
                .Select(x => new PositionsRecord(x.ThreadId, x.Position, thread == x.ThreadId)).ToList();
            if(positions.Count(x => x.IsCurrentThread) != 1)
                throw new InvalidOperationException("There needs to be exactly 1 positions record with the current thread tag at any given position");
            return new PositionsResult(positions);
        }

        public TimeTravelFacadeBuilder AdvanceToNextPosition()
        {
            if (!_frames.Any()) return this;
            var first = _frames.OrderBy(x => x.Position).FirstOrDefault(x => x.Position > _currentPosition);
            _currentPosition = first != null ? first.Position : _frames.Max(x => x.Position);
            WithGetCurrentPosition(_currentPosition);
            WithPositions(Positions());
            return this;
        }

        public ITimeTravelFacade Build()
        {
            return Mock.Object;
        }
    }

    internal class HttpFacadeBuilder
    {
        public Mock<IHttpFacade> Mock = new Mock<IHttpFacade>();

        public HttpFacadeBuilder WithPostAsync(HttpResponseMessage result)
        {
            Mock.Setup(facade => facade.PostAsync(It.IsAny<Uri>(), It.IsAny<byte[]>())).Returns(Task.FromResult(result));
            Mock.Setup(facade => facade.PostAsync(It.IsAny<Uri>(), It.IsAny<Dictionary<string,string>>())).Returns(Task.FromResult(result));
            return this;
        }

        public HttpFacadeBuilder WithPostJsonAsync(HttpResponseMessage result)
        {
            Mock.Setup(facade => facade.PostJsonAsync(It.IsAny<Uri>(), It.IsAny<object>())).Returns(Task.FromResult(result));
            return this;
        }

        public IHttpFacade Build()
        {
            return Mock.Object;
        }
    }
}