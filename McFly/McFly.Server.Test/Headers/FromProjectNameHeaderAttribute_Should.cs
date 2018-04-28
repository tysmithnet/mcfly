using System.Web.Http.Controllers;
using FluentAssertions;
using McFly.Server.Headers;
using Xunit;

namespace McFly.Server.Test.Headers
{
    public class FromProjectNameHeaderAttribute_Should
    {
        [Fact]
        public void Should_Have_Correct_Name()
        {
            var header = new FromProjectNameHeaderAttribute();
            header.HeaderName.Should().Be("X-Project-Name");
        }

        [Fact]
        public void Should_Get_Correct_Binding()
        {
            var header = new FromProjectNameHeaderAttribute();
            header.GetBinding(new ReflectedHttpParameterDescriptor()).Should().BeOfType<FromHeaderBinding>();
        }
    }
}