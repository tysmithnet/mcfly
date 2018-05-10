using System.Collections.Generic;
using FluentAssertions;
using McFly.Server.Core;
using McFly.WinDbg.Search;
using Xunit;

namespace McFly.WinDbg.Test.Search
{
    public class SearchRequestConverter_Should
    {
        [Fact]
        public void Convert_The_Request_Correctly()
        {
            var converter = new SearchRequestConverter();

            var searchRequest = new SearchRequest("frame", new []{new SearchFilter()
            {
                Command = "where",
                Args = new List<string>()
                {
                    "rax", "-eq", "10"
                }
            }, });
            converter.Convert(searchRequest).Type.Should().BeOfType<TerminalSearchCriterionDto>();
        }
    }
}
