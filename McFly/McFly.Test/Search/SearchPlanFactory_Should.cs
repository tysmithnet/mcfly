using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using McFly.WinDbg.Search;
using Xunit;

namespace McFly.Test.Search
{
    public class SearchPlanFactory_Should
    {
        [Fact]
        public void Create_The_Correct_Search_Plan()
        {
            var fac = new SearchRequestFactory();

            var res = fac.Create("frame | reg rax -eq 0 OR rbx -eq 1 | note text -contains encrypt".Split());

            res.Index.Should().Be("frame");
            res.SearchFilters.SequenceEqual(new[]
            {
                new SearchFilter
                {
                    Command = "reg",
                    Args = new List<string>
                    {
                        "rax",
                        "-eq",
                        "0",
                        "OR",
                        "rbx",
                        "-eq",
                        "1"
                    }
                },
                new SearchFilter
                {
                    Command = "note",
                    Args = new List<string>
                    {
                        "text",
                        "-contains",
                        "encrypt"
                    }
                }
            }).Should().BeTrue();
        }
    }
}