using Moq;
using Xunit;

namespace McFly.Tests
{
    public class SearchMethod_Should
    {
        public class SearchPlanInterpreterBuilder
        {
            public Mock<ISearchPlanInterpreter> Mock = new Mock<ISearchPlanInterpreter>();

            public ISearchPlanInterpreter Build()
            {
                return Mock.Object;
            }
        }

        public class SearchIndexBuilder
        {
            public Mock<ISearchIndex> Mock = new Mock<ISearchIndex>();

            public ISearchIndex Build()
            {
                return Mock.Object;
            }
        }

        public class SearchResultDisplayStrategyBuilder
        {
            public Mock<ISearchResultDisplayStrategy> Mock = new Mock<ISearchResultDisplayStrategy>();

            public ISearchResultDisplayStrategy Build()
            {
                return Mock.Object;
            }
        }

        public class SearchParserBuilder
        {
            public Mock<ISearchParser> Mock = new Mock<ISearchParser>();

            public ISearchParser Build()
            {
                return Mock.Object;
            }
        }

        [Fact]
        public void Get_Results_From_All_Registered_Search_Strategies()
        {
            var searchMethod = new SearchMethod
            {
                SearchParser = new SearchParserBuilder()
                    .Build(),
                SearchResultDisplayStrategy = new SearchResultDisplayStrategyBuilder()
                    .Build(),
                SearchIndices = new[]
                {
                    new SearchIndexBuilder().Build()
                },
                SearchPlanInterpreter = new SearchPlanInterpreterBuilder().Build()
            };

            searchMethod.Process("".Split(' '));
            searchMethod.Process("-s 0:0 -e 100:0".Split(' '));
            searchMethod.Process("kernel32".Split(' '));
            searchMethod.Process("| where rax -eq 1 and mod -contains 32 | fields rax rip mod fun".Split(' '));
        }
    }
}