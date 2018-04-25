using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using McFly.Search;
using McFly.Server.Contract;
using Xunit;

namespace McFly.Test.Search
{
    public class SearchPlanConverter_Should
    {
        [Fact]
        public void Convert_Basic_Cases()
        {
            var searchPlanConverter = new SearchPlanConverter();
            var input = new SearchRequest("frame", new List<SearchFilter>
            {
                new SearchFilter
                {
                    Command = "where",
                    Args = new List<string> {"rax", "-eq", "10"}
                }
            });

            var res = searchPlanConverter.Convert(input);

            res.GetType().Should().Be<TerminalSearchCriterionDto>();
            var term = res as TerminalSearchCriterionDto;
            term.Type.Should().Be("register");
            term.Args.SequenceEqual(new[] {"rax", "-eq", "10"}).Should().BeTrue();
        }
    }
}