using System.Collections.Generic;
using FluentAssertions;
using McFly.Search;
using McFly.Server.Contract;
using Xunit;

namespace McFly.Tests.Search
{
    public class SearchPlanConverter_Should
    {
        [Fact]
        public void Convert_Basic_Cases()
        {
            var searchPlanConverter = new SearchPlanConverter();
            var input = new SearchPlan("frame", new List<SearchFilter>()
            {
                new SearchFilter()
                {
                    Command = "where",
                    Args = new List<string>() {"rax", "-eq", "10"}
                }
            });

            var res = searchPlanConverter.Convert(input);

            res.Type.Should().Be("and");
            res.SubCriteria[0].Type.Should().Be("register");
            res.SubCriteria[0].SubCriteria.Should().BeNullOrEmpty();
            res.SubCriteria[0].Should().BeOfType<TerminalSearchCriterionDto>();
            (res.SubCriteria[0] as TerminalSearchCriterionDto).Args.Should().Equal("rax -eq 10".Split(' '));
            ;
        }
    }
}