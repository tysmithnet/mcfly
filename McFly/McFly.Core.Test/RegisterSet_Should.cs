using System;
using System.Linq;
using FluentAssertions;
using McFly.Core.Registers;
using Xunit;

namespace McFly.Core.Test
{
    public class RegisterSet_Should
    {
        [Fact]
        public void Process_Registers_Correctly()
        {
            var r = new RegisterSet();
            
            r.Process("rax", "0x0123456789abcdef");
            r.Rax.Should().Be(0x0123456789abcdef);
            r.Eax.Should().Be(0x89abcdef);
            r.Ax.Should().Be(0xcdef);
            r.Al.Should().Be(0xef);
            r.Ah.Should().Be(0xcd);

            r = new RegisterSet();
            r.Process("rbx", "0x0123456789abcdef");
            r.Rbx.Should().Be(0x0123456789abcdef);
            r.Ebx.Should().Be(0x89abcdef);
            r.Bx.Should().Be(0xcdef);
            r.Bl.Should().Be(0xef);
            r.Bh.Should().Be(0xcd);

            r = new RegisterSet();
            r.Process("rcx", "0x0123456789abcdef");
            r.Rcx.Should().Be(0x0123456789abcdef);
            r.Ecx.Should().Be(0x89abcdef);
            r.Cx.Should().Be(0xcdef);
            r.Cl.Should().Be(0xef);
            r.Ch.Should().Be(0xcd);

            r = new RegisterSet();
            r.Process("rdx", "0x0123456789abcdef");
            r.Rdx.Should().Be(0x0123456789abcdef);
            r.Edx.Should().Be(0x89abcdef);
            r.Dx.Should().Be(0xcdef);
            r.Dl.Should().Be(0xef);
            r.Dh.Should().Be(0xcd);

            r = new RegisterSet();
            r.Process("rsp", "0x0123456789abcdef");
            r.Rsp.Should().Be(0x0123456789abcdef);
            r.Esp.Should().Be(0x89abcdef);
            r.Sp.Should().Be(0xcdef);
            r.Spl.Should().Be(0xef);

            r = new RegisterSet();
            r.Process("rbp", "0x0123456789abcdef");
            r.Rbp.Should().Be(0x0123456789abcdef);
            r.Ebp.Should().Be(0x89abcdef);
            r.Bp.Should().Be(0xcdef);
            r.Bpl.Should().Be(0xef);

            r = new RegisterSet();
            r.Process("rsi", "0x0123456789abcdef");
            r.Rsi.Should().Be(0x0123456789abcdef);
            r.Esi.Should().Be(0x89abcdef);
            r.Si.Should().Be(0xcdef);
            r.Sil.Should().Be(0xef);

            r = new RegisterSet();
            r.Process("rdi", "0x0123456789abcdef");
            r.Rdi.Should().Be(0x0123456789abcdef);
            r.Edi.Should().Be(0x89abcdef);
            r.Di.Should().Be(0xcdef);
            r.Dil.Should().Be(0xef);

            r = new RegisterSet();
            r.Process("r8", "0x0123456789abcdef");
            r.R8.Should().Be(0x0123456789abcdef);
            r.R8d.Should().Be(0x89abcdef);
            r.R8w.Should().Be(0xcdef);
            r.R8b.Should().Be(0xef);

            r = new RegisterSet();
            r.Process("r9", "0x0123456789abcdef");
            r.R9.Should().Be(0x0123456789abcdef);
            r.R9d.Should().Be(0x89abcdef);
            r.R9w.Should().Be(0xcdef);
            r.R9b.Should().Be(0xef);

            r = new RegisterSet();
            r.Process("r10", "0x0123456789abcdef");
            r.R10.Should().Be(0x0123456789abcdef);
            r.R10d.Should().Be(0x89abcdef);
            r.R10w.Should().Be(0xcdef);
            r.R10b.Should().Be(0xef);

            r = new RegisterSet();
            r.Process("r11", "0x0123456789abcdef");
            r.R11.Should().Be(0x0123456789abcdef);
            r.R11d.Should().Be(0x89abcdef);
            r.R11w.Should().Be(0xcdef);
            r.R11b.Should().Be(0xef);

            r = new RegisterSet();
            r.Process("r12", "0x0123456789abcdef");
            r.R12.Should().Be(0x0123456789abcdef);
            r.R12d.Should().Be(0x89abcdef);
            r.R12w.Should().Be(0xcdef);
            r.R12b.Should().Be(0xef);

            r = new RegisterSet();
            r.Process("r13", "0x0123456789abcdef");
            r.R13.Should().Be(0x0123456789abcdef);
            r.R13d.Should().Be(0x89abcdef);
            r.R13w.Should().Be(0xcdef);
            r.R13b.Should().Be(0xef);

            r = new RegisterSet();
            r.Process("r14", "0x0123456789abcdef");
            r.R14.Should().Be(0x0123456789abcdef);
            r.R14d.Should().Be(0x89abcdef);
            r.R14w.Should().Be(0xcdef);
            r.R14b.Should().Be(0xef);

            r = new RegisterSet();
            r.Process("r15", "0x0123456789abcdef");
            r.R15.Should().Be(0x0123456789abcdef);
            r.R15d.Should().Be(0x89abcdef);
            r.R15w.Should().Be(0xcdef);
            r.R15b.Should().Be(0xef);

            r = new RegisterSet();
            r.Process("rip", "0x0123456789abcdef");
            r.Rip.Should().Be(0x0123456789abcdef);
            r.Eip.Should().Be(0x89abcdef);
            r.Ip.Should().Be(0xcdef);

            r = new RegisterSet();
            r.Process("efl", "0x01234567");
            r.Efl.Should().Be(0x01234567);
            r.Fl.Should().Be(0x4567);

            r = new RegisterSet();
            r.Process("cs", "0x0123");
            r.Cs.Should().Be(0x0123);

            r = new RegisterSet();
            r.Process("ds", "0x0123");
            r.Ds.Should().Be(0x0123);

            r = new RegisterSet();
            r.Process("es", "0x0123");
            r.Es.Should().Be(0x0123);

            r = new RegisterSet();
            r.Process("fs", "0x0123");
            r.Fs.Should().Be(0x0123);

            r = new RegisterSet();
            r.Process("gs", "0x0123");
            r.Gs.Should().Be(0x0123);

            r = new RegisterSet();
            r.Process("ss", "0x0123");
            r.Ss.Should().Be(0x0123); 

            r = new RegisterSet();
            r.Process("dr0", "0x0123456789abcdef");
            r.Dr0.Should().Be(0x0123456789abcdef);

            r = new RegisterSet();
            r.Process("dr1", "0x0123456789abcdef");
            r.Dr1.Should().Be(0x0123456789abcdef);

            r = new RegisterSet();
            r.Process("dr2", "0x0123456789abcdef");
            r.Dr2.Should().Be(0x0123456789abcdef);

            r = new RegisterSet();
            r.Process("dr3", "0x0123456789abcdef");
            r.Dr3.Should().Be(0x0123456789abcdef);

            r = new RegisterSet();
            r.Process("dr6", "0x0123456789abcdef");
            r.Dr6.Should().Be(0x0123456789abcdef);

            r = new RegisterSet();
            r.Process("dr7", "0x0123456789abcdef");
            r.Dr7.Should().Be(0x0123456789abcdef);

            r = new RegisterSet();
            r.Process("fpcw", "0x0123");
            r.Fpcw.Should().Be(0x0123);

            r = new RegisterSet();
            r.Process("fpsw", "0x0123");
            r.Fpsw.Should().Be(0x123);

            r = new RegisterSet();
            r.Process("fptw", "0x0123");
            r.Fptw.Should().Be(0x123);

            r = new RegisterSet();
            r.Process("st0", "0:1234:0123456789abcdef");
            r.St0.Should().Equal(new[] {0x12, 0x34, 0x01, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef}.Reverse());

            r = new RegisterSet();
            r.Process("st1", "0:1234:0123456789abcdef");
            r.St1.Should().Equal(new[] { 0x12, 0x34, 0x01, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef }.Reverse());

            r = new RegisterSet();
            r.Process("st2", "0:1234:0123456789abcdef");
            r.St2.Should().Equal(new[] { 0x12, 0x34, 0x01, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef }.Reverse());

            r = new RegisterSet();
            r.Process("st3", "0:1234:0123456789abcdef");
            r.St3.Should().Equal(new[] { 0x12, 0x34, 0x01, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef }.Reverse());

            r = new RegisterSet();
            r.Process("st4", "0:1234:0123456789abcdef");
            r.St4.Should().Equal(new[] { 0x12, 0x34, 0x01, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef }.Reverse());

            r = new RegisterSet();
            r.Process("st5", "0:1234:0123456789abcdef");
            r.St5.Should().Equal(new[] { 0x12, 0x34, 0x01, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef }.Reverse());

            r = new RegisterSet();
            r.Process("st6", "0:1234:0123456789abcdef");
            r.St6.Should().Equal(new[] { 0x12, 0x34, 0x01, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef }.Reverse());

            r = new RegisterSet();
            r.Process("st7", "0:1234:0123456789abcdef");
            r.St7.Should().Equal(new[] { 0x12, 0x34, 0x01, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef }.Reverse());

            r = new RegisterSet();
            r.Process("mm0", "0xffffffffffffffff");
            r.Mm0.Should().Be(0xffffffffffffffff);

            r = new RegisterSet();
            r.Process("mm1", "0xfedcba9876543210");
            r.Mm1.Should().Be(0xfedcba9876543210);

            r = new RegisterSet();
            r.Process("mm2", "0xfedcba9876543210");
            r.Mm2.Should().Be(0xfedcba9876543210);

            r = new RegisterSet();
            r.Process("mm3", "0xfedcba9876543210");
            r.Mm3.Should().Be(0xfedcba9876543210);

            r = new RegisterSet();
            r.Process("mm4", "0xfedcba9876543210");
            r.Mm4.Should().Be(0xfedcba9876543210);

            r = new RegisterSet();
            r.Process("mm5", "0xfedcba9876543210");
            r.Mm5.Should().Be(0xfedcba9876543210);

            r = new RegisterSet();
            r.Process("mm6", "0xfedcba9876543210");
            r.Mm6.Should().Be(0xfedcba9876543210);

            r = new RegisterSet();
            r.Process("mm7", "0xfedcba9876543210");
            r.Mm7.Should().Be(0xfedcba9876543210);

            r = new RegisterSet();
            r.Process("mxcsr", "76543210");
            r.Mxcsr.Should().Be(0x76543210);

            r = new RegisterSet();
            r.Process("ymm0", "           0            0            0            0            0            0            0            0");
            r.Ymm0.Should().Equal(Enumerable.Range(0, 32).Select(Convert.ToByte));
            r.Xmm0.Should().Equal(Enumerable.Range(0, 16).Select(Convert.ToByte));

            r = new RegisterSet();
            r.Process("ymm1", "    ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff");
            r.Ymm1.Should().Equal(Enumerable.Range(0, 32).Select(Convert.ToByte));
            r.Xmm1.Should().Equal(Enumerable.Range(0, 16).Select(Convert.ToByte));

            r = new RegisterSet();
            r.Process("ymm2", "    ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff");
            r.Ymm2.Should().Equal(Enumerable.Range(0, 32).Select(Convert.ToByte));
            r.Xmm2.Should().Equal(Enumerable.Range(0, 16).Select(Convert.ToByte));

            r = new RegisterSet();
            r.Process("ymm3", "    ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff");
            r.Ymm3.Should().Equal(Enumerable.Range(0, 32).Select(Convert.ToByte));
            r.Xmm3.Should().Equal(Enumerable.Range(0, 16).Select(Convert.ToByte));

            r = new RegisterSet();
            r.Process("ymm4", "    ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff");
            r.Ymm4.Should().Equal(Enumerable.Range(0, 32).Select(Convert.ToByte));
            r.Xmm4.Should().Equal(Enumerable.Range(0, 16).Select(Convert.ToByte));

            r = new RegisterSet();
            r.Process("ymm5", "    ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff");
            r.Ymm5.Should().Equal(Enumerable.Range(0, 32).Select(Convert.ToByte));
            r.Xmm5.Should().Equal(Enumerable.Range(0, 16).Select(Convert.ToByte));

            r = new RegisterSet();
            r.Process("ymm6", "    ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff");
            r.Ymm6.Should().Equal(Enumerable.Range(0, 32).Select(Convert.ToByte));
            r.Xmm6.Should().Equal(Enumerable.Range(0, 16).Select(Convert.ToByte));

            r = new RegisterSet();
            r.Process("ymm7", "    ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff");
            r.Ymm7.Should().Equal(Enumerable.Range(0, 32).Select(Convert.ToByte));
            r.Xmm7.Should().Equal(Enumerable.Range(0, 16).Select(Convert.ToByte));

            r = new RegisterSet();
            r.Process("ymm8", "    ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff");
            r.Ymm8.Should().Equal(Enumerable.Range(0, 32).Select(Convert.ToByte));
            r.Xmm8.Should().Equal(Enumerable.Range(0, 16).Select(Convert.ToByte));

            r = new RegisterSet();
            r.Process("ymm9", "    ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff");
            r.Ymm9.Should().Equal(Enumerable.Range(0, 32).Select(Convert.ToByte));
            r.Xmm9.Should().Equal(Enumerable.Range(0, 16).Select(Convert.ToByte));

            r = new RegisterSet();
            r.Process("ymm10", "    ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff");
            r.Ymm10.Should().Equal(Enumerable.Range(0, 32).Select(Convert.ToByte));
            r.Xmm10.Should().Equal(Enumerable.Range(0, 16).Select(Convert.ToByte));

            r = new RegisterSet();
            r.Process("ymm11", "    ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff");
            r.Ymm11.Should().Equal(Enumerable.Range(0, 32).Select(Convert.ToByte));
            r.Xmm11.Should().Equal(Enumerable.Range(0, 16).Select(Convert.ToByte));

            r = new RegisterSet();
            r.Process("ymm12", "    ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff");
            r.Ymm12.Should().Equal(Enumerable.Range(0, 32).Select(Convert.ToByte));
            r.Xmm12.Should().Equal(Enumerable.Range(0, 16).Select(Convert.ToByte));

            r = new RegisterSet();
            r.Process("ymm13", "    ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff");
            r.Ymm13.Should().Equal(Enumerable.Range(0, 32).Select(Convert.ToByte));
            r.Xmm13.Should().Equal(Enumerable.Range(0, 16).Select(Convert.ToByte));

            r = new RegisterSet();
            r.Process("ymm14", "    ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff");
            r.Ymm14.Should().Equal(Enumerable.Range(0, 32).Select(Convert.ToByte));
            r.Xmm14.Should().Equal(Enumerable.Range(0, 16).Select(Convert.ToByte));

            r = new RegisterSet();
            r.Process("ymm15", "    ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff     ffffffff");
            r.Ymm15.Should().Equal(Enumerable.Range(0, 32).Select(Convert.ToByte));
            r.Xmm15.Should().Equal(Enumerable.Range(0, 16).Select(Convert.ToByte));
        }
    }
}