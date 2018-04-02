using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using McFly.Server.Contract;
using McFly.Server.Search;
using Xunit;

namespace McFly.Server.Test.Search
{
    public class RegisterCriterionConverter_Should
    {
        [Fact]
        public void Correctly_Repond_To_Conversion_Requests()
        {
            //var converter = new RegisterCriterionConverter();

            //converter.CanConvert(new SearchCriterionDto
            //{
            //    Type = ""
            //}).Should().BeTrue();
            true.Should().Be(false);
        }
    }
}
