using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using McFly.Core.Registers;
using Xunit;

namespace McFly.Core.Test
{
    public class Register_Should
    {
        [Fact]
        public void Not_Have_Duplicates()
        {
            Register.AllRegisters.Should().OnlyHaveUniqueItems();
        }

        [Fact]
        public void Have_The_Correct_Num_Bits()
        {
            Register.AllRegisters128.Select(x => x.NumBits).Distinct().Single().Should().Be(128);
            Register.AllRegisters80.Select(x => x.NumBits).Distinct().Single().Should().Be(80);
            Register.AllRegisters64.Select(x => x.NumBits).Distinct().Single().Should().Be(64);
            Register.AllRegisters32.Select(x => x.NumBits).Distinct().Single().Should().Be(32);
            Register.AllRegisters16.Select(x => x.NumBits).Distinct().Single().Should().Be(16);
            Register.AllRegisters8.Select(x => x.NumBits).Distinct().Single().Should().Be(8);
        }

        [Fact]
        public void Have_The_Correct_Register_Names()
        {
            Register.Rax.Name.Should().Be("rax");
            Register.Rbx.Name.Should().Be("rbx");
            Register.Rcx.Name.Should().Be("rcx");
            Register.Rdx.Name.Should().Be("rdx");
            Register.Rsi.Name.Should().Be("rsi");
            Register.Rdi.Name.Should().Be("rdi");
            Register.Rsp.Name.Should().Be("rsp");
            Register.Rbp.Name.Should().Be("rbp");
            Register.Rip.Name.Should().Be("rip");

            Register.Efl.Name.Should().Be("efl");
            Register.Cs.Name.Should().Be("cs");
            Register.Ds.Name.Should().Be("ds");
            Register.Es.Name.Should().Be("es");
            Register.Fs.Name.Should().Be("fs");
            Register.Gs.Name.Should().Be("gs");
            Register.Ss.Name.Should().Be("ss");

            Register.R8.Name.Should().Be("r8");
            Register.R9.Name.Should().Be("r9");
            Register.R10.Name.Should().Be("r10");
            Register.R11.Name.Should().Be("r11");
            Register.R12.Name.Should().Be("r12");
            Register.R13.Name.Should().Be("r13");
            Register.R14.Name.Should().Be("r14");
            Register.R15.Name.Should().Be("r15");

            Register.Dr0.Name.Should().Be("dr0");
            Register.Dr1.Name.Should().Be("dr1");
            Register.Dr2.Name.Should().Be("dr2");
            Register.Dr3.Name.Should().Be("dr3");
            Register.Dr6.Name.Should().Be("dr6");
            Register.Dr7.Name.Should().Be("dr7");

            Register.Exfrom.Name.Should().Be("exfrom");
            Register.Exto.Name.Should().Be("exto");
            Register.Brfrom.Name.Should().Be("brfrom");
            Register.Brto.Name.Should().Be("brto");

            Register.Eax.Name.Should().Be("eax");
            Register.Ecx.Name.Should().Be("ecx");
            Register.Edx.Name.Should().Be("edx");
            Register.Ebx.Name.Should().Be("ebx");
            Register.Esp.Name.Should().Be("esp");
            Register.Ebp.Name.Should().Be("ebp");
            Register.Esi.Name.Should().Be("esi");
            Register.Edi.Name.Should().Be("edi");

            Register.R8d.Name.Should().Be("r8d");
            Register.R9d.Name.Should().Be("r9d");
            Register.R10d.Name.Should().Be("r10d");
            Register.R11d.Name.Should().Be("r11d");
            Register.R12d.Name.Should().Be("r12d");
            Register.R13d.Name.Should().Be("r13d");
            Register.R14d.Name.Should().Be("r14d");
            Register.R15d.Name.Should().Be("r15d");
            Register.Eip.Name.Should().Be("eip");

            Register.Ax.Name.Should().Be("ax");
            Register.Bx.Name.Should().Be("bx");
            Register.Cx.Name.Should().Be("cx");
            Register.Dx.Name.Should().Be("dx");
            Register.Si.Name.Should().Be("si");
            Register.Di.Name.Should().Be("di");
            Register.Sp.Name.Should().Be("sp");
            Register.Bp.Name.Should().Be("bp");
            Register.Ip.Name.Should().Be("ip");

            Register.R8w.Name.Should().Be("r8w");
            Register.R9w.Name.Should().Be("r9w");
            Register.R10w.Name.Should().Be("r10w");
            Register.R11w.Name.Should().Be("r11w");
            Register.R12w.Name.Should().Be("r12w");
            Register.R13w.Name.Should().Be("r13w");
            Register.R14w.Name.Should().Be("r14w");
            Register.R15w.Name.Should().Be("r15w");

            Register.Ip.Name.Should().Be("ip");
            Register.Fl.Name.Should().Be("fl");
            Register.Al.Name.Should().Be("al");
            Register.Cl.Name.Should().Be("cl");
            Register.Dl.Name.Should().Be("dl");
            Register.Bl.Name.Should().Be("bl");
            Register.Spl.Name.Should().Be("spl");
            Register.Bpl.Name.Should().Be("bpl");
            Register.Sil.Name.Should().Be("sil");
            Register.Dil.Name.Should().Be("dil");

            Register.R8b.Name.Should().Be("r8b");
            Register.R9b.Name.Should().Be("r9b");
            Register.R10b.Name.Should().Be("r10b");
            Register.R11b.Name.Should().Be("r11b");
            Register.R12b.Name.Should().Be("r12b");
            Register.R13b.Name.Should().Be("r13b");
            Register.R14b.Name.Should().Be("r14b");
            Register.R15b.Name.Should().Be("r15b");

            Register.Ah.Name.Should().Be("ah");
            Register.Ch.Name.Should().Be("ch");
            Register.Dh.Name.Should().Be("dh");
            Register.Bh.Name.Should().Be("bh");

            Register.Iopl.Name.Should().Be("iopl");
            Register.Of.Name.Should().Be("of");
            Register.Df.Name.Should().Be("df");
            Register.If.Name.Should().Be("if");
            Register.Tf.Name.Should().Be("tf");
            Register.Sf.Name.Should().Be("sf");
            Register.Zf.Name.Should().Be("zf");
            Register.Af.Name.Should().Be("af");
            Register.Pf.Name.Should().Be("pf");
            Register.Cf.Name.Should().Be("cf");
            Register.Vip.Name.Should().Be("vip");
            Register.Vif.Name.Should().Be("vif");

            Register.Mm0.Name.Should().Be("mm0");
            Register.Mm1.Name.Should().Be("mm1");
            Register.Mm2.Name.Should().Be("mm2");
            Register.Mm3.Name.Should().Be("mm3");
            Register.Mm4.Name.Should().Be("mm4");
            Register.Mm5.Name.Should().Be("mm5");
            Register.Mm6.Name.Should().Be("mm6");
            Register.Mm7.Name.Should().Be("mm7");

            Register.Mxcsr.Name.Should().Be("mxcsr");

            Register.Xmm0.Name.Should().Be("xmm0");
            Register.Xmm1.Name.Should().Be("xmm1");
            Register.Xmm2.Name.Should().Be("xmm2");
            Register.Xmm3.Name.Should().Be("xmm3");
            Register.Xmm4.Name.Should().Be("xmm4");
            Register.Xmm5.Name.Should().Be("xmm5");
            Register.Xmm6.Name.Should().Be("xmm6");
            Register.Xmm7.Name.Should().Be("xmm7");
            Register.Xmm8.Name.Should().Be("xmm8");
            Register.Xmm9.Name.Should().Be("xmm9");
            Register.Xmm10.Name.Should().Be("xmm10");
            Register.Xmm11.Name.Should().Be("xmm11");
            Register.Xmm12.Name.Should().Be("xmm12");
            Register.Xmm13.Name.Should().Be("xmm13");
            Register.Xmm14.Name.Should().Be("xmm14");
            Register.Xmm15.Name.Should().Be("xmm15");

            Register.Ymm0.Name.Should().Be("ymm0");
            Register.Ymm1.Name.Should().Be("ymm1");
            Register.Ymm2.Name.Should().Be("ymm2");
            Register.Ymm3.Name.Should().Be("ymm3");
            Register.Ymm4.Name.Should().Be("ymm4");
            Register.Ymm5.Name.Should().Be("ymm5");
            Register.Ymm6.Name.Should().Be("ymm6");
            Register.Ymm7.Name.Should().Be("ymm7");
            Register.Ymm8.Name.Should().Be("ymm8");
            Register.Ymm9.Name.Should().Be("ymm9");
            Register.Ymm10.Name.Should().Be("ymm10");
            Register.Ymm11.Name.Should().Be("ymm11");
            Register.Ymm12.Name.Should().Be("ymm12");
            Register.Ymm13.Name.Should().Be("ymm13");
            Register.Ymm14.Name.Should().Be("ymm14");
            Register.Ymm15.Name.Should().Be("ymm15");

            Register.Xmm0l.Name.Should().Be("xmm0l");
            Register.Xmm1l.Name.Should().Be("xmm1l");
            Register.Xmm2l.Name.Should().Be("xmm2l");
            Register.Xmm3l.Name.Should().Be("xmm3l");
            Register.Xmm4l.Name.Should().Be("xmm4l");
            Register.Xmm5l.Name.Should().Be("xmm5l");
            Register.Xmm6l.Name.Should().Be("xmm6l");
            Register.Xmm7l.Name.Should().Be("xmm7l");
            Register.Xmm8l.Name.Should().Be("xmm8l");
            Register.Xmm9l.Name.Should().Be("xmm9l");
            Register.Xmm10l.Name.Should().Be("xmm10l");
            Register.Xmm11l.Name.Should().Be("xmm11l");
            Register.Xmm12l.Name.Should().Be("xmm12l");
            Register.Xmm13l.Name.Should().Be("xmm13l");
            Register.Xmm14l.Name.Should().Be("xmm14l");
            Register.Xmm15l.Name.Should().Be("xmm15l");

            Register.Ymm0l.Name.Should().Be("ymm0l");
            Register.Ymm1l.Name.Should().Be("ymm1l");
            Register.Ymm2l.Name.Should().Be("ymm2l");
            Register.Ymm3l.Name.Should().Be("ymm3l");
            Register.Ymm4l.Name.Should().Be("ymm4l");
            Register.Ymm5l.Name.Should().Be("ymm5l");
            Register.Ymm6l.Name.Should().Be("ymm6l");
            Register.Ymm7l.Name.Should().Be("ymm7l");
            Register.Ymm8l.Name.Should().Be("ymm8l");
            Register.Ymm9l.Name.Should().Be("ymm9l");
            Register.Ymm10l.Name.Should().Be("ymm10l");
            Register.Ymm11l.Name.Should().Be("ymm11l");
            Register.Ymm12l.Name.Should().Be("ymm12l");
            Register.Ymm13l.Name.Should().Be("ymm13l");
            Register.Ymm14l.Name.Should().Be("ymm14l");
            Register.Ymm15l.Name.Should().Be("ymm15l");

            Register.Fpcw.Name.Should().Be("fpcw");
            Register.Fpsw.Name.Should().Be("fpsw");
            Register.Fptw.Name.Should().Be("fptw");
            Register.St0.Name.Should().Be("st0");
            Register.St1.Name.Should().Be("st1");
            Register.St2.Name.Should().Be("st2");
            Register.St3.Name.Should().Be("st3");
            Register.St4.Name.Should().Be("st4");
            Register.St5.Name.Should().Be("st5");
            Register.St6.Name.Should().Be("st6");
            Register.St7.Name.Should().Be("st7");
        }

        [Fact]
        public void Have_Correct_Register_Num_Bits()
        {
            Register.Rax.NumBits.Should().Be(64);
            Register.Rbx.NumBits.Should().Be(64);
            Register.Rcx.NumBits.Should().Be(64);
            Register.Rdx.NumBits.Should().Be(64);
            Register.Rsi.NumBits.Should().Be(64);
            Register.Rdi.NumBits.Should().Be(64);
            Register.Rsp.NumBits.Should().Be(64);
            Register.Rbp.NumBits.Should().Be(64);
            Register.Rip.NumBits.Should().Be(64);

            Register.Efl.NumBits.Should().Be(32);

            Register.Cs.NumBits.Should().Be(16);
            Register.Ds.NumBits.Should().Be(16);
            Register.Es.NumBits.Should().Be(16);
            Register.Fs.NumBits.Should().Be(16);
            Register.Gs.NumBits.Should().Be(16);
            Register.Ss.NumBits.Should().Be(16);

            Register.R8.NumBits.Should().Be(64);
            Register.R9.NumBits.Should().Be(64);
            Register.R10.NumBits.Should().Be(64);
            Register.R11.NumBits.Should().Be(64);
            Register.R12.NumBits.Should().Be(64);
            Register.R13.NumBits.Should().Be(64);
            Register.R14.NumBits.Should().Be(64);
            Register.R15.NumBits.Should().Be(64);

            Register.Dr0.NumBits.Should().Be(64);
            Register.Dr1.NumBits.Should().Be(64);
            Register.Dr2.NumBits.Should().Be(64);
            Register.Dr3.NumBits.Should().Be(64);
            Register.Dr6.NumBits.Should().Be(64);
            Register.Dr7.NumBits.Should().Be(64);

            Register.Exfrom.NumBits.Should().Be(64);
            Register.Exto.NumBits.Should().Be(64);
            Register.Brfrom.NumBits.Should().Be(64);
            Register.Brto.NumBits.Should().Be(64);

            Register.Eax.NumBits.Should().Be(32);
            Register.Ecx.NumBits.Should().Be(32);
            Register.Edx.NumBits.Should().Be(32);
            Register.Ebx.NumBits.Should().Be(32);
            Register.Esp.NumBits.Should().Be(32);
            Register.Ebp.NumBits.Should().Be(32);
            Register.Esi.NumBits.Should().Be(32);
            Register.Edi.NumBits.Should().Be(32);

            Register.R8d.NumBits.Should().Be(32);
            Register.R9d.NumBits.Should().Be(32);
            Register.R10d.NumBits.Should().Be(32);
            Register.R11d.NumBits.Should().Be(32);
            Register.R12d.NumBits.Should().Be(32);
            Register.R13d.NumBits.Should().Be(32);
            Register.R14d.NumBits.Should().Be(32);
            Register.R15d.NumBits.Should().Be(32);
            Register.Eip.NumBits.Should().Be(32);

            Register.Ax.NumBits.Should().Be(16);
            Register.Bx.NumBits.Should().Be(16);
            Register.Cx.NumBits.Should().Be(16);
            Register.Dx.NumBits.Should().Be(16);
            Register.Si.NumBits.Should().Be(16);
            Register.Di.NumBits.Should().Be(16);
            Register.Sp.NumBits.Should().Be(16);
            Register.Bp.NumBits.Should().Be(16);

            Register.R8w.NumBits.Should().Be(16);
            Register.R9w.NumBits.Should().Be(16);
            Register.R10w.NumBits.Should().Be(16);
            Register.R11w.NumBits.Should().Be(16);
            Register.R12w.NumBits.Should().Be(16);
            Register.R13w.NumBits.Should().Be(16);
            Register.R14w.NumBits.Should().Be(16);
            Register.R15w.NumBits.Should().Be(16);

            Register.Ip.NumBits.Should().Be(16);
            Register.Fl.NumBits.Should().Be(16);
            Register.Al.NumBits.Should().Be(8);
            Register.Cl.NumBits.Should().Be(8);
            Register.Dl.NumBits.Should().Be(8);
            Register.Bl.NumBits.Should().Be(8);
            Register.Spl.NumBits.Should().Be(8);
            Register.Bpl.NumBits.Should().Be(8);
            Register.Sil.NumBits.Should().Be(8);
            Register.Dil.NumBits.Should().Be(8);

            Register.R8b.NumBits.Should().Be(8);
            Register.R9b.NumBits.Should().Be(8);
            Register.R10b.NumBits.Should().Be(8);
            Register.R11b.NumBits.Should().Be(8);
            Register.R12b.NumBits.Should().Be(8);
            Register.R13b.NumBits.Should().Be(8);
            Register.R14b.NumBits.Should().Be(8);
            Register.R15b.NumBits.Should().Be(8);

            Register.Ah.NumBits.Should().Be(8);
            Register.Ch.NumBits.Should().Be(8);
            Register.Dh.NumBits.Should().Be(8);
            Register.Bh.NumBits.Should().Be(8);

            Register.Iopl.NumBits.Should().Be(2);
            Register.Of.NumBits.Should().Be(1);
            Register.Df.NumBits.Should().Be(1);
            Register.If.NumBits.Should().Be(1);
            Register.Tf.NumBits.Should().Be(1);
            Register.Sf.NumBits.Should().Be(1);
            Register.Zf.NumBits.Should().Be(1);
            Register.Af.NumBits.Should().Be(1);
            Register.Pf.NumBits.Should().Be(1);
            Register.Cf.NumBits.Should().Be(1);
            Register.Vip.NumBits.Should().Be(1);
            Register.Vif.NumBits.Should().Be(1);

            Register.Mm0.NumBits.Should().Be(64);
            Register.Mm1.NumBits.Should().Be(64);
            Register.Mm2.NumBits.Should().Be(64);
            Register.Mm3.NumBits.Should().Be(64);
            Register.Mm4.NumBits.Should().Be(64);
            Register.Mm5.NumBits.Should().Be(64);
            Register.Mm6.NumBits.Should().Be(64);
            Register.Mm7.NumBits.Should().Be(64);

            Register.Mxcsr.NumBits.Should().Be(32);

            Register.Xmm0.NumBits.Should().Be(128);
            Register.Xmm1.NumBits.Should().Be(128);
            Register.Xmm2.NumBits.Should().Be(128);
            Register.Xmm3.NumBits.Should().Be(128);
            Register.Xmm4.NumBits.Should().Be(128);
            Register.Xmm5.NumBits.Should().Be(128);
            Register.Xmm6.NumBits.Should().Be(128);
            Register.Xmm7.NumBits.Should().Be(128);
            Register.Xmm8.NumBits.Should().Be(128);
            Register.Xmm9.NumBits.Should().Be(128);
            Register.Xmm10.NumBits.Should().Be(128);
            Register.Xmm11.NumBits.Should().Be(128);
            Register.Xmm12.NumBits.Should().Be(128);
            Register.Xmm13.NumBits.Should().Be(128);
            Register.Xmm14.NumBits.Should().Be(128);
            Register.Xmm15.NumBits.Should().Be(128);

            Register.Ymm0.NumBits.Should().Be(128);
            Register.Ymm1.NumBits.Should().Be(128);
            Register.Ymm2.NumBits.Should().Be(128);
            Register.Ymm3.NumBits.Should().Be(128);
            Register.Ymm4.NumBits.Should().Be(128);
            Register.Ymm5.NumBits.Should().Be(128);
            Register.Ymm6.NumBits.Should().Be(128);
            Register.Ymm7.NumBits.Should().Be(128);
            Register.Ymm8.NumBits.Should().Be(128);
            Register.Ymm9.NumBits.Should().Be(128);
            Register.Ymm10.NumBits.Should().Be(128);
            Register.Ymm11.NumBits.Should().Be(128);
            Register.Ymm12.NumBits.Should().Be(128);
            Register.Ymm13.NumBits.Should().Be(128);
            Register.Ymm14.NumBits.Should().Be(128);
            Register.Ymm15.NumBits.Should().Be(128);

            Register.Xmm0l.NumBits.Should().Be(64);
            Register.Xmm1l.NumBits.Should().Be(64);
            Register.Xmm2l.NumBits.Should().Be(64);
            Register.Xmm3l.NumBits.Should().Be(64);
            Register.Xmm4l.NumBits.Should().Be(64);
            Register.Xmm5l.NumBits.Should().Be(64);
            Register.Xmm6l.NumBits.Should().Be(64);
            Register.Xmm7l.NumBits.Should().Be(64);
            Register.Xmm8l.NumBits.Should().Be(64);
            Register.Xmm9l.NumBits.Should().Be(64);
            Register.Xmm10l.NumBits.Should().Be(64);
            Register.Xmm11l.NumBits.Should().Be(64);
            Register.Xmm12l.NumBits.Should().Be(64);
            Register.Xmm13l.NumBits.Should().Be(64);
            Register.Xmm14l.NumBits.Should().Be(64);
            Register.Xmm15l.NumBits.Should().Be(64);

            Register.Ymm0l.NumBits.Should().Be(64);
            Register.Ymm1l.NumBits.Should().Be(64);
            Register.Ymm2l.NumBits.Should().Be(64);
            Register.Ymm3l.NumBits.Should().Be(64);
            Register.Ymm4l.NumBits.Should().Be(64);
            Register.Ymm5l.NumBits.Should().Be(64);
            Register.Ymm6l.NumBits.Should().Be(64);
            Register.Ymm7l.NumBits.Should().Be(64);
            Register.Ymm8l.NumBits.Should().Be(64);
            Register.Ymm9l.NumBits.Should().Be(64);
            Register.Ymm10l.NumBits.Should().Be(64);
            Register.Ymm11l.NumBits.Should().Be(64);
            Register.Ymm12l.NumBits.Should().Be(64);
            Register.Ymm13l.NumBits.Should().Be(64);
            Register.Ymm14l.NumBits.Should().Be(64);
            Register.Ymm15l.NumBits.Should().Be(64);

            Register.Fpcw.NumBits.Should().Be(16);
            Register.Fpsw.NumBits.Should().Be(16);
            Register.Fptw.NumBits.Should().Be(16);
            Register.St0.NumBits.Should().Be(80);
            Register.St1.NumBits.Should().Be(80);
            Register.St2.NumBits.Should().Be(80);
            Register.St3.NumBits.Should().Be(80);
            Register.St4.NumBits.Should().Be(80);
            Register.St5.NumBits.Should().Be(80);
            Register.St6.NumBits.Should().Be(80);
            Register.St7.NumBits.Should().Be(80);
        }
    }
}
