using System.Collections.Generic;
using FluentAssertions;
using McFly.Core;
using Moq;
using Xunit;

namespace McFly.Tests
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

    public class SearchParser_Should
    {
        [Fact]
        public void Parse_Arguments_Correctly()
        {
            var searchParser = new SearchParser();
            var emptyExpected = new SearchPlan(new InitialSearch(), new List<SearchFilter>());
            var startEndExpected = new SearchPlan(new InitialSearch()
            {
                Start = new Position(0,0),
                End = new Position(0x100, 0)
            }, new List<SearchFilter>());

            var empty = searchParser.Parse("".Split(' '));
            var startEnd = searchParser.Parse("-s 0:0 -e 100:0".Split(' '));
            var kernel32 = searchParser.Parse("kernel32".Split(' '));
            var where = searchParser.Parse("| where rax -eq 1 | mod -contains 32".Split(' '));
            var whereFields = searchParser.Parse("| where rax -eq 1 | where mod -contains 32 | fields rax rip mod fun".Split(' '));

            empty.Should().Be(emptyExpected);
            startEnd.Should().Be(startEndExpected);
        }
    }

    public class SearchMethod_Should
    {
        [Fact]
        public void Get_Results_From_All_Registered_Search_Strategies()
        {
            var searchParserBuilder = new SearchParserBuilder();
            var searchResultDisplayStrategyBuilder = new SearchResultDisplayStrategyBuilder();
            var searchIndexBuilder = new SearchIndexBuilder();
            var searchPlanInterpreterBuilder = new SearchPlanInterpreterBuilder();

            var searchMethod = new SearchMethod
            {
                SearchParser = searchParserBuilder
                    .Build(),
                SearchResultDisplayStrategy = searchResultDisplayStrategyBuilder
                    .Build(),
                SearchIndices = new[]
                {
                    searchIndexBuilder.Build()
                },
                SearchPlanInterpreter = searchPlanInterpreterBuilder.Build()
            };

            
        }
    }
}