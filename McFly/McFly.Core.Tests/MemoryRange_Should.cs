using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators;
using FluentAssertions;
using Xunit;

namespace McFly.Core.Tests
{
    public class MemoryRange_Should
    {
        [Fact]
        public void Not_Allow_Invalid_Memory_Ranges()
        {
            // arrange
            Action throws = () => new MemoryRange(100, 0);

            // act
            // assert
            throws.Should()
                .Throw<ArgumentOutOfRangeException>("The low address cannot be larger than the high address");
        }

        [Fact]
        public void Exhibit_Value_Equality_And_Comparison()
        {
            var m1 = new MemoryRange(0, 0);
            var m2 = new MemoryRange(0, 0);
            var m3 = new MemoryRange(1, 2);
            var m4 = new MemoryRange(1, 3);
            var m5 = new MemoryRange(2, 2);

            m1.Equals(m2).Should().BeTrue();
            m1.Equals((object)m2).Should().BeTrue();
            m1.CompareTo(m2).Should().Be(0);
            m1.CompareTo((object)m2).Should().Be(0);
            (m1 == m2).Should().BeTrue();
            (m1 != m4).Should().BeTrue();
            m1.GetHashCode().Should().Be(m2.GetHashCode());
            (m2 < m3).Should().BeTrue();
            (m2 <= m4).Should().BeTrue();
            (m4 > m3).Should().BeTrue();
            (m5 >= m4).Should().BeTrue();
        }
    }
}
