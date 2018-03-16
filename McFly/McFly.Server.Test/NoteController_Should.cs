using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McFly.Core;
using McFly.Server.Controllers;
using Xunit;

namespace McFly.Server.Test
{
    public class NoteController_Should
    {
        [Fact]
        public void Create_Note_On_Post()
        {
            // arrange
            var controller = new NoteController();

            // act
            // assert
            controller.Post("testing", new Position(0, 0), 1, "hi world");
        }
    }
}
