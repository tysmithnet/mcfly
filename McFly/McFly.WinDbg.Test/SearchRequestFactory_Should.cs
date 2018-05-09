using System;
using System.Linq;
using FluentAssertions;
using McFly.WinDbg.Search;
using Xunit;

namespace McFly.WinDbg.Test
{
    public class SearchRequestFactory_Should
    {
        [Fact]
        public void Create_The_Correct_Search_Request()
        {
            var fac = new SearchRequestFactory();
            fac.Create("frame".Split(' ')).SearchFilters.Should().BeEmpty();
            var request = fac.Create(new[]
                {"frame", "|", "register", "rax", "-eq", "10", "|", "stack", "-contains", "findme"});
            request.SearchFilters.Should().HaveCount(2);
            request.SearchFilters.ElementAt(0).Command.Should().Be("register");
            request.SearchFilters.ElementAt(0).Args.SequenceEqual(new[] {"rax", "-eq", "10"}).Should().BeTrue();
            request.SearchFilters.ElementAt(1).Command.Should().Be("stack");
            request.SearchFilters.ElementAt(1).Args.SequenceEqual(new[] {"-contains", "findme"}).Should().BeTrue();
        }

        [Fact]
        public void Throw_If_Invalid_Args_Passed()
        {
            var fac = new SearchRequestFactory();
            Action a = () => fac.Create(null);
            Action a2 = () => fac.Create(new string[0]);

            a.Should().Throw<ArgumentNullException>();
            a2.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}