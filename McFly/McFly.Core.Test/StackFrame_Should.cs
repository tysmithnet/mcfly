using FluentAssertions;
using Xunit;

namespace McFly.Core.Test
{
    public class StackFrame_Should
    {
        [Fact]
        public void Exhibit_Value_Equality()
        {
            var frame0 = new StackFrame(0, null, null, null, 0);
            var frame1 = new StackFrame(0, null, null, null, 0);
            var frame2 = new StackFrame(0, ulong.MaxValue, "a", "foo", 10);
            var frame3 = new StackFrame(0, ulong.MaxValue, "a", "foo", 10);
            var frame4 = new StackFrame(0, 123, "abc", "def", 1110);
            var frame5 = new StackFrame(1, 123, "abc", "def", 1110);
            var frame6 = new StackFrame(0, 123, "cba", "def", 1110);
            var frame7 = new StackFrame(0, 123, "abc", "def", 1220);
            var frame8 = new StackFrame(0, 123, "abc", "fed", 1110);

            frame0.Equals(frame0).Should().BeTrue();
            frame0.Equals((object) frame0).Should().BeTrue();
            frame0.Equals(null).Should().BeFalse();
            frame0.Equals((object)null).Should().BeFalse();
            frame0.Equals(new object()).Should().BeFalse();
            frame0.Equals(frame1).Should().BeTrue();
            frame0.Equals(frame2).Should().BeFalse();
            frame2.Equals(frame3).Should().BeTrue();
            frame3.Equals(frame4).Should().BeFalse();
            frame4.Equals(frame5).Should().BeFalse();
            frame4.Equals(frame6).Should().BeFalse();
            frame4.Equals(frame7).Should().BeFalse();
            frame4.Equals(frame8).Should().BeFalse();
        }
    }
}