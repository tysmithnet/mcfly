using System;
using FluentAssertions;
using Xunit;

namespace McFly.Core.Tests
{
    public class Frame_Should
    {
        [Fact]
        public void Not_Allow_Invalid_Thread_Ids()
        {
            // arrange
            var frame = new Frame();

            // act
            // assert
            frame.Invoking(f => f.ThreadId = -1).Should()
                .Throw<ArgumentOutOfRangeException>("Thread ids are non negative");
        }
    }
}