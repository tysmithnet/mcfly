using FluentAssertions;
using McFly.Core;
using McFly.Server.Search;
using Xunit;

namespace McFly.Server.Data.SqlServer.Test
{
    public class FrameCriterionVisitor_Should
    {
        [Fact]
        public void Create_The_Correct_Expression_Tree_For_And()
        {
            var visitor = new FrameCriterionVisitor();
            var criteria1 = new RegisterEqualsCriterion(Register.Rax, 0);
            var criteria2 = new RegisterEqualsCriterion(Register.Rbx, 1);
            var and = new AndCriterion(new[] {criteria1, criteria2});
            var f = visitor.Visit(and);
            var frame = new FrameEntity
            {
                Rax = 0,
                Rbx = 1
            };
            var frame2 = new FrameEntity
            {
                Rax = 1,
                Rbx = 1
            };
            f(frame).Should().BeTrue();
            f(frame2).Should().BeFalse();
        }

        [Fact]
        public void Create_The_Correct_Expression_Tree_For_RegisterEqual()
        {
            var visitor = new FrameCriterionVisitor();
            var criteria = new RegisterEqualsCriterion(Register.Rax, 0);
            var f = visitor.Visit(criteria);
            var frame = new FrameEntity
            {
                Rax = 0
            };
            var frame2 = new FrameEntity
            {
                Rax = 1
            };
            f(frame).Should().BeTrue();
            f(frame2).Should().BeFalse();
        }

        [Fact]
        public void Create_The_Correct_Expression_Tree_For_RegisterBetween()
        {
            var visitor = new FrameCriterionVisitor();
            var criteria = new RegisterBetweenCriterion(Register.Rax, 0, 10);
            var f = visitor.Visit(criteria);
            var frame = new FrameEntity
            {
                Rax = 0
            };
            var frame2 = new FrameEntity
            {
                Rax = 10
            };
            f(frame).Should().BeTrue();
            f(frame2).Should().BeFalse();
        }
    }
}