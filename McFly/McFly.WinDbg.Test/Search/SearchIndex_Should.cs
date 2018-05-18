using FluentAssertions;
using McFly.WinDbg.Search;
using Xunit;

namespace McFly.WinDbg.Test.Search
{
    public class SearchIndex_Should
    {
        [Fact]
        public void Have_Correct_Short_Names_For_Indices()
        {
            SearchIndex.Frame.ShortName.Should().Be("frame");
        }
    }
}
