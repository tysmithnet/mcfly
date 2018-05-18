using System;
using System.Collections.Generic;
using FluentAssertions;
using McFly.WinDbg.Search;
using Xunit;

namespace McFly.WinDbg.Test.Search
{
    public class SearchRequest_Should
    {
        [Fact]
        public void Allow_Search_Filters_To_Be_Added()
        {
            var request = new SearchRequest("name", new List<SearchFilter>());
            request.AddSearchFilter(new SearchFilter());
        }

        [Fact]
        public void Require_An_Index()
        {
            Action a = () => new SearchRequest(null, new List<SearchFilter>());
            Action a2 = () => new SearchRequest("name", null);

            a.Should().Throw<ArgumentNullException>();
            a2.Should().Throw<ArgumentNullException>();
        }
    }
}