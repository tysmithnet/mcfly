using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace McFly.Core.Test
{
    public class RegisterSet_Should
    {
        [Fact]
        public void Not_Throw_When_Assigned_Null()
        {
            var rs = new RegisterSet();
            {
                Action a = () => rs.Rax = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Rcx = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Rdx = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Rbx = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Rsp = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Rbp = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Rsi = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Rdi = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R8 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R9 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R10 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R11 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R12 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R13 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R14 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R15 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Rip = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Efl = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Cs = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ds = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Es = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Fs = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Gs = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ss = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Dr0 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Dr1 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Dr2 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Dr3 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Dr6 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Dr7 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Fpcw = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Fpsw = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Fptw = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.St0 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.St1 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.St2 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.St3 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.St4 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.St5 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.St6 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.St7 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Mm0 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Mm1 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Mm2 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Mm3 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Mm4 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Mm5 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Mm6 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Mm7 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Mxcsr = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm0 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm1 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm2 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm3 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm4 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm5 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm6 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm7 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm8 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm9 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm10 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm11 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm12 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm13 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm14 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm15 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm0l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm1l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm2l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm3l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm4l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm5l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm6l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm7l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm8l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm9l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm10l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm11l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm12l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm13l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm14l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm15l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm0h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm1h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm2h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm3h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm4h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm5h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm6h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm7h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm8h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm9h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm10h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm11h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm12h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm13h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm14h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Xmm15h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm0 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm1 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm2 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm3 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm4 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm5 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm6 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm7 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm8 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm9 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm10 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm11 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm12 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm13 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm14 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm15 = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm0l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm1l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm2l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm3l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm4l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm5l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm6l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm7l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm8l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm9l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm10l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm11l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm12l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm13l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm14l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm15l = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm0h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm1h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm2h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm3h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm4h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm5h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm6h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm7h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm8h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm9h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm10h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm11h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm12h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm13h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm14h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ymm15h = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Exfrom = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Exto = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Brfrom = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Brto = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Eax = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ecx = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Edx = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ebx = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Esp = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ebp = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Esi = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Edi = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R8d = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R9d = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R10d = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R11d = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R12d = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R13d = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R14d = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R15d = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Eip = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ax = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Cx = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Dx = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Bx = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Sp = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Bp = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Si = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Di = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R8w = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R9w = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R10w = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R11w = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R12w = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R13w = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R14w = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R15w = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ip = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Fl = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Al = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Cl = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Dl = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Bl = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Spl = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Bpl = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Sil = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Dil = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R8b = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R9b = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R10b = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R11b = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R12b = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R13b = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R14b = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.R15b = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ah = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Ch = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Dh = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Bh = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Iopl = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Of = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Df = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.If = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Tf = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Sf = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Zf = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Af = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Pf = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Cf = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Vip = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Vif = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Fopcode = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Fpip = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Fpipsel = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Fpdp = null;
                a.Should().NotThrow();
            }
            {
                Action a = () => rs.Fpdpsel = null;
                a.Should().NotThrow();
            }
        }

        [Fact]
        public void Throw_If_Incorrect_Num_Bytes_Assigned()
        {
            var rs = new RegisterSet();
            {
                Action a = () => rs.St0 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.St1 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.St2 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.St3 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.St4 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.St5 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.St6 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.St7 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Xmm0 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Xmm1 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Xmm2 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Xmm3 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Xmm4 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Xmm5 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Xmm6 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Xmm7 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Xmm8 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Xmm9 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Xmm10 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Xmm11 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Xmm12 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Xmm13 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Xmm14 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Xmm15 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm0 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm1 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm2 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm3 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm4 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm5 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm6 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm7 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm8 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm9 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm10 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm11 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm12 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm13 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm14 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm15 = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm0h = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm1h = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm2h = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm3h = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm4h = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm5h = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm6h = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm7h = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm8h = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm9h = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm10h = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm11h = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm12h = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm13h = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm14h = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }
            {
                Action a = () => rs.Ymm15h = new byte[0];
                a.Should().Throw<ArgumentOutOfRangeException>();
            }

        }

        [Fact]
        public void Have_Null_Values_When_Created()
        {
            var rs = new RegisterSet();
            rs.Rax.Should().BeNull();
            rs.Rcx.Should().BeNull();
            rs.Rdx.Should().BeNull();
            rs.Rbx.Should().BeNull();
            rs.Rsp.Should().BeNull();
            rs.Rbp.Should().BeNull();
            rs.Rsi.Should().BeNull();
            rs.Rdi.Should().BeNull();
            rs.R8.Should().BeNull();
            rs.R9.Should().BeNull();
            rs.R10.Should().BeNull();
            rs.R11.Should().BeNull();
            rs.R12.Should().BeNull();
            rs.R13.Should().BeNull();
            rs.R14.Should().BeNull();
            rs.R15.Should().BeNull();
            rs.Rip.Should().BeNull();
            rs.Efl.Should().BeNull();
            rs.Cs.Should().BeNull();
            rs.Ds.Should().BeNull();
            rs.Es.Should().BeNull();
            rs.Fs.Should().BeNull();
            rs.Gs.Should().BeNull();
            rs.Ss.Should().BeNull();
            rs.Dr0.Should().BeNull();
            rs.Dr1.Should().BeNull();
            rs.Dr2.Should().BeNull();
            rs.Dr3.Should().BeNull();
            rs.Dr6.Should().BeNull();
            rs.Dr7.Should().BeNull();
            rs.Fpcw.Should().BeNull();
            rs.Fpsw.Should().BeNull();
            rs.Fptw.Should().BeNull();
            rs.St0.Should().BeNull();
            rs.St1.Should().BeNull();
            rs.St2.Should().BeNull();
            rs.St3.Should().BeNull();
            rs.St4.Should().BeNull();
            rs.St5.Should().BeNull();
            rs.St6.Should().BeNull();
            rs.St7.Should().BeNull();
            rs.Mm0.Should().BeNull();
            rs.Mm1.Should().BeNull();
            rs.Mm2.Should().BeNull();
            rs.Mm3.Should().BeNull();
            rs.Mm4.Should().BeNull();
            rs.Mm5.Should().BeNull();
            rs.Mm6.Should().BeNull();
            rs.Mm7.Should().BeNull();
            rs.Mxcsr.Should().BeNull();
            rs.Xmm0.Should().BeNull();
            rs.Xmm1.Should().BeNull();
            rs.Xmm2.Should().BeNull();
            rs.Xmm3.Should().BeNull();
            rs.Xmm4.Should().BeNull();
            rs.Xmm5.Should().BeNull();
            rs.Xmm6.Should().BeNull();
            rs.Xmm7.Should().BeNull();
            rs.Xmm8.Should().BeNull();
            rs.Xmm9.Should().BeNull();
            rs.Xmm10.Should().BeNull();
            rs.Xmm11.Should().BeNull();
            rs.Xmm12.Should().BeNull();
            rs.Xmm13.Should().BeNull();
            rs.Xmm14.Should().BeNull();
            rs.Xmm15.Should().BeNull();
            rs.Xmm0l.Should().BeNull();
            rs.Xmm1l.Should().BeNull();
            rs.Xmm2l.Should().BeNull();
            rs.Xmm3l.Should().BeNull();
            rs.Xmm4l.Should().BeNull();
            rs.Xmm5l.Should().BeNull();
            rs.Xmm6l.Should().BeNull();
            rs.Xmm7l.Should().BeNull();
            rs.Xmm8l.Should().BeNull();
            rs.Xmm9l.Should().BeNull();
            rs.Xmm10l.Should().BeNull();
            rs.Xmm11l.Should().BeNull();
            rs.Xmm12l.Should().BeNull();
            rs.Xmm13l.Should().BeNull();
            rs.Xmm14l.Should().BeNull();
            rs.Xmm15l.Should().BeNull();
            rs.Xmm0h.Should().BeNull();
            rs.Xmm1h.Should().BeNull();
            rs.Xmm2h.Should().BeNull();
            rs.Xmm3h.Should().BeNull();
            rs.Xmm4h.Should().BeNull();
            rs.Xmm5h.Should().BeNull();
            rs.Xmm6h.Should().BeNull();
            rs.Xmm7h.Should().BeNull();
            rs.Xmm8h.Should().BeNull();
            rs.Xmm9h.Should().BeNull();
            rs.Xmm10h.Should().BeNull();
            rs.Xmm11h.Should().BeNull();
            rs.Xmm12h.Should().BeNull();
            rs.Xmm13h.Should().BeNull();
            rs.Xmm14h.Should().BeNull();
            rs.Xmm15h.Should().BeNull();
            rs.Ymm0.Should().BeNull();
            rs.Ymm1.Should().BeNull();
            rs.Ymm2.Should().BeNull();
            rs.Ymm3.Should().BeNull();
            rs.Ymm4.Should().BeNull();
            rs.Ymm5.Should().BeNull();
            rs.Ymm6.Should().BeNull();
            rs.Ymm7.Should().BeNull();
            rs.Ymm8.Should().BeNull();
            rs.Ymm9.Should().BeNull();
            rs.Ymm10.Should().BeNull();
            rs.Ymm11.Should().BeNull();
            rs.Ymm12.Should().BeNull();
            rs.Ymm13.Should().BeNull();
            rs.Ymm14.Should().BeNull();
            rs.Ymm15.Should().BeNull();
            rs.Ymm0l.Should().BeNull();
            rs.Ymm1l.Should().BeNull();
            rs.Ymm2l.Should().BeNull();
            rs.Ymm3l.Should().BeNull();
            rs.Ymm4l.Should().BeNull();
            rs.Ymm5l.Should().BeNull();
            rs.Ymm6l.Should().BeNull();
            rs.Ymm7l.Should().BeNull();
            rs.Ymm8l.Should().BeNull();
            rs.Ymm9l.Should().BeNull();
            rs.Ymm10l.Should().BeNull();
            rs.Ymm11l.Should().BeNull();
            rs.Ymm12l.Should().BeNull();
            rs.Ymm13l.Should().BeNull();
            rs.Ymm14l.Should().BeNull();
            rs.Ymm15l.Should().BeNull();
            rs.Ymm0h.Should().BeNull();
            rs.Ymm1h.Should().BeNull();
            rs.Ymm2h.Should().BeNull();
            rs.Ymm3h.Should().BeNull();
            rs.Ymm4h.Should().BeNull();
            rs.Ymm5h.Should().BeNull();
            rs.Ymm6h.Should().BeNull();
            rs.Ymm7h.Should().BeNull();
            rs.Ymm8h.Should().BeNull();
            rs.Ymm9h.Should().BeNull();
            rs.Ymm10h.Should().BeNull();
            rs.Ymm11h.Should().BeNull();
            rs.Ymm12h.Should().BeNull();
            rs.Ymm13h.Should().BeNull();
            rs.Ymm14h.Should().BeNull();
            rs.Ymm15h.Should().BeNull();
            rs.Exfrom.Should().BeNull();
            rs.Exto.Should().BeNull();
            rs.Brfrom.Should().BeNull();
            rs.Brto.Should().BeNull();
            rs.Eax.Should().BeNull();
            rs.Ecx.Should().BeNull();
            rs.Edx.Should().BeNull();
            rs.Ebx.Should().BeNull();
            rs.Esp.Should().BeNull();
            rs.Ebp.Should().BeNull();
            rs.Esi.Should().BeNull();
            rs.Edi.Should().BeNull();
            rs.R8d.Should().BeNull();
            rs.R9d.Should().BeNull();
            rs.R10d.Should().BeNull();
            rs.R11d.Should().BeNull();
            rs.R12d.Should().BeNull();
            rs.R13d.Should().BeNull();
            rs.R14d.Should().BeNull();
            rs.R15d.Should().BeNull();
            rs.Eip.Should().BeNull();
            rs.Ax.Should().BeNull();
            rs.Cx.Should().BeNull();
            rs.Dx.Should().BeNull();
            rs.Bx.Should().BeNull();
            rs.Sp.Should().BeNull();
            rs.Bp.Should().BeNull();
            rs.Si.Should().BeNull();
            rs.Di.Should().BeNull();
            rs.R8w.Should().BeNull();
            rs.R9w.Should().BeNull();
            rs.R10w.Should().BeNull();
            rs.R11w.Should().BeNull();
            rs.R12w.Should().BeNull();
            rs.R13w.Should().BeNull();
            rs.R14w.Should().BeNull();
            rs.R15w.Should().BeNull();
            rs.Ip.Should().BeNull();
            rs.Fl.Should().BeNull();
            rs.Al.Should().BeNull();
            rs.Cl.Should().BeNull();
            rs.Dl.Should().BeNull();
            rs.Bl.Should().BeNull();
            rs.Spl.Should().BeNull();
            rs.Bpl.Should().BeNull();
            rs.Sil.Should().BeNull();
            rs.Dil.Should().BeNull();
            rs.R8b.Should().BeNull();
            rs.R9b.Should().BeNull();
            rs.R10b.Should().BeNull();
            rs.R11b.Should().BeNull();
            rs.R12b.Should().BeNull();
            rs.R13b.Should().BeNull();
            rs.R14b.Should().BeNull();
            rs.R15b.Should().BeNull();
            rs.Ah.Should().BeNull();
            rs.Ch.Should().BeNull();
            rs.Dh.Should().BeNull();
            rs.Bh.Should().BeNull();
            rs.Iopl.Should().BeNull();
            rs.Of.Should().BeNull();
            rs.Df.Should().BeNull();
            rs.If.Should().BeNull();
            rs.Tf.Should().BeNull();
            rs.Sf.Should().BeNull();
            rs.Zf.Should().BeNull();
            rs.Af.Should().BeNull();
            rs.Pf.Should().BeNull();
            rs.Cf.Should().BeNull();
            rs.Vip.Should().BeNull();
            rs.Vif.Should().BeNull();
            rs.Fopcode.Should().BeNull();
            rs.Fpip.Should().BeNull();
            rs.Fpipsel.Should().BeNull();
            rs.Fpdp.Should().BeNull();
            rs.Fpdpsel.Should().BeNull();
        }

        [Fact]
        public void Be_Equal_When_Non_Calculated_Properties_Are_Equal()
        {
            var rs = new RegisterSet();
            rs.Equals(rs).Should().BeTrue();
            rs.Equals((object) rs).Should().BeTrue();
            rs.Equals(null).Should().BeFalse();
            rs.Equals((object) rs).Should().BeTrue();
            rs.Equals((object) null).Should().BeFalse();
            rs.Equals(new object()).Should().BeFalse();

            {
                var r1 = new RegisterSet();
                var r2 = new RegisterSet();
                r1.Equals(r1).Should().BeTrue();
                r1.Equals(r2).Should().BeTrue();
                r1.Equals((object) r2).Should().BeTrue();
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
                    Vip = true
                };
                var r2 = new RegisterSet()
                {
                    Vip = true
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

        [Fact]
        public void Set_The_Correct_Values()
        {
            var rs = new RegisterSet();

            rs.Af = false;
            rs.Af.Should().BeFalse();

            rs.Cf = false;
            rs.Cf.Should().BeFalse();

            rs.Df = false;
            rs.Df.Should().BeFalse();

            rs.If = false;
            rs.If.Should().BeFalse();

            rs.Of = false;
            rs.Of.Should().BeFalse();

            rs.Pf = false;
            rs.Pf.Should().BeFalse();

            rs.Sf = false;
            rs.Sf.Should().BeFalse();

            rs.Tf = false;
            rs.Tf.Should().BeFalse();

            rs.Vif = false;
            rs.Vif.Should().BeFalse();

            rs.Vip = false;
            rs.Vip.Should().BeFalse();

            rs.Zf = false;
            rs.Zf.Should().BeFalse();

            rs.Sp = ushort.MaxValue;
            rs.Sp.Should().Be(ushort.MaxValue);

            rs.R12b = byte.MaxValue;
            rs.R12b.Should().Be(byte.MaxValue);
        }
    }
}