using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace McFly.Core.Test
{
    public class RegisterSet_Should
    {
        
        [Fact]
        public void Be_Equal_When_Non_Calculated_Properties_Are_Equal()
        {
            {
                var r1 = new RegisterSet();
                var r2 = new RegisterSet();
                r1.Equals(r1).Should().BeTrue();
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }

            {
                var r1 = new RegisterSet()
                {
                     Af = true
                };
                var r2 = new RegisterSet()
                {
                    Af = true
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }

            {
                var r1 = new RegisterSet()
                {
                    Ah = byte.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Ah = byte.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }

            {
                var r1 = new RegisterSet()
                {
                    Al = byte.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Al = byte.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }

            {
                var r1 = new RegisterSet()
                {
                    Ax = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Ax = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }

            {
                var r1 = new RegisterSet()
                {
                    Bh = byte.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Bh = byte.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Bl = byte.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Bl = byte.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                   Bl = byte.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Bl = byte.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }

            {
                var r1 = new RegisterSet()
                {
                    Bp = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Bp = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }

            {
                var r1 = new RegisterSet()
                {
                    Bpl = byte.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Bpl = byte.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }

            {
                var r1 = new RegisterSet()
                {
                    Brfrom = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Brfrom = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }

            {
                var r1 = new RegisterSet()
                {
                    Brto = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Brto = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }

            {
                var r1 = new RegisterSet()
                {
                    Bx = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Bx = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }

            {
                var r1 = new RegisterSet()
                {
                    Cf = true
                };
                var r2 = new RegisterSet()
                {
                    Cf = true
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ch = byte.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Ch = byte.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Cl = byte.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Cl = byte.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Cs = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Cs = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Cx = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Cx = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Df = true
                };
                var r2 = new RegisterSet()
                {
                    Df = true
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Dh = byte.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Dh = byte.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Di = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Di = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Dil = byte.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Dil = byte.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Dl = byte.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Dl = byte.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Dr0 = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Dr0 = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Dr1 = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Dr1 = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Dr2 = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Dr2 = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Dr3 = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Dr3 = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Dr6 = ulong.MaxValue

                };
                var r2 = new RegisterSet()
                {
                    Dr6 = ulong.MaxValue

                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Dr7 = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Dr7 = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {    Dx = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Dx = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {    Eax = uint.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Eax = uint.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ebx = uint.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Ebx = uint.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ecx = uint.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Ecx = uint.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {     
                    Edx = uint.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Edx = uint.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Efl = uint.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Efl = uint.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Edi = uint.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Edi = uint.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Eip = uint.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Eip = uint.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ebp = uint.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Ebp = uint.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Es = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Es = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                   Esi = uint.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Esi = uint.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Esp = uint.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Esp = uint.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Exto = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Exto = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Fs = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Fs = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Fl = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Fl = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Fpcw = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Fpcw = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Fpsw = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Fpsw = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Fptw = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Fptw = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Fopcode = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Fopcode = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Fpip = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Fpip = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Fpipsel = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Fpipsel = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Fpdp = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Fpdp = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Fpdpsel = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Fpdpsel = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Gs = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Gs = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Iopl = 3
                };
                var r2 = new RegisterSet()
                {
                    Iopl = 3
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    If = true
                };
                var r2 = new RegisterSet()
                {
                    If = true
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ip = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Ip = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Mxcsr = uint.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Mxcsr = uint.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Mm0 = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Mm0 = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Mm1 = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Mm1 = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Mm2 = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Mm2 = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Mm3 = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Mm3 = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Mm4 = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Mm4 = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Mm5 = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Mm5 = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Mm6 = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Mm6 = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Mm7 = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Mm7 = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Of = true
                };
                var r2 = new RegisterSet()
                {
                    Of = true
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Pf = true
                };
                var r2 = new RegisterSet()
                {
                    Pf = true
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Rax = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Rax = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Rbx = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Rbx = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Rcx = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Rcx = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Rdx = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Rdx = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Rdi = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Rdi = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Rsi = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Rsi = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Rsp = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Rsp = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Rbp = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Rbp = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    R8 = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R8 = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    R8d = uint.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R8d = uint.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    R8w = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R8w = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    R8b = byte.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R8b = byte.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }


            {
                var r1 = new RegisterSet()
                {
                    R9 = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R9 = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    R9d = uint.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R9d = uint.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    R9w = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R9w = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    R9b = byte.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R9b = byte.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }

            {
                var r1 = new RegisterSet()
                {
                    R10 = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R10 = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    R10d = uint.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R10d = uint.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    R10w = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R10w = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    R10b = byte.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R10b = byte.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }

            {
                var r1 = new RegisterSet()
                {
                    R11 = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R11 = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    R11d = uint.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R11d = uint.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    R11w = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R11w = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    R11b = byte.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R11b = byte.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }

            {
                var r1 = new RegisterSet()
                {
                    R13 = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R13 = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    R13d = uint.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R13d = uint.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    R13w = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R13w = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    R13b = byte.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R13b = byte.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }

            {
                var r1 = new RegisterSet()
                {
                    R14 = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R14 = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    R14d = uint.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R14d = uint.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    R14w = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R14w = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    R14b = byte.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R14b = byte.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }

            {
                var r1 = new RegisterSet()
                {
                    R15 = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R15 = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    R15d = uint.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R15d = uint.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    R15w = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R15w = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    R15b = byte.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    R15b = byte.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                   Rip = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Rip = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    St0 = Enumerable.Range(1, 10).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    St0 = Enumerable.Range(1, 10).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                     St1 = Enumerable.Range(1, 10).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    St1 = Enumerable.Range(1, 10).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    St2 = Enumerable.Range(1, 10).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    St2 = Enumerable.Range(1, 10).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    St3 = Enumerable.Range(1, 10).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    St3 = Enumerable.Range(1, 10).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    St4 = Enumerable.Range(1, 10).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    St4 = Enumerable.Range(1, 10).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                     St5 = Enumerable.Range(1, 10).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                     St5 = Enumerable.Range(1, 10).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    St6 = Enumerable.Range(1, 10).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    St6 = Enumerable.Range(1, 10).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                       St7 = Enumerable.Range(1, 10).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                     St7 = Enumerable.Range(1, 10).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                     Sf = true
                };
                var r2 = new RegisterSet()
                {
                    Sf = true
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                      Si = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                     Si = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                     Sil = byte.MaxValue
                };
                var r2 = new RegisterSet()
                {
                     Sil = byte.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Spl = byte.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Spl = byte.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ss = ushort.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Ss = ushort.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Tf = true
                };
                var r2 = new RegisterSet()
                {
                    Tf = true
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Vif = true
                };
                var r2 = new RegisterSet()
                {
                    Vif = true
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                     Xmm0 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Xmm0 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm0l = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm0l = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                      Xmm0h = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm0h = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm1 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Xmm1 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm1l = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm1l = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm1h = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm1h = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm2 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Xmm2 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm2l = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm2l = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm2h = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm2h = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm3 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Xmm3 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm3l = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm3l = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm3h = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm3h = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm4 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Xmm4 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm4l = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm4l = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm4h = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm4h = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm5 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Xmm5 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm5l = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm5l = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm5h = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm5h = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm6 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Xmm6 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm6l = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm6l = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm6h = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm6h = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm7 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Xmm7 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm7l = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm7l = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm7h = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm7h = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm8 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Xmm8 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm8l = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm8l = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm8h = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm8h = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm9 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Xmm9 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm9l = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm9l = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm9h = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm9h = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm10 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Xmm10 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm10l = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm10l = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm10h = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm10h = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm11 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Xmm11 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm11l = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm11l = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm11h = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm11h = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm12 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Xmm12 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm12l = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm12l = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm12h = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm12h = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm13 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Xmm13 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm13l = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm13l = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm13h = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm13h = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm14 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Xmm14 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm14l = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm14l = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm14h = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm14h = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm15 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Xmm15 = Enumerable.Range(0, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm15l = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm15l = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Xmm15h = ulong.MaxValue
                };
                var r2 = new RegisterSet()
                {
                    Xmm15h = ulong.MaxValue
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm0 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm0 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm0h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm0h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm0l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm0l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm1 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm1 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm1h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm1h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm1l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm1l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm2 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm2 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm2h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm2h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm2l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm2l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm3 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm3 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm3h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm3h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm3l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm3l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm4 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm4 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm4h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm4h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm4l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm4l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm5 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm5 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm5h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm5h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm5l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm5l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm6 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm6 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm6h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm6h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm6l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm6l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm7 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm7 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm7h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm7h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm7l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm7l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm8 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm8 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm8h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm8h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm8l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm8l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm9 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm9 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm9h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm9h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm9l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm9l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm10 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm10 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm10h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm10h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm10l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm10l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm11 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm11 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm11h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm11h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm11l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm11l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm12 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm12 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm12h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm12h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm12l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm12l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm13 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm13 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm13h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm13h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm13l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm13l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm14 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm14 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm14h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm14h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm14l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm14l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm15 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm15 = Enumerable.Range(1, 32).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm15h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm15h = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Ymm15l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Ymm15l = Enumerable.Range(1, 16).Select(x => Convert.ToByte(x)).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                   Zf = true
                };
                var r2 = new RegisterSet()
                {
                    Zf = true
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                   Af = true,
                   Ymm0 = Enumerable.Range(1,32).Select(Convert.ToByte).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Af = true,
                    Ymm0 = Enumerable.Range(1, 32).Select(Convert.ToByte).ToArray()
                };
                r1.Equals(r2).Should().BeTrue();
                r1.GetHashCode().Should().Be(r2.GetHashCode());
            }
            {
                var r1 = new RegisterSet()
                {
                    Af = true,
                    Ymm0 = Enumerable.Range(1, 32).Select(Convert.ToByte).ToArray()
                };
                var r2 = new RegisterSet()
                {
                    Af = false,
                    Ymm0 = Enumerable.Range(1, 32).Select(Convert.ToByte).ToArray()
                };
                r1.Equals(r2).Should().BeFalse();
                r1.GetHashCode().Should().NotBe(r2.GetHashCode());
            }
        }
    }
}