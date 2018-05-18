using FluentAssertions;
using McFly.Server.Core;
using McFly.Server.Search;
using Xunit;

namespace McFly.Server.Test.Search
{
    public class RegisterCriterionConverter_Should
    {
        [Fact]
        public void Correctly_Repond_To_Conversion_Requests()
        {
            var converter = new RegisterCriterionConverter();

            converter.CanConvert(new TerminalSearchCriterionDto
            {
                Type = "register"
            }).Should().BeTrue();
        }
    }
}