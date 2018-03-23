using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McFly.Core;
using Moq;

namespace McFly.Tests
{
    internal class ServerClientBuilder
    {
        public Mock<IServerClient> Mock = new Mock<IServerClient>();

        public ServerClientBuilder WithUpsertFrames(Action result)
        {
            Mock.Setup(client => client.UpsertFrames(It.IsAny<IEnumerable<Frame>>())).Callback(result);
            return this;
        }

        public ServerClientBuilder WithUpsertFrames(IEnumerable<Frame> frames, Action result)
        {
            var list = frames.ToList();
            Mock.Setup(client =>
                client.UpsertFrames(It.Is<IEnumerable<Frame>>(enumerable => enumerable.SequenceEqual(list))));
            return this;
        }

        public IServerClient Build()
        {
            return Mock.Object;
        }
    }
}
