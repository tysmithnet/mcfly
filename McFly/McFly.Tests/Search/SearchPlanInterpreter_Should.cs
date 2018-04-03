using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    Args = new List<string>() {"rax", "-eq", "10", "AND", "rbx", "-neq", "0"}
                }
            });

            var res = searchPlanConverter.Convert(input);

            res.Type.Should().Be("and");
            res.SubCriteria[0].Type.Should().Be("register");
            res.SubCriteria[0].SubCriteria.Should().BeNullOrEmpty();
            res.SubCriteria[0].Should().BeOfType<TerminalSearchCriterionDto>();
            (res.SubCriteria[0] as TerminalSearchCriterionDto).Expression.Should().Be("rax -eq 10");
            res.SubCriteria[1].Type.Should().Be("register");
            res.SubCriteria[1].SubCriteria.Should().BeNullOrEmpty();
            res.SubCriteria[1].Should().BeOfType<TerminalSearchCriterionDto>();
            (res.SubCriteria[1] as TerminalSearchCriterionDto).Expression.Should().Be("rax -eq 11");
            ;
        }
    }

    public class SearchPlanInterpreter_Should
    {
        public void Create_The_Correct_Search_Request()
        {
            var interpreter = new SearchPlanInterpreter();
            
        }
    }
}
