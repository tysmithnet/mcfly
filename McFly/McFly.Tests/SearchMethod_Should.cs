using System.Collections.Generic;
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

    public class SearchPlanInterpreter_Should // todo: move to SQL data project
    {
        public void Generate_The_Correct_Sql_Statement()
        {
            var initial = new InitialSearch()
            {
                Start = new Position(1,1),
                End = new Position(8, 0),
            };
            var plan = new SearchPlan();
        }
    }
}