using System;
using FluentAssertions;
using Xunit;

namespace McFly.Core.Tests
{
    public class Frame_Should
    {
        private readonly Frame _frame1 = new Frame
        {
            Position = new Position(10, 11),
            ThreadId = 400,
            DisassemblyLine = new DisassemblyLine(0x100, new byte[] {0x10, 0x11}, "mov", "r8,r9"),
            RegisterSet = new RegisterSet
            {
                Rax = 1,
                Rbx = 2,
                Rcx = 3,
                Rdx = 4
            },
            StackTrace = new StackTrace(new[]
            {
                new StackFrame(0x400, 0x700, "mod", "helloworld", 0x12),
                new StackFrame(0x420, 0x701, "mod", "helloworld", 0x13)
            })
        };

        private readonly Frame _frame2 = new Frame
        {
            Position = new Position(10, 11),
            ThreadId = 400,
            DisassemblyLine = new DisassemblyLine(0x100, new byte[] {0x10, 0x11}, "mov", "r8,r9"),
            RegisterSet = new RegisterSet
            {
                Rax = 1,
                Rbx = 2,
                Rcx = 3,
                Rdx = 4
            },
            StackTrace = new StackTrace(new[]
            {
                new StackFrame(0x400, 0x700, "mod", "helloworld", 0x12),
                new StackFrame(0x420, 0x701, "mod", "helloworld", 0x13)
            })
        };

        private readonly Frame _frame3 = new Frame
        {
            Position = new Position(11, 11),
            ThreadId = 400,
            DisassemblyLine = new DisassemblyLine(0x100, new byte[] {0x10, 0x11}, "mov", "r8,r9"),
            RegisterSet = new RegisterSet
            {
                Rax = 1,
                Rbx = 2,
                Rcx = 3,
                Rdx = 4
            },
            StackTrace = new StackTrace(new[]
            {
                new StackFrame(0x400, 0x700, "mod", "helloworld", 0x12),
                new StackFrame(0x420, 0x701, "mod", "helloworld", 0x13)
            })
        };

        private readonly Frame _frame4 = new Frame
        {
            Position = new Position(11, 11),
            ThreadId = 401,
            DisassemblyLine = new DisassemblyLine(0x100, new byte[] {0x10, 0x11}, "mov", "r8,r9"),
            RegisterSet = new RegisterSet
            {
                Rax = 1,
                Rbx = 2,
                Rcx = 3,
                Rdx = 4
            },
            StackTrace = new StackTrace(new[]
            {
                new StackFrame(0x400, 0x700, "mod", "helloworld", 0x12),
                new StackFrame(0x420, 0x701, "mod", "helloworld", 0x13)
            })
        };

        [Fact]
        public void Be_Comparable_By_Position_Then_Frame()
        {
            // arrange
            // act
            // assert
            (_frame1 < _frame3).Should().BeTrue();
            (_frame3 <= _frame4).Should().BeTrue();
            (_frame3 > _frame1).Should().BeTrue();
            (_frame4 >= _frame3).Should().BeTrue();
            _frame1.CompareTo(_frame2).Should().Be(0);
            _frame1.CompareTo((object) _frame3).Should().Be(-1);
        }

        [Fact]
        public void Exhibit_Value_Equality()
        {
            // arrange
            // act
            // assert
            _frame1.Equals(_frame2).Should().BeTrue();
            _frame1.Equals((object) _frame2).Should().BeTrue();
            (_frame1 == _frame2).Should().BeTrue();
            _frame1.GetHashCode().Should().Be(_frame2.GetHashCode());
        }

        [Fact]
        public void Not_Allow_Invalid_Thread_Ids()
        {
            // arrange
            var frame = new Frame();

            // act
            // assert
            frame.Invoking(f => f.ThreadId = -1).Should()
                .Throw<ArgumentOutOfRangeException>("Thread ids are non negative");
        }
    }
}