using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using FluentAssertions;
using McFly.Core;
using McFly.Server.Controllers;
using McFly.Server.Test.Builders;
using Moq;
using Xunit;

namespace McFly.Server.Test.Controllers
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
            builder.Mock.Verify(
                access => access.UpsertFrames("testing", It.Is<IEnumerable<Frame>>(e => e.SequenceEqual(frames))),
                Times.Once);
        }

        [Fact]
        public void Return_Error_Code_If_Upsert_Fails()
        {
            // arrange
            var frames = new Frame[]
            {
            };
            var frameController = new FrameController();
            var builder = new FrameAccessBuilder();
            builder.WithUpsertFrames(new Exception("oops"));
            frameController.FrameAccess = builder.Build();


            // act                                                        
            var res = frameController.Post("test", frames) as ExceptionResult;

            // assert
            res.Should().NotBeNull();
        }
    }
}