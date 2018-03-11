using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace McFly.Core.Tests
{
    public class Position_Should
    {
        [Fact]
        public void Not_Allow_Negative_Values()
        {
            // arrange
            var position = new Position(0, 0);
            Action constructorTestHigh = () => new Position(-1, 0);
            Action constructorTestLow = () => new Position(0, -1);
            Action highTest = () => position.High = -1;
            Action lowTest = () => position.Low = -1;

            // act
            // assert
            constructorTestHigh.Should().Throw<ArgumentOutOfRangeException>("High cannot be negative");
            constructorTestLow.Should().Throw<ArgumentOutOfRangeException>("Low cannot be negative");
            highTest.Should().Throw<ArgumentOutOfRangeException>("High cannot be negative");
            lowTest.Should().Throw<ArgumentOutOfRangeException>("Low cannot be negative");
        }

        [Fact]
        public void Parse_Correctly()
        {
            // arrange
            var position = Position.Parse("abc:123");
            var position2 = Position.Parse("ABC:123");
            Action throws = () => Position.Parse("hello");

            // act
            // assert
            position.Equals(new Position(0xabc, 0x123)).Should().BeTrue("Positions use hex");
            position.Equals(new Position(0xabc, 0x123)).Should().BeTrue("Positions use hex and case doesn't matter");
            throws.Should().Throw<FormatException>("Input should be in the form xxx:xxx");
        }

        [Fact]
        public void Render_ToString_Correctly()
        {
            // arrange
            var zero = new Position(0, 0);
            var rand = new Position(0x123, 0xabc);

            // act
            // assert
            zero.ToString().Should().Be("0:0", "Zeros show up as zeros");
            rand.ToString().Should().Be("123:ABC", "Positions are upper case hex pairs separated by :");
        }

        [Fact]
        public void Demonstrate_Field_Equality()
        {
            // arrange
            var left = new Position(123, 456);
            var left2 = new Position(0, 0);
            var right = new Position(123, 456);
            var right2 = new Position(123, 457);
            var comp = Position.HighLowThreadIdComparer;

            // act
            // assert
            (left == right).Should().Be(true, " == should be overloaded");
            (left != right).Should().Be(false, " == should be overloaded");
            left.Equals((object)null).Should().Be(false, "Object equals  operator should be overloaded");
            left.Equals((object)left).Should().Be(true, "Object equals  operator should be overloaded");
            left.Equals((object)right).Should().Be(true, "Object equals should be overriden");
            left.Equals((object) 3).Should().Be(false, "Object equals should be overriden");
            left.Equals((Position)null).Should().Be(false, "Position equals  operator should be overloaded");
            left.Equals((Position)left).Should().Be(true, "Position equals  operator should be overloaded");
            left.Equals((Position)right).Should().Be(true, "Position equals should be overriden");
            left.Equals(right).Should().Be(true, "Position equals should be overriden");
            (left < right).Should().Be(false, "< operator should be overriden");
            (left2 < right).Should().Be(true, "< operator should be overriden");
            (left > right).Should().Be(false, "> operator should be overriden");
            (right2 > right).Should().Be(true, "> operator should be overriden");
            (left <= right).Should().Be(true, "<= operator should be overriden");
            (left >= right).Should().Be(true, ">= operator should be overriden");
            left.CompareTo(left).Should().Be(0, "CompareTo should be implemented");
            left.CompareTo(null).Should().Be(1, "CompareTo should be implemented");
            comp.Equals(left, left).Should().BeTrue("IEquatable should be implemented");
            comp.GetHashCode(left).Should().Be(left.GetHashCode(), "The same object should have the same hash code");
        }
    }
}
