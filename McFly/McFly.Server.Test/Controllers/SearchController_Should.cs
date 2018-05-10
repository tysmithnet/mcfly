using System.Linq;
using FluentAssertions;
using McFly.Core;
using McFly.Core.Registers;
using McFly.Server.Core;
using McFly.Server.Controllers;
using McFly.Server.Data.Search;
using McFly.Server.Test.Builders;
using Xunit;

namespace McFly.Server.Test.Controllers
{
    public class SearchController_Should
    {
        [Fact]
        public void Find_Matching_Frames_When_Searched()
        {
            var searchController = new SearchController();
            var builder = new SearchCriteriaConverterFacadeBuilder();
            builder.WithConvert(new RegisterEqualsCriterion(Register.Rax, ((ulong)10).ToHexString()));
            searchController.ConversionFacade = builder.Build();
            var accessBuilder = new FrameAccessBuilder();
            accessBuilder.WithSearch(new[]
            {
                new Frame
                {
                    Position = new Position(0, 0),
                    ThreadId = 1,
                    RegisterSet = new RegisterSet
                    {
                        Rax = 10
                    }
                }
            });
            searchController.FrameAccess = accessBuilder.Build();

            var frames = searchController.SearchFrames("", new TerminalSearchCriterionDto
            {
                Type = "register",
                Args = "rax -eq 10".Split(' ')
            });
            frames.All(x => x.RegisterSet.Rax == 10).Should().BeTrue();
        }
    }
}