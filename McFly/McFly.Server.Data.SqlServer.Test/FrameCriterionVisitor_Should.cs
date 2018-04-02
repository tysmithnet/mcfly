using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using McFly.Core;
using Xunit;

namespace McFly.Server.Data.SqlServer.Test
{
    public class FrameCriterionVisitor_Should
    {
        [Fact]
        public void Create_The_Correct_Expression_Tree_For_RegisterEqual()
        {
            var visitor = new FrameCriterionVisitor();
            var criteria = new RegisterEqualsCriterion(Register.Rax, 0);
            var f = visitor.Visit(criteria);
            var frame = new FrameEntity()
            {
                Rax = 0
            };
            var frame2 = new FrameEntity()
            {
                Rax = 1
            };
            f(frame).Should().BeTrue();
            f(frame2).Should().BeFalse();
        }
    }
}
