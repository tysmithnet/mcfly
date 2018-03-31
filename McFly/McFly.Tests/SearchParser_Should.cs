using System.Collections.Generic;
using FluentAssertions;
using McFly.Core;
using Xunit;

namespace McFly.Tests
{
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
            var kernel32Expected = new SearchPlan(new InitialSearch(){SearchTerm = "kernel32"}, new List<SearchFilter>());
            var whereExpected = new SearchPlan(new InitialSearch(), new []
            {
                new SearchFilter()
                {
                    Command = "where",
                    Args = new List<string>()
                    {
                        "rax", "-eq", "1", "mod", "-contains", "32"
                    }
                },
            });
            var whereFieldsExpected = new SearchPlan(new InitialSearch(), new[]
            {
                new SearchFilter()
                {
                    Command = "where",
                    Args = new List<string>()
                    {
                        "rax", "-eq", "1"
                    }
                },
                new SearchFilter()
                {
                    Command = "fields",
                    Args = new List<string>()
                    {
                        "rax", "rip", "mod", "fun"
                    }
                },
            });
            var empty = searchParser.Parse("".Split(' '));
            var startEnd = searchParser.Parse("-s 0:0 -e 100:0".Split(' '));
            var kernel32 = searchParser.Parse("kernel32".Split(' '));
            var where = searchParser.Parse("| where rax -eq 1 mod -contains 32".Split(' '));
            var whereFields = searchParser.Parse("| where rax -eq 1 | fields rax rip mod fun".Split(' '));

            empty.Should().Be(emptyExpected);
            startEnd.Should().Be(startEndExpected);
            kernel32.Should().Be(kernel32Expected);
            where.Should().Be(whereExpected);
            whereFields.Should().Be(whereFieldsExpected);
        }
    }
}