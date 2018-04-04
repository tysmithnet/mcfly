using System.Linq;
using FluentAssertions;
using McFly.Core;
using McFly.Server.Data.Search;
using Xunit;

namespace McFly.Server.Data.SqlServer.Test
{
    public class FrameCriterionVisitor_Should
    {
        [Fact]
        public void Create_The_Correct_Expression_Tree_For_And()
        {
            var visitor = new FrameCriterionVisitor();
            var criteria1 = new RegisterEqualsCriterion(Register.Rax, ((ulong)0).ToByteArray());
            var criteria2 = new RegisterEqualsCriterion(Register.Rbx, ((ulong)1).ToByteArray());
            var and = new AndCriterion(new[] {criteria1, criteria2});
            var f = visitor.Visit(and);
            var builder = new ContextFactoryBuilder();
            var frame = new FrameEntity
            {
                Rax = ((ulong) 0).ToByteArray(),
                Rbx = ((ulong) 1).ToByteArray()
            };
            var frame2 = new FrameEntity
            {
                Rax = ((ulong) 1).ToByteArray(),
                Rbx = ((ulong) 1).ToByteArray()
            };
            builder.WithFrame(frame).WithFrame(frame2);
            var method = f.Compile();
            new[] {frame, frame2}.Single(x => method(x)).Should().Be(frame);
        }

        [Fact]
        public void Create_The_Correct_Expression_Tree_For_Or()
        {
            var visitor = new FrameCriterionVisitor();
            var criteria1 = new RegisterEqualsCriterion(Register.Rax, ((ulong)0).ToByteArray());
            var criteria2 = new RegisterEqualsCriterion(Register.Rbx, ((ulong)1).ToByteArray());
            var and = new OrCriterion(new[] { criteria1, criteria2 });
            var f = visitor.Visit(and);
            var builder = new ContextFactoryBuilder();
            var frame = new FrameEntity
            {
                Rax = ((ulong)0).ToByteArray(),
                Rbx = ((ulong)1).ToByteArray()
            };
            var frame2 = new FrameEntity
            {
                Rax = ((ulong)1).ToByteArray(),
                Rbx = ((ulong)1).ToByteArray()
            };
            builder.WithFrame(frame).WithFrame(frame2);
            var method = f.Compile();
            new[] {frame, frame2}.Where(x => method(x)).SequenceEqual(new[] {frame, frame2}).Should().BeTrue();
        }
    }
}