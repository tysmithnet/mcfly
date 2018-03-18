using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McFly.Core;
using McFly.Server.Controllers;
using Moq;
using Xunit;

namespace McFly.Server.Test
{
    public class FrameController_Should
    {
        [Fact]
        public void Upsert_Frame_On_Post()
        {
            // arrange
            var frames = new Frame[]
            {
            };
            var frameController = new FrameController();
            var builder = new FrameAccessBuilder();
            frameController.FrameAccess = builder.Build();

            // act
            frameController.Post("testing", frames);

            // assert
            builder.Mock.Verify(access => access.UpsertFrames("testing", It.Is<IEnumerable<Frame>>(e => e.SequenceEqual(frames))), Times.Once);
        }
    }
}
