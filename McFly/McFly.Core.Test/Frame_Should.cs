using System;
using FluentAssertions;
using Xunit;

namespace McFly.Core.Test
{
    public class Frame_Should
    {
        private readonly Frame _frame1 = new Frame
        {
            Id = Guid.Parse("dc2ee39a-23e6-4090-a4f4-e62377c42087"),
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
            Id = Guid.Parse("dc2ee39a-23e6-4090-a4f4-e62377c42087"),
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

        private readonly Frame _frame5 = new Frame
        {
            Position = new Position(11, 11),
            ThreadId = 401,
            DisassemblyLine = new DisassemblyLine(0x100, new byte[] { 0x10, 0x11 }, "mov", "r8,r9"),
            RegisterSet = new RegisterSet
            {
                Rax = 2,
                Rbx = 4,
                Rcx = 6,
                Rdx = 8
            },
            StackTrace = new StackTrace(new[]
            {
                new StackFrame(0x400, 0x700, "mod", "helloworld", 0x12),
                new StackFrame(0x420, 0x701, "mod", "helloworld", 0x13)
            })
        };

        private readonly Frame _frame6 = new Frame
        {
            Position = new Position(11, 11),
            ThreadId = 401,
            DisassemblyLine = new DisassemblyLine(0x100, new byte[] { 0x10, 0x11 }, "mov", "r8,r9"),
            RegisterSet = new RegisterSet
            {
                Rax = 2,
                Rbx = 4,
                Rcx = 6,
                Rdx = 8
            },
            StackTrace = new StackTrace(new[]
            {
                new StackFrame(0x400, 0x700, "mod", "helloworld2", 0x12),
                new StackFrame(0x420, 0x701, "mod", "helloworld2", 0x13)
            })
        };

        private readonly Frame _frame7 = new Frame
        {
            Position = new Position(11, 11),
            ThreadId = 402,
            DisassemblyLine = new DisassemblyLine(0x100, new byte[] { 0x10, 0x11 }, "mov", "r8,r9"),
            RegisterSet = new RegisterSet
            {
                Rax = 2,
                Rbx = 4,
                Rcx = 6,
                Rdx = 8
            },
            StackTrace = new StackTrace(new[]
            {
                new StackFrame(0x400, 0x700, "mod", "helloworld2", 0x12),
                new StackFrame(0x420, 0x701, "mod", "helloworld2", 0x13)
            })
        };

        private readonly Frame _frame8 = new Frame
        {
            Position = new Position(11, 11),
            ThreadId = 402,
            DisassemblyLine = new DisassemblyLine(0x100, new byte[] { 0x10, 0x11, 0x12 }, "mov", "r8,r9"),
            RegisterSet = new RegisterSet
            {
                Rax = 2,
                Rbx = 4,
                Rcx = 6,
                Rdx = 8
            },
            StackTrace = new StackTrace(new[]
            {
                new StackFrame(0x400, 0x700, "mod", "helloworld2", 0x12),
                new StackFrame(0x420, 0x701, "mod", "helloworld2", 0x13)
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
            Action a = () => _frame1.CompareTo(new object());
            a.Should().Throw<ArgumentException>();
            _frame1.CompareTo(null).Should().Be(1);
            _frame1.CompareTo(_frame1).Should().Be(0);
            _frame1.CompareTo((object) _frame1).Should().Be(0);
            _frame1.CompareTo((object) null).Should().Be(1);
        }

        [Fact]
        public void Exhibit_Entity_Equality_By_Default()
        {
            _frame1.Equals(null).Should().BeFalse();
            _frame1.Equals((object) null).Should().BeFalse();
            _frame1.Equals(_frame1).Should().BeTrue();
            _frame1.Equals((object) _frame1).Should().BeTrue();
            _frame1.Equals(_frame2).Should().BeTrue();
            _frame1.Equals((object)_frame2).Should().BeTrue();
            _frame1.Equals(new object()).Should().BeFalse();
            _frame1.GetHashCode().Should().Be(_frame2.GetHashCode());
            _frame1.GetHashCode().Should().NotBe(_frame3.GetHashCode());
        }

        [Fact]
        public void Indicate_Id_Is_Set_When_Id_Is_Not_Empty()
        {
            _frame1.IsIdSet.Should().BeTrue();
            new Frame().IsIdSet.Should().BeFalse();
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

        [Fact]
        public void Offer_Value_Equality()
        {
            _frame1.ValueEquals(null).Should().BeFalse();
            _frame1.ValueEquals(_frame1).Should().BeTrue();
            _frame1.ValueEquals(_frame2).Should().BeTrue();
            _frame1.ValueEquals(_frame3).Should().BeFalse();
            _frame4.ValueEquals(_frame5).Should().BeFalse();
            _frame5.ValueEquals(_frame6).Should().BeFalse();
            _frame6.ValueEquals(_frame7).Should().BeFalse();
            _frame7.ValueEquals(_frame8).Should().BeFalse();
        }
    }
}