using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using McFly.Core;
using Moq;
using Xunit;

namespace McFly.Tests
{
    public class TimeTravelFacade_Should
    {
        [Fact]
        public void Set_The_Position_Correctly()
        {
            // arrange
            var facade = new TimeTravelFacade();
            var position = new Position(0, 0);
            var builder = new DbgEngProxyBuilder();
            facade.DbgEngProxy = builder.Build();

            // act
            facade.SetPosition(position);

            // assert
            builder.Mock.Verify(proxy => proxy.Execute("!tt 0:0"), Times.Once);
        }

        [Fact]
        public void Get_The_Correct_Current_Position()
        {
            // arrange
            var builder = new DbgEngProxyBuilder();
            builder.WithExecuteResult("!positions", @">Thread ID=0x7590 - Position: 35:0
 Thread ID=0x12A0 - Position: 246A:0
 Thread ID=0x6CDC - Position: 21D59:0
 Thread ID=0x2984 - Position: 21DFE:0
 Thread ID=0x3484 - Position: 21ECA:0
 Thread ID=0x60B4 - Position: 2414F:0
 Thread ID=0x1F54 - Position: 241DE:0
");
            var facade = new TimeTravelFacade {DbgEngProxy = builder.Build()};

            // act
            var position = facade.GetCurrentPosition();
            var threadPosition = facade.GetCurrentPosition(0x60b4);

            // assert
            position.Should().Be(new Position(0x35, 0));
            threadPosition.Should().Be(new Position(0x2414f, 0));
        }
    }
}
