using FluentAssertions;
using McFly.Server.Contract;
using McFly.Server.Data.Search;
using McFly.Server.Search;
using Xunit;

namespace McFly.Server.Test.Search
{
    public class SearchCriterionCoversionFacade_Should
    {
        [Fact]
        public void Use_The_First_Matching_Converter()
        {
            var facade = new SearchCriterionConversionFacade
            {
                Converters = new ISearchCriterionConverter[] {new RegisterCriterionConverter()}
            };

            var result = facade.Convert(new TerminalSearchCriterionDto
            {
                Type = "register",
                Expression = "rax -eq 10"
            });
            result.Should().BeOfType<RegisterEqualsCriterion>();
        }
    }
}