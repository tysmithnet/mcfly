using FluentAssertions;
using Xunit;

namespace McFly.Core.Test
{
    public class StackTrace_Should
    {
        [Fact]
        public void Exhibit_Value_Equality()
        {
            var stack0 = new StackTrace(new StackFrame[0]);
            var stack1 = new StackTrace(new StackFrame[0]);
            var stack2 = new StackTrace(new[]
            {
                new StackFrame(100, null, null, null, 0)
            });
            var stack3 = new StackTrace(new[]
            {
                new StackFrame(100, null, null, null, 0)
            });
            var stack4 = new StackTrace(new[]
            {
                new StackFrame(101, null, null, null, 0)
            });
            stack0.Equals(stack0).Should().BeTrue();
            stack0.Equals(null).Should().BeFalse();
            stack0.Equals((object)null).Should().BeFalse();
            stack0.Equals(new object()).Should().BeFalse();
            stack1.Equals(stack0).Should().BeTrue();
            stack2.Equals(stack1).Should().BeFalse();
            stack2.Equals(stack3).Should().BeTrue();
            stack3.Equals(stack4).Should().BeFalse();
            stack0.GetHashCode().Should().Be(stack1.GetHashCode());
            stack2.GetHashCode().Should().Be(stack3.GetHashCode());
            stack0.GetHashCode().Should().NotBe(stack3.GetHashCode());
        }
    }
}