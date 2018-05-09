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