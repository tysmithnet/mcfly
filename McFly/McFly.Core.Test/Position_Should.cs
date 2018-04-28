using System;
using FluentAssertions;
using Xunit;

namespace McFly.Core.Test
{
    public class Position_Should
    {
        [Fact]
        public void Demonstrate_Field_Equality()
        {
            // arrange
            var left = new Position(123, 456);
            var left2 = new Position(0, 0);
            var right = new Position(123, 456);
            var right2 = new Position(123, 457);
            var comp = Position.HighLowComparer;

            // act
            // assert
            (left == right).Should().Be(true, " == should be overloaded");
            (left != right).Should().Be(false, " == should be overloaded");
            left.Equals((object) null).Should().Be(false, "Object equals  operator should be overloaded");
            left.Equals((object) left).Should().Be(true, "Object equals  operator should be overloaded");
            left.Equals((object) right).Should().Be(true, "Object equals should be overriden");
            left.Equals(3).Should().Be(false, "Object equals should be overriden");
            left.Equals(null).Should().Be(false, "Position equals  operator should be overloaded");
            left.Equals(left).Should().Be(true, "Position equals  operator should be overloaded");
            left.Equals(right).Should().Be(true, "Position equals should be overriden");
            left.Equals(right).Should().Be(true, "Position equals should be overriden");
            (left < right).Should().Be(false, "< operator should be overriden");
            (left2 < right).Should().Be(true, "< operator should be overriden");
            (left > right).Should().Be(false, "> operator should be overriden");
            (right2 > right).Should().Be(true, "> operator should be overriden");
            (left <= right).Should().Be(true, "<= operator should be overriden");
            (left >= right).Should().Be(true, ">= operator should be overriden");
            left.CompareTo(left).Should().Be(0, "CompareTo should be implemented");
            left.CompareTo(null).Should().Be(1, "CompareTo should be implemented");
            left.CompareTo(right).Should().Be(0, "Positions should exhibit value equality");
            left.CompareTo(right2).Should().Be(-1, "The low portion is greater");
            left.CompareTo((object)left).Should().Be(0, "CompareTo should be implemented");
            left.CompareTo((object)null).Should().Be(1, "CompareTo should be implemented");
            Action a = () => left.CompareTo(new object());
            a.Should().Throw<ArgumentException>();
            left.CompareTo((object)right).Should().Be(0, "Positions should exhibit value equality");
            left.CompareTo((object)right2).Should().Be(-1, "The low portion is greater");
            comp.Equals(left, left).Should().BeTrue("IEquatable should be implemented");
            comp.GetHashCode(left).Should().Be(left.GetHashCode(), "The same object should have the same hash code");
        }

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
            position2.Equals(new Position(0xabc, 0x123)).Should().BeTrue("Positions use hex and case doesn't matter");
            position.High.Should().Be(0xabc, "The high portion is everything before the :");
            position.Low.Should().Be(0x123, "The low portion is everything after the :");
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
            zero.DebugDisplay.Should().Be("0:0");
        }
    }
}