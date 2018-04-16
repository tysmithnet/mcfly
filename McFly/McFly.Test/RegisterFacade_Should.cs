using System;
using System.Linq;
using System.Text.RegularExpressions;
using FluentAssertions;
using McFly.Core.Registers;
using McFly.Test.Builders;
using Xunit;
using static McFly.Core.Registers.Register;

namespace McFly.Test
{
    public class RegisterFacade_Should
    {
        [Fact]
        public void Get_Current_RegisterSet_Correctly()
        {
            // arrange
            var builder = new DebugEngineProxyBuilder();
            builder.With32Bit(false);
            var facade = new RegisterFacade();
            builder.WithExecuteResult(
                @"rax=000000003205f31c rbx=000000001e042120 rcx=000000003205f322 rdx=000000003205f2ce");
            builder.WithThreadId(1);
            facade.DebugEngineProxy = builder.Build();

            // act
            var registerSet = facade.GetCurrentRegisterSet(new Register[] {Rax, Rbx, Rcx, Rdx});
            var emptySet = facade.GetCurrentRegisterSet(new Register[0]);

            // assert
            registerSet.Rax.Should().Be(0x000000003205f31c);
            registerSet.Rbx.Should().Be(0x000000001e042120);
            registerSet.Rcx.Should().Be(0x000000003205f322);
            registerSet.Rdx.Should().Be(0x000000003205f2ce);
            emptySet.Should().Be(new RegisterSet());
        }

        [Fact]
        public void Process_Complicated_x86_Register_Requests()
        {
            var registers =
                @"
eax=12f77c40 
ebx=001e0000 
ecx=77c58e7e 
edx=64534afc 
esi=6453137c 
edi=0037b000 
esp=004ff8d0 
ebp=004ffb28 
eip=77c58e7e
efl=00000202 
cs=00000023 
ds=0000002b 
es=0000002b 
fs=00000053 
gs=0000002b 
ss=0000002b 
dr0=00000000 
dr1=00000000
dr2=00000000 
dr3=00000000 
dr6=00000000 
dr7=00000000 
di=b000 
si=137c
bx=0 
dx=4afc 
cx=8e7e 
ax=7c40
bp=fb28 
ip=8e7e
fl=202 
sp=f8d0 
bl=0 
dl=fc
cl=7e
al=40
bh=0 
dh=4a
ch=8e
ah=7c
iopl=0
of=0
df=0 
if=1 
tf=0 
sf=0
zf=0 
af=0 
pf=0 
cf=0 
vip=0
vif=0
mxcsr=00001f80 
xmm0=           0            0            0            0 
xmm1=           0            0            0            0 
xmm2=           0            0            0            0 
xmm3=           0            0            0            0 
xmm4=           0            0            0            0 
xmm5=           0            0            0            0 
xmm6=           0            0            0            0 
xmm7=           0            0            0            0 
mm0=0000000000000000 
mm1=0000000000000000 
mm2=0000000000000000 
mm3=0000000000000000 
mm4=0000000000000000 
mm5=0000000000000000
mm6=0000000000000000 
mm7=0000000000000000 
ymm0=           0            0            0            0            0            0            0            0 
ymm1=           0            0            0            0            0            0            0            0 
ymm2=           0            0            0            0            0            0            0            0 
ymm3=           0            0            0            0            0            0            0            0 
ymm4=           0            0            0            0            0            0            0            0 
ymm5=           0            0            0            0            0            0            0            0 
ymm6=           0            0            0            0            0            0            0            0 
ymm7=           0            0            0            0            0            0            0            0 
xmm0l=0000000000000000 
xmm1l=0000000000000000 
xmm2l=0000000000000000 
xmm3l=0000000000000000 
xmm4l=0000000000000000 
xmm5l=0000000000000000 
xmm6l=0000000000000000
xmm7l=0000000000000000 
xmm0h=0000000000000000 
xmm1h=0000000000000000 
xmm2h=0000000000000000 
xmm3h=0000000000000000 
xmm4h=0000000000000000 
xmm5h=0000000000000000 
xmm6h=0000000000000000 
xmm7h=0000000000000000 
fpcw=0000027f 
fpsw=00000000 
fptw=00000000
fopcode=00000000 
fpip=00000000 
fpipsel=00000000
fpdp=00000000 
fpdpsel=00000000 
st0= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000) 
st1= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000) 
st2= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000) 
st3= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000) 
st4= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)
st5= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000) 
st6= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000) 
st7= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)";
            var builder = new DebugEngineProxyBuilder();
            builder.With32Bit(false);
            var facade = new RegisterFacade();
            builder.WithExecuteResult(registers);
            builder.WithThreadId(1);
            facade.DebugEngineProxy = builder.Build();
            var registerSet = facade.GetCurrentRegisterSet(new Register[]
            {
                Eax, Ebx, Ecx, Edx, Esi, Edi, Esp, Ebp, Eip, Efl, Cs, Ds, Es, Fs, Gs, Ss, Dr0, Dr1, Dr2, Dr3, Dr6, Dr7,
                Di, Si, Bx, Dx, Cx, Ax, Bp, Ip, Fl, Sp, Bl, Dl, Cl, Al, Bh, Dh, Ch, Ah, Iopl, Of, Df, If, Tf, Sf, Zf,
                Af, Pf, Cf, Vip, Vif, Mxcsr, Xmm0, Xmm1, Xmm2, Xmm3, Xmm4, Xmm5, Xmm6, Xmm7, Mm0, Mm1, Mm2, Mm3, Mm4,
                Mm5, Mm6, Mm7, Ymm0, Ymm1, Ymm2, Ymm3, Ymm4, Ymm5, Ymm6, Ymm7, Xmm0l, Xmm1l, Xmm2l, Xmm3l, Xmm4l, Xmm5l,
                Xmm6l, Xmm7l, Xmm0h, Xmm1h, Xmm2h, Xmm3h, Xmm4h, Xmm5h, Xmm6h, Xmm7h, Fpcw, Fpsw, Fptw, Fopcode, Fpip,
                Fpipsel, Fpdp, Fpdpsel, St0, St1, St2, St3, St4, St5, St6, St7
            });
            registerSet.Eax.Should().Be(0x12f77c40);
            registerSet.Ebx.Should().Be(0x001e0000);
            registerSet.Ecx.Should().Be(0x77c58e7e);
        }

        [Fact]
        public void Return_The_Correct_Regex()
        {
            var fac = new RegisterFacade();

            fac.GetRegisterRegex(Af).Match("af=0").Groups["val"].Value.Should().Be("0");

            fac.GetRegisterRegex(Ah).Match("ah=7c").Groups["val"].Value.Should().Be("7c");

            fac.GetRegisterRegex(Al).Match("al=7c").Groups["val"].Value.Should().Be("7c");

            fac.GetRegisterRegex(Ax).Match("ax=31808").Groups["val"].Value.Should().Be("31808");

            fac.GetRegisterRegex(Bh).Match("bh=ff").Groups["val"].Value.Should().Be("ff");

            fac.GetRegisterRegex(Bl).Match("bl=ff").Groups["val"].Value.Should().Be("ff");

            fac.GetRegisterRegex(Bp).Match("bp=fb28").Groups["val"].Value.Should().Be("fb28");

            fac.GetRegisterRegex(Bpl).Match("bpl=f0").Groups["val"].Value.Should().Be("f0");

            fac.GetRegisterRegex(Brfrom).Match("brfrom=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Brto).Match("brto=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Bx).Match("bx=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Cf).Match("cf=0").Groups["val"].Value.Should().Be("0");

            fac.GetRegisterRegex(Ch).Match("ch=9b").Groups["val"].Value.Should().Be("9b");

            fac.GetRegisterRegex(Cl).Match("cl=a0").Groups["val"].Value.Should().Be("a0");

            fac.GetRegisterRegex(Cs).Match("cs=0033").Groups["val"].Value.Should().Be("0033");

            fac.GetRegisterRegex(Cx).Match("cx=9ba0").Groups["val"].Value.Should().Be("9ba0");

            fac.GetRegisterRegex(Df).Match("df=0").Groups["val"].Value.Should().Be("0");

            fac.GetRegisterRegex(Dh).Match("dh=0").Groups["val"].Value.Should().Be("0");

            fac.GetRegisterRegex(Di).Match("di=8544").Groups["val"].Value.Should().Be("8544");

            fac.GetRegisterRegex(Dil).Match("dil=0").Groups["val"].Value.Should().Be("0");

            fac.GetRegisterRegex(Dl).Match("dl=ce").Groups["val"].Value.Should().Be("ce");

            fac.GetRegisterRegex(Dr0).Match("dr0=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Dr1).Match("dr1=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Dr2).Match("dr2=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Dr3).Match("dr3=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Dr6).Match("dr6=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Dr7).Match("dr7=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Ds).Match("ds=002b").Groups["val"].Value.Should().Be("002b");

            fac.GetRegisterRegex(Dx).Match("dx=f2ce").Groups["val"].Value.Should().Be("f2ce");

            fac.GetRegisterRegex(Eax).Match("eax=3205f31c").Groups["val"].Value.Should().Be("3205f31c");

            fac.GetRegisterRegex(Ebp).Match("ebp=3205f31c").Groups["val"].Value.Should().Be("3205f31c");

            fac.GetRegisterRegex(Ebx).Match("ebx=3205f31c").Groups["val"].Value.Should().Be("3205f31c");

            fac.GetRegisterRegex(Ecx).Match("ecx=3205f31c").Groups["val"].Value.Should().Be("3205f31c");

            fac.GetRegisterRegex(Edi).Match("edi=3205f31c").Groups["val"].Value.Should().Be("3205f31c");

            fac.GetRegisterRegex(Edx).Match("edx=3205f31c").Groups["val"].Value.Should().Be("3205f31c");

            fac.GetRegisterRegex(Efl).Match("efl=3205f31c").Groups["val"].Value.Should().Be("3205f31c");

            fac.GetRegisterRegex(Eip).Match("eip=3205f31c").Groups["val"].Value.Should().Be("3205f31c");

            fac.GetRegisterRegex(Es).Match("es=0033").Groups["val"].Value.Should().Be("0033");

            fac.GetRegisterRegex(Esi).Match("esi=004ff300").Groups["val"].Value.Should().Be("004ff300");

            fac.GetRegisterRegex(Esp).Match("esp=004ff300").Groups["val"].Value.Should().Be("004ff300");

            fac.GetRegisterRegex(Exfrom).Match("exfrom=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Exto).Match("exto=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Fl).Match("fl=246").Groups["val"].Value.Should().Be("246");

            fac.GetRegisterRegex(Fpcw).Match("fpcw=027f").Groups["val"].Value.Should().Be("027f");

            fac.GetRegisterRegex(Fpsw).Match("fpsw=027f").Groups["val"].Value.Should().Be("027f");

            fac.GetRegisterRegex(Fptw).Match("fptw=027f").Groups["val"].Value.Should().Be("027f");

            fac.GetRegisterRegex(Fs).Match("fs=0053").Groups["val"].Value.Should().Be("0053");

            fac.GetRegisterRegex(Gs).Match("gs=002b").Groups["val"].Value.Should().Be("002b");

            fac.GetRegisterRegex(If).Match("if=1").Groups["val"].Value.Should().Be("1");

            fac.GetRegisterRegex(Iopl).Match("iopl=3").Groups["val"].Value.Should().Be("3");

            fac.GetRegisterRegex(Ip).Match("ip=5543").Groups["val"].Value.Should().Be("5543");

            fac.GetRegisterRegex(Mm0).Match("mm0=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Mm1).Match("mm1=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Mm2).Match("mm2=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Mm3).Match("mm3=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Mm4).Match("mm4=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Mm5).Match("mm5=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Mm6).Match("mm6=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Mm7).Match("mm7=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Mxcsr).Match("mxcsr=00001f80").Groups["val"].Value.Should().Be("00001f80");

            fac.GetRegisterRegex(Of).Match("of=1").Groups["val"].Value.Should().Be("1");

            fac.GetRegisterRegex(Pf).Match("pf=1").Groups["val"].Value.Should().Be("1");

            fac.GetRegisterRegex(R10).Match("r10=000000003205f2c0").Groups["val"].Value.Should().Be("000000003205f2c0");

            fac.GetRegisterRegex(R10b).Match("r10b=c0").Groups["val"].Value.Should().Be("c0");

            fac.GetRegisterRegex(R10d).Match("r10d=3205f2c0").Groups["val"].Value.Should().Be("3205f2c0");

            fac.GetRegisterRegex(R10w).Match("r10w=f2c0").Groups["val"].Value.Should().Be("f2c0");

            fac.GetRegisterRegex(R11).Match("r11=000000003205f2c0").Groups["val"].Value.Should().Be("000000003205f2c0");

            fac.GetRegisterRegex(R11b).Match("r11b=c0").Groups["val"].Value.Should().Be("c0");

            fac.GetRegisterRegex(R11d).Match("r11d=3205f2c0").Groups["val"].Value.Should().Be("3205f2c0");

            fac.GetRegisterRegex(R11w).Match("r11w=f2c0").Groups["val"].Value.Should().Be("f2c0");

            fac.GetRegisterRegex(R12).Match("r12=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(R12b).Match("r12b=FF").Groups["val"].Value.Should().Be("FF");

            fac.GetRegisterRegex(R12d).Match("r12d=FFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFF");

            fac.GetRegisterRegex(R12w).Match("r12w=FFFF").Groups["val"].Value.Should().Be("FFFF");

            fac.GetRegisterRegex(R13).Match("r13=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(R13b).Match("r13b=FF").Groups["val"].Value.Should().Be("FF");

            fac.GetRegisterRegex(R13d).Match("r13d=FFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFF");

            fac.GetRegisterRegex(R13w).Match("r13w=FFFF").Groups["val"].Value.Should().Be("FFFF");

            fac.GetRegisterRegex(R14).Match("r14=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(R14b).Match("r14b=FF").Groups["val"].Value.Should().Be("FF");

            fac.GetRegisterRegex(R14d).Match("r14d=FFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFF");

            fac.GetRegisterRegex(R14w).Match("r14w=FFFF").Groups["val"].Value.Should().Be("FFFF");

            fac.GetRegisterRegex(R15).Match("r15=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(R15b).Match("r15b=FF").Groups["val"].Value.Should().Be("FF");

            fac.GetRegisterRegex(R15d).Match("r15d=FFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFF");

            fac.GetRegisterRegex(R15w).Match("r15w=FFFF").Groups["val"].Value.Should().Be("FFFF");

            fac.GetRegisterRegex(R8).Match("r8=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(R8b).Match("r8b=FF").Groups["val"].Value.Should().Be("FF");

            fac.GetRegisterRegex(R8d).Match("r8d=FFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFF");

            fac.GetRegisterRegex(R8w).Match("r8w=FFFF").Groups["val"].Value.Should().Be("FFFF");

            fac.GetRegisterRegex(R9).Match("r9=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(R9b).Match("r9b=FF").Groups["val"].Value.Should().Be("FF");

            fac.GetRegisterRegex(R9d).Match("r9d=FFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFF");

            fac.GetRegisterRegex(R9w).Match("r9w=FFFF").Groups["val"].Value.Should().Be("FFFF");

            fac.GetRegisterRegex(Rax).Match("rax=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Rbp).Match("rbp=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Rbx).Match("rbx=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Rcx).Match("rcx=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Rdi).Match("rdi=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Rdx).Match("rdx=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Rip).Match("rip=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Rsi).Match("rsi=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Rsp).Match("rsp=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Sf).Match("sf=1").Groups["val"].Value.Should().Be("1");

            fac.GetRegisterRegex(Si).Match("si=105").Groups["val"].Value.Should().Be("105");

            fac.GetRegisterRegex(Sil).Match("sil=5").Groups["val"].Value.Should().Be("5");

            fac.GetRegisterRegex(Sp).Match("sp=d180").Groups["val"].Value.Should().Be("d180");

            fac.GetRegisterRegex(Spl).Match("spl=80").Groups["val"].Value.Should().Be("80");

            fac.GetRegisterRegex(Ss).Match("ss=002b").Groups["val"].Value.Should().Be("002b");

            Match m;
            m = fac.GetRegisterRegex(St0)
     .Match(
         "st0= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)");
            m.Groups["val"].Value.Should().Be("0000:0000000000000000");
            m = fac.GetRegisterRegex(St1)
                .Match(
                    "st1= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)");
            m.Groups["val"].Value.Should().Be("0000:0000000000000000");
            m = fac.GetRegisterRegex(St2)
                .Match(
                    "st2= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)");
            m.Groups["val"].Value.Should().Be("0000:0000000000000000");
            m = fac.GetRegisterRegex(St3)
                .Match(
                    "st3= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)");
            m.Groups["val"].Value.Should().Be("0000:0000000000000000");
            m = fac.GetRegisterRegex(St4)
                .Match(
                    "st4= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)");
            m.Groups["val"].Value.Should().Be("0000:0000000000000000");
            m = fac.GetRegisterRegex(St5)
                .Match(
                    "st5= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)");
            m.Groups["val"].Value.Should().Be("0000:0000000000000000");
            m = fac.GetRegisterRegex(St6)
                .Match(
                    "st6= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)");
            m.Groups["val"].Value.Should().Be("0000:0000000000000000");
            m = fac.GetRegisterRegex(St7)
                .Match(
                    "st7= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)");
            m.Groups["val"].Value.Should().Be("0000:0000000000000000");

            fac.GetRegisterRegex(Tf).Match("tf=1").Groups["val"].Value.Should().Be("1");

            fac.GetRegisterRegex(Vif).Match("vif=1").Groups["val"].Value.Should().Be("1");

            fac.GetRegisterRegex(Vip).Match("vip=1").Groups["val"].Value.Should().Be("1");

            fac.GetRegisterRegex(Xmm0).Match("xmm0=           0            0            0            0").Groups["val"].Value.Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Xmm0h).Match("xmm0h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm0l).Match("xmm0l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm1).Match("xmm1=           0            0            0            0").Groups["val"].Value.Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Xmm10).Match("xmm10=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Xmm10h).Match("xmm10h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm10l).Match("xmm10l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm11).Match("xmm11=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Xmm11h).Match("xmm11h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm11l).Match("xmm11l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm12).Match("xmm12=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Xmm12h).Match("xmm12h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm12l).Match("xmm12l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm13).Match("xmm13=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Xmm13h).Match("xmm13h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm13l).Match("xmm13l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm14).Match("xmm14=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Xmm14h).Match("xmm14h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm14l).Match("xmm14l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm15).Match("xmm15=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Xmm15h).Match("xmm15h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm15l).Match("xmm15l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm1h).Match("xmm1h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm1l).Match("xmm1l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm2).Match("xmm2=           0            0            0            0").Groups["val"].Value.Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Xmm2h).Match("xmm2h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm2l).Match("xmm2l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm3).Match("xmm3=           0            0            0            0").Groups["val"].Value.Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Xmm3h).Match("xmm3h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm3l).Match("xmm3l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm4).Match("xmm4=           0            0            0            0").Groups["val"].Value.Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Xmm4h).Match("xmm4h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm4l).Match("xmm4l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm5).Match("xmm5=           0            0            0            0").Groups["val"].Value.Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Xmm5h).Match("xmm5h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm5l).Match("xmm5l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm6).Match("xmm6=           0            0            0            0").Groups["val"].Value.Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Xmm6h).Match("xmm6h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm6l).Match("xmm6l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm7).Match("xmm7=           0            0            0            0").Groups["val"].Value.Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Xmm7h).Match("xmm7h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm7l).Match("xmm7l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm8).Match("xmm8=           0            0            0            0").Groups["val"].Value.Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Xmm8h).Match("xmm8h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm8l).Match("xmm8l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm9).Match("xmm9=           0            0            0            0").Groups["val"].Value.Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Xmm9h).Match("xmm9h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Xmm9l).Match("xmm9l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.GetRegisterRegex(Ymm0)
                .Match(
                    "ymm0=           0            0            0            0            0            0            0            0")
                .Groups["val"].Value.Should()
                .Be(
                    "           0            0            0            0            0            0            0            0");

            fac.GetRegisterRegex(Ymm0h).Match("ymm0h=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Ymm0l).Match("ymm0l=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");
            fac.GetRegisterRegex(Ymm1)
                .Match(
                    "ymm1=           0            0            0            0            0            0            0            0")
                .Groups["val"].Value.Should()
                .Be(
                    "           0            0            0            0            0            0            0            0");

            fac.GetRegisterRegex(Ymm1h).Match("ymm1h=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Ymm1l).Match("ymm1l=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");
            fac.GetRegisterRegex(Ymm2)
                .Match(
                    "ymm2=           0            0            0            0            0            0            0            0")
                .Groups["val"].Value.Should()
                .Be(
                    "           0            0            0            0            0            0            0            0");

            fac.GetRegisterRegex(Ymm2h).Match("ymm2h=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Ymm2l).Match("ymm2l=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");
            fac.GetRegisterRegex(Ymm3)
                .Match(
                    "ymm3=           0            0            0            0            0            0            0            0")
                .Groups["val"].Value.Should()
                .Be(
                    "           0            0            0            0            0            0            0            0");

            fac.GetRegisterRegex(Ymm3h).Match("ymm3h=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Ymm3l).Match("ymm3l=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");
            fac.GetRegisterRegex(Ymm4)
                .Match(
                    "ymm4=           0            0            0            0            0            0            0            0")
                .Groups["val"].Value.Should()
                .Be(
                    "           0            0            0            0            0            0            0            0");

            fac.GetRegisterRegex(Ymm4h).Match("ymm4h=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Ymm4l).Match("ymm4l=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");
            fac.GetRegisterRegex(Ymm5)
                .Match(
                    "ymm5=           0            0            0            0            0            0            0            0")
                .Groups["val"].Value.Should()
                .Be(
                    "           0            0            0            0            0            0            0            0");

            fac.GetRegisterRegex(Ymm5h).Match("ymm5h=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Ymm5l).Match("ymm5l=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");
            fac.GetRegisterRegex(Ymm6)
                .Match(
                    "ymm6=           0            0            0            0            0            0            0            0")
                .Groups["val"].Value.Should()
                .Be(
                    "           0            0            0            0            0            0            0            0");

            fac.GetRegisterRegex(Ymm6h).Match("ymm6h=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Ymm6l).Match("ymm6l=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");
            fac.GetRegisterRegex(Ymm7)
                .Match(
                    "ymm7=           0            0            0            0            0            0            0            0")
                .Groups["val"].Value.Should()
                .Be(
                    "           0            0            0            0            0            0            0            0");

            fac.GetRegisterRegex(Ymm7h).Match("ymm7h=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Ymm7l).Match("ymm7l=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");
            fac.GetRegisterRegex(Ymm8)
                .Match(
                    "ymm8=           0            0            0            0            0            0            0            0")
                .Groups["val"].Value.Should()
                .Be(
                    "           0            0            0            0            0            0            0            0");

            fac.GetRegisterRegex(Ymm8h).Match("ymm8h=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Ymm8l).Match("ymm8l=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");
            fac.GetRegisterRegex(Ymm9)
                .Match(
                    "ymm9=           0            0            0            0            0            0            0            0")
                .Groups["val"].Value.Should()
                .Be(
                    "           0            0            0            0            0            0            0            0");

            fac.GetRegisterRegex(Ymm9h).Match("ymm9h=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Ymm9l).Match("ymm9l=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");
            fac.GetRegisterRegex(Ymm10)
                .Match(
                    "ymm10=           0            0            0            0            0            0            0            0")
                .Groups["val"].Value.Should()
                .Be(
                    "           0            0            0            0            0            0            0            0");

            fac.GetRegisterRegex(Ymm10h).Match("ymm10h=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Ymm10l).Match("ymm10l=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");
            fac.GetRegisterRegex(Ymm11)
                .Match(
                    "ymm11=           0            0            0            0            0            0            0            0")
                .Groups["val"].Value.Should()
                .Be(
                    "           0            0            0            0            0            0            0            0");

            fac.GetRegisterRegex(Ymm11h).Match("ymm11h=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Ymm11l).Match("ymm11l=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");
            fac.GetRegisterRegex(Ymm12)
                .Match(
                    "ymm12=           0            0            0            0            0            0            0            0")
                .Groups["val"].Value.Should()
                .Be(
                    "           0            0            0            0            0            0            0            0");

            fac.GetRegisterRegex(Ymm12h).Match("ymm12h=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Ymm12l).Match("ymm12l=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");
            fac.GetRegisterRegex(Ymm13)
                .Match(
                    "ymm13=           0            0            0            0            0            0            0            0")
                .Groups["val"].Value.Should()
                .Be(
                    "           0            0            0            0            0            0            0            0");

            fac.GetRegisterRegex(Ymm13h).Match("ymm13h=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Ymm13l).Match("ymm13l=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");
            fac.GetRegisterRegex(Ymm14)
                .Match(
                    "ymm14=           0            0            0            0            0            0            0            0")
                .Groups["val"].Value.Should()
                .Be(
                    "           0            0            0            0            0            0            0            0");

            fac.GetRegisterRegex(Ymm14h).Match("ymm14h=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Ymm14l).Match("ymm14l=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");
            fac.GetRegisterRegex(Ymm15)
                .Match(
                    "ymm15=           0            0            0            0            0            0            0            0")
                .Groups["val"].Value.Should()
                .Be(
                    "           0            0            0            0            0            0            0            0");

            fac.GetRegisterRegex(Ymm15h).Match("ymm15h=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Ymm15l).Match("ymm15l=           0            0            0            0").Groups["val"].Value
                .Should()
                .Be("           0            0            0            0");

            fac.GetRegisterRegex(Zf).Match("zf=1").Groups["val"].Value.Should().Be("1");
        }

        [Fact]
        public void Process_Registers_Correctly()
        {
            var r = new RegisterSet();
            var rf = new RegisterFacade();

            rf.ProcessRegister(Rax, "0x0123456789abcdef", r);
            r.Rax.Should().Be(0x0123456789abcdef);
            r.Eax.Should().Be(0x89abcdef);
            r.Ax.Should().Be(0xcdef);
            r.Al.Should().Be(0xef);
            r.Ah.Should().Be(0xcd);

            r = new RegisterSet();
            rf.ProcessRegister(Rbx, "0x0123456789abcdef", r);
            r.Rbx.Should().Be(0x0123456789abcdef);
            r.Ebx.Should().Be(0x89abcdef);
            r.Bx.Should().Be(0xcdef);
            r.Bl.Should().Be(0xef);
            r.Bh.Should().Be(0xcd);

            r = new RegisterSet();
            rf.ProcessRegister(Rcx, "0x0123456789abcdef", r);
            r.Rcx.Should().Be(0x0123456789abcdef);
            r.Ecx.Should().Be(0x89abcdef);
            r.Cx.Should().Be(0xcdef);
            r.Cl.Should().Be(0xef);
            r.Ch.Should().Be(0xcd);

            r = new RegisterSet();
            rf.ProcessRegister(Rdx, "0x0123456789abcdef", r);
            r.Rdx.Should().Be(0x0123456789abcdef);
            r.Edx.Should().Be(0x89abcdef);
            r.Dx.Should().Be(0xcdef);
            r.Dl.Should().Be(0xef);
            r.Dh.Should().Be(0xcd);

            r = new RegisterSet();
            rf.ProcessRegister(Rsp, "0x0123456789abcdef", r);
            r.Rsp.Should().Be(0x0123456789abcdef);
            r.Esp.Should().Be(0x89abcdef);
            r.Sp.Should().Be(0xcdef);
            r.Spl.Should().Be(0xef);

            r = new RegisterSet();
            rf.ProcessRegister(Rbp, "0x0123456789abcdef", r);
            r.Rbp.Should().Be(0x0123456789abcdef);
            r.Ebp.Should().Be(0x89abcdef);
            r.Bp.Should().Be(0xcdef);
            r.Bpl.Should().Be(0xef);

            r = new RegisterSet();
            rf.ProcessRegister(Rsi, "0x0123456789abcdef", r);
            r.Rsi.Should().Be(0x0123456789abcdef);
            r.Esi.Should().Be(0x89abcdef);
            r.Si.Should().Be(0xcdef);
            r.Sil.Should().Be(0xef);

            r = new RegisterSet();
            rf.ProcessRegister(Rdi, "0x0123456789abcdef", r);
            r.Rdi.Should().Be(0x0123456789abcdef);
            r.Edi.Should().Be(0x89abcdef);
            r.Di.Should().Be(0xcdef);
            r.Dil.Should().Be(0xef);

            r = new RegisterSet();
            rf.ProcessRegister(R8, "0x0123456789abcdef", r);
            r.R8.Should().Be(0x0123456789abcdef);
            r.R8d.Should().Be(0x89abcdef);
            r.R8w.Should().Be(0xcdef);
            r.R8b.Should().Be(0xef);

            r = new RegisterSet();
            rf.ProcessRegister(R9, "0x0123456789abcdef", r);
            r.R9.Should().Be(0x0123456789abcdef);
            r.R9d.Should().Be(0x89abcdef);
            r.R9w.Should().Be(0xcdef);
            r.R9b.Should().Be(0xef);

            r = new RegisterSet();
            rf.ProcessRegister(R10, "0x0123456789abcdef", r);
            r.R10.Should().Be(0x0123456789abcdef);
            r.R10d.Should().Be(0x89abcdef);
            r.R10w.Should().Be(0xcdef);
            r.R10b.Should().Be(0xef);

            r = new RegisterSet();
            rf.ProcessRegister(R11, "0x0123456789abcdef", r);
            r.R11.Should().Be(0x0123456789abcdef);
            r.R11d.Should().Be(0x89abcdef);
            r.R11w.Should().Be(0xcdef);
            r.R11b.Should().Be(0xef);

            r = new RegisterSet();
            rf.ProcessRegister(R12, "0x0123456789abcdef", r);
            r.R12.Should().Be(0x0123456789abcdef);
            r.R12d.Should().Be(0x89abcdef);
            r.R12w.Should().Be(0xcdef);
            r.R12b.Should().Be(0xef);

            r = new RegisterSet();
            rf.ProcessRegister(R13, "0x0123456789abcdef", r);
            r.R13.Should().Be(0x0123456789abcdef);
            r.R13d.Should().Be(0x89abcdef);
            r.R13w.Should().Be(0xcdef);
            r.R13b.Should().Be(0xef);

            r = new RegisterSet();
            rf.ProcessRegister(R14, "0x0123456789abcdef", r);
            r.R14.Should().Be(0x0123456789abcdef);
            r.R14d.Should().Be(0x89abcdef);
            r.R14w.Should().Be(0xcdef);
            r.R14b.Should().Be(0xef);

            r = new RegisterSet();
            rf.ProcessRegister(R15, "0x0123456789abcdef", r);
            r.R15.Should().Be(0x0123456789abcdef);
            r.R15d.Should().Be(0x89abcdef);
            r.R15w.Should().Be(0xcdef);
            r.R15b.Should().Be(0xef);

            r = new RegisterSet();
            rf.ProcessRegister(Rip, "0x0123456789abcdef", r);
            r.Rip.Should().Be(0x0123456789abcdef);
            r.Eip.Should().Be(0x89abcdef);
            r.Ip.Should().Be(0xcdef);

            r = new RegisterSet();
            rf.ProcessRegister(Efl, "0x01234567", r);
            r.Efl.Should().Be(0x01234567);
            r.Fl.Should().Be(0x4567);

            r = new RegisterSet();
            rf.ProcessRegister(Cs, "0x0123", r);
            r.Cs.Should().Be(0x0123);

            r = new RegisterSet();
            rf.ProcessRegister(Ds, "0x0123", r);
            r.Ds.Should().Be(0x0123);

            r = new RegisterSet();
            rf.ProcessRegister(Es, "0x0123", r);
            r.Es.Should().Be(0x0123);

            r = new RegisterSet();
            rf.ProcessRegister(Fs, "0x0123", r);
            r.Fs.Should().Be(0x0123);

            r = new RegisterSet();
            rf.ProcessRegister(Gs, "0x0123", r);
            r.Gs.Should().Be(0x0123);

            r = new RegisterSet();
            rf.ProcessRegister(Ss, "0x0123", r);
            r.Ss.Should().Be(0x0123); 

            r = new RegisterSet();
            rf.ProcessRegister(Dr0, "0x0123456789abcdef", r);
            r.Dr0.Should().Be(0x0123456789abcdef);

            r = new RegisterSet();
            rf.ProcessRegister(Dr1, "0x0123456789abcdef", r);
            r.Dr1.Should().Be(0x0123456789abcdef);

            r = new RegisterSet();
            rf.ProcessRegister(Dr2, "0x0123456789abcdef", r);
            r.Dr2.Should().Be(0x0123456789abcdef);

            r = new RegisterSet();
            rf.ProcessRegister(Dr3, "0x0123456789abcdef", r);
            r.Dr3.Should().Be(0x0123456789abcdef);

            r = new RegisterSet();
            rf.ProcessRegister(Dr6, "0x0123456789abcdef", r);
            r.Dr6.Should().Be(0x0123456789abcdef);

            r = new RegisterSet();
            rf.ProcessRegister(Dr7, "0x0123456789abcdef", r);
            r.Dr7.Should().Be(0x0123456789abcdef);

            r = new RegisterSet();
            rf.ProcessRegister(Fpcw, "0x0123", r);
            r.Fpcw.Should().Be(0x0123);

            r = new RegisterSet();
            rf.ProcessRegister(Fpsw, "0x0123", r);
            r.Fpsw.Should().Be(0x123);

            r = new RegisterSet();
            rf.ProcessRegister(Fptw, "0x0123", r);
            r.Fptw.Should().Be(0x123);

            r = new RegisterSet();
            rf.ProcessRegister(Fopcode, "0x0123", r);
            r.Fopcode.Should().Be(0x123);

            r = new RegisterSet();
            rf.ProcessRegister(Fpip, "0x0123", r);
            r.Fpip.Should().Be(0x123);

            r = new RegisterSet();
            rf.ProcessRegister(Fpipsel, "0x0123", r);
            r.Fpipsel.Should().Be(0x123);

            r = new RegisterSet();
            rf.ProcessRegister(Fpdp, "0x0123", r);
            r.Fpdp.Should().Be(0x123);

            r = new RegisterSet();
            rf.ProcessRegister(Fpdpsel, "0x0123", r);
            r.Fpdpsel.Should().Be(0x123);

            r = new RegisterSet();
            rf.ProcessRegister(St0, "1234:0123456789abcdef", r);
            r.St0.Should().Equal(new[] {0x12, 0x34, 0x01, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef}.Reverse());

            r = new RegisterSet();
            rf.ProcessRegister(St1, "1234:0123456789abcdef", r);
            r.St1.Should().Equal(new[] { 0x12, 0x34, 0x01, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef }.Reverse());

            r = new RegisterSet();
            rf.ProcessRegister(St2, "1234:0123456789abcdef", r);
            r.St2.Should().Equal(new[] { 0x12, 0x34, 0x01, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef }.Reverse());

            r = new RegisterSet();
            rf.ProcessRegister(St3, "1234:0123456789abcdef", r);
            r.St3.Should().Equal(new[] { 0x12, 0x34, 0x01, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef }.Reverse());

            r = new RegisterSet();
            rf.ProcessRegister(St4, "1234:0123456789abcdef", r);
            r.St4.Should().Equal(new[] { 0x12, 0x34, 0x01, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef }.Reverse());

            r = new RegisterSet();
            rf.ProcessRegister(St5, "1234:0123456789abcdef", r);
            r.St5.Should().Equal(new[] { 0x12, 0x34, 0x01, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef }.Reverse());

            r = new RegisterSet();
            rf.ProcessRegister(St6, "1234:0123456789abcdef", r);
            r.St6.Should().Equal(new[] { 0x12, 0x34, 0x01, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef }.Reverse());

            r = new RegisterSet();
            rf.ProcessRegister(St7, "1234:0123456789abcdef", r);
            r.St7.Should().Equal(new[] { 0x12, 0x34, 0x01, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef }.Reverse());

            r = new RegisterSet();
            rf.ProcessRegister(Mm0, "0xffffffffffffffff", r);
            r.Mm0.Should().Be(0xffffffffffffffff);

            r = new RegisterSet();
            rf.ProcessRegister(Mm1, "0xfedcba9876543210", r);
            r.Mm1.Should().Be(0xfedcba9876543210);

            r = new RegisterSet();
            rf.ProcessRegister(Mm2, "0xfedcba9876543210", r);
            r.Mm2.Should().Be(0xfedcba9876543210);

            r = new RegisterSet();
            rf.ProcessRegister(Mm3, "0xfedcba9876543210", r);
            r.Mm3.Should().Be(0xfedcba9876543210);

            r = new RegisterSet();
            rf.ProcessRegister(Mm4, "0xfedcba9876543210", r);
            r.Mm4.Should().Be(0xfedcba9876543210);

            r = new RegisterSet();
            rf.ProcessRegister(Mm5, "0xfedcba9876543210", r);
            r.Mm5.Should().Be(0xfedcba9876543210);

            r = new RegisterSet();
            rf.ProcessRegister(Mm6, "0xfedcba9876543210", r);
            r.Mm6.Should().Be(0xfedcba9876543210);

            r = new RegisterSet();
            rf.ProcessRegister(Mm7, "0xfedcba9876543210", r);
            r.Mm7.Should().Be(0xfedcba9876543210);

            r = new RegisterSet();
            rf.ProcessRegister(Mxcsr, "76543210", r);
            r.Mxcsr.Should().Be(0x76543210);

            r = new RegisterSet();
            rf.ProcessRegister(Ymm0, "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567", r);
            r.Ymm0.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm0.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm0l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm1, "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567", r);
            r.Ymm1.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm1.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm1l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm2, "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567", r);
            r.Ymm2.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm2.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm2l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm3, "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567", r);
            r.Ymm3.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm3.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm3l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm4, "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567", r);
            r.Ymm4.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm4.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm4l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm5, "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567", r);
            r.Ymm5.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm5.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm5l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm6, "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567", r);
            r.Ymm6.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm6.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm6l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm7, "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567", r);
            r.Ymm7.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm7.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm7l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm8, "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567", r);
            r.Ymm8.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm8.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm8l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm9, "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567", r);
            r.Ymm9.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm9.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm9l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm10, "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567", r);
            r.Ymm10.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm10.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm10l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm11, "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567", r);
            r.Ymm11.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm11.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm11l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm12, "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567", r);
            r.Ymm12.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm12.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm12l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm13, "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567", r);
            r.Ymm13.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm13.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm13l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm14, "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567", r);
            r.Ymm14.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm14.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm14l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm15, "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567", r);
            r.Ymm15.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm15.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm15l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm0, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Xmm0.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm0.Should().Equal(r.Xmm0.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm1, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Xmm1.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm1.Should().Equal(r.Xmm1.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm2, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Xmm2.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm2.Should().Equal(r.Xmm2.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm3, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Xmm3.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm3.Should().Equal(r.Xmm3.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm4, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Xmm4.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm4.Should().Equal(r.Xmm4.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm5, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Xmm5.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm5.Should().Equal(r.Xmm5.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm6, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Xmm6.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm6.Should().Equal(r.Xmm6.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm7, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Xmm7.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm7.Should().Equal(r.Xmm7.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm8, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Xmm8.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm8.Should().Equal(r.Xmm8.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm9, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Xmm9.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm9.Should().Equal(r.Xmm9.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm10, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Xmm10.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm10.Should().Equal(r.Xmm10.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm11, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Xmm11.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm11.Should().Equal(r.Xmm11.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm12, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Xmm12.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm12.Should().Equal(r.Xmm12.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm13, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Xmm13.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm13.Should().Equal(r.Xmm13.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm14, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Xmm14.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm14.Should().Equal(r.Xmm14.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm15, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Xmm15.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm15.Should().Equal(r.Xmm15.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm0l, "deadbeeffacecafe", r);
            r.Xmm0l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm0.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm0.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm1l, "deadbeeffacecafe", r);
            r.Xmm1l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm1.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm1.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm2l, "deadbeeffacecafe", r);
            r.Xmm2l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm2.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm2.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm3l, "deadbeeffacecafe", r);
            r.Xmm3l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm3.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm3.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm4l, "deadbeeffacecafe", r);
            r.Xmm4l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm4.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm4.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm5l, "deadbeeffacecafe", r);
            r.Xmm5l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm5.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm5.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm6l, "deadbeeffacecafe", r);
            r.Xmm6l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm6.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm6.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm7l, "deadbeeffacecafe", r);
            r.Xmm7l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm7.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm7.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm8l, "deadbeeffacecafe", r);
            r.Xmm8l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm8.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm8.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm9l, "deadbeeffacecafe", r);
            r.Xmm9l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm9.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm9.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm10l, "deadbeeffacecafe", r);
            r.Xmm10l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm10.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm10.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm11l, "deadbeeffacecafe", r);
            r.Xmm11l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm11.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm11.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm12l, "deadbeeffacecafe", r);
            r.Xmm12l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm12.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm12.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm13l, "deadbeeffacecafe", r);
            r.Xmm13l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm13.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm13.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm14l, "deadbeeffacecafe", r);
            r.Xmm14l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm14.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm14.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm15l, "deadbeeffacecafe", r);
            r.Xmm15l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm15.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm15.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            rf.ProcessRegister(Xmm0h, "deadbeeffacecafe", r);
            r.Xmm0h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm0.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm0.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm0l.Should().Be(0);

            r = new RegisterSet();
            rf.ProcessRegister(Xmm1h, "deadbeeffacecafe", r);
            r.Xmm1h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm1.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm1.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm1l.Should().Be(0);

            r = new RegisterSet();
            rf.ProcessRegister(Xmm2h, "deadbeeffacecafe", r);
            r.Xmm2h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm2.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm2.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm2l.Should().Be(0);

            r = new RegisterSet();
            rf.ProcessRegister(Xmm3h, "deadbeeffacecafe", r);
            r.Xmm3h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm3.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm3.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm3l.Should().Be(0);

            r = new RegisterSet();
            rf.ProcessRegister(Xmm4h, "deadbeeffacecafe", r);
            r.Xmm4h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm4.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm4.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm4l.Should().Be(0);

            r = new RegisterSet();
            rf.ProcessRegister(Xmm5h, "deadbeeffacecafe", r);
            r.Xmm5h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm5.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm5.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm5l.Should().Be(0);

            r = new RegisterSet();
            rf.ProcessRegister(Xmm6h, "deadbeeffacecafe", r);
            r.Xmm6h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm6.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm6.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm6l.Should().Be(0);

            r = new RegisterSet();
            rf.ProcessRegister(Xmm7h, "deadbeeffacecafe", r);
            r.Xmm7h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm7.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm7.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm7l.Should().Be(0);

            r = new RegisterSet();
            rf.ProcessRegister(Xmm8h, "deadbeeffacecafe", r);
            r.Xmm8h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm8.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm8.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm8l.Should().Be(0);

            r = new RegisterSet();
            rf.ProcessRegister(Xmm9h, "deadbeeffacecafe", r);
            r.Xmm9h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm9.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm9.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm9l.Should().Be(0);

            r = new RegisterSet();
            rf.ProcessRegister(Xmm10h, "deadbeeffacecafe", r);
            r.Xmm10h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm10.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm10.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm10l.Should().Be(0);

            r = new RegisterSet();
            rf.ProcessRegister(Xmm11h, "deadbeeffacecafe", r);
            r.Xmm11h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm11.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm11.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm11l.Should().Be(0);

            r = new RegisterSet();
            rf.ProcessRegister(Xmm12h, "deadbeeffacecafe", r);
            r.Xmm12h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm12.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm12.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm12l.Should().Be(0);

            r = new RegisterSet();
            rf.ProcessRegister(Xmm13h, "deadbeeffacecafe", r);
            r.Xmm13h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm13.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm13.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm13l.Should().Be(0);

            r = new RegisterSet();
            rf.ProcessRegister(Xmm14h, "deadbeeffacecafe", r);
            r.Xmm14h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm14.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm14.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm14l.Should().Be(0);

            r = new RegisterSet();
            rf.ProcessRegister(Xmm15h, "deadbeeffacecafe", r);
            r.Xmm15h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm15.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm15.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm15l.Should().Be(0);

            r = new RegisterSet();
            rf.ProcessRegister(Ymm0h, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm0.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm0.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            rf.ProcessRegister(Ymm1h, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm1.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm1.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            rf.ProcessRegister(Ymm2h, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm2.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm2.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            rf.ProcessRegister(Ymm3h, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm3.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm3.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            rf.ProcessRegister(Ymm4h, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm4.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm4.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            rf.ProcessRegister(Ymm5h, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm5.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm5.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            rf.ProcessRegister(Ymm6h, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm6.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm6.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            rf.ProcessRegister(Ymm7h, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm7.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm7.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            rf.ProcessRegister(Ymm8h, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm8.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm8.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            rf.ProcessRegister(Ymm9h, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm9.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm9.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            rf.ProcessRegister(Ymm10h, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm10.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm10.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            rf.ProcessRegister(Ymm11h, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm11.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm11.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            rf.ProcessRegister(Ymm12h, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm12.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm12.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            rf.ProcessRegister(Ymm13h, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm13.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm13.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            rf.ProcessRegister(Ymm14h, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm14.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm14.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            rf.ProcessRegister(Ymm15h, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm15.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm15.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            rf.ProcessRegister(Ymm0l, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm0l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm0.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm0.Should().Equal(r.Xmm0.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm1l, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm1l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm1.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm1.Should().Equal(r.Xmm1.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm2l, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm2l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm2.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm2.Should().Equal(r.Xmm2.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm3l, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm3l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm3.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm3.Should().Equal(r.Xmm3.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm4l, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm4l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm4.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm4.Should().Equal(r.Xmm4.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm5l, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm5l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm5.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm5.Should().Equal(r.Xmm5.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm6l, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm6l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm6.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm6.Should().Equal(r.Xmm6.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm7l, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm7l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm7.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm7.Should().Equal(r.Xmm7.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm8l, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm8l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm8.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm8.Should().Equal(r.Xmm8.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm9l, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm9l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm9.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm9.Should().Equal(r.Xmm9.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm10l, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm10l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm10.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm10.Should().Equal(r.Xmm10.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm11l, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm11l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm11.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm11.Should().Equal(r.Xmm11.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm12l, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm12l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm12.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm12.Should().Equal(r.Xmm12.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm13l, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm13l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm13.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm13.Should().Equal(r.Xmm13.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm14l, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm14l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm14.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm14.Should().Equal(r.Xmm14.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Ymm15l, "    12345678     deadbeef     abcdabcd     01020304", r);
            r.Ymm15l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm15.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm15.Should().Equal(r.Xmm15.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            rf.ProcessRegister(Exfrom, "12345678deadbeef", r);
            r.Exfrom.Should().Be(0x12345678deadbeef);

            r = new RegisterSet();
            rf.ProcessRegister(Exto, "12345678deadbeef", r);
            r.Exto.Should().Be(0x12345678deadbeef);

            r = new RegisterSet();
            rf.ProcessRegister(Brfrom, "12345678deadbeef", r);
            r.Brfrom.Should().Be(0x12345678deadbeef);

            r = new RegisterSet();
            rf.ProcessRegister(Brto, "12345678deadbeef", r);
            r.Brto.Should().Be(0x12345678deadbeef);

            r = new RegisterSet();
            rf.ProcessRegister(Eax, "12345678", r);
            r.Eax.Should().Be(0x12345678);

            r = new RegisterSet();
            rf.ProcessRegister(Ecx, "12345678", r);
            r.Ecx.Should().Be(0x12345678);

            r = new RegisterSet();
            rf.ProcessRegister(Edx, "12345678", r);
            r.Edx.Should().Be(0x12345678);

            r = new RegisterSet();
            rf.ProcessRegister(Ebx, "12345678", r);
            r.Ebx.Should().Be(0x12345678);

            r = new RegisterSet();
            rf.ProcessRegister(Esp, "12345678", r);
            r.Esp.Should().Be(0x12345678);

            r = new RegisterSet();
            rf.ProcessRegister(Ebp, "12345678", r);
            r.Ebp.Should().Be(0x12345678);

            r = new RegisterSet();
            rf.ProcessRegister(Esi, "12345678", r);
            r.Esi.Should().Be(0x12345678);

            r = new RegisterSet();
            rf.ProcessRegister(Edi, "12345678", r);
            r.Edi.Should().Be(0x12345678);

            r = new RegisterSet();
            rf.ProcessRegister(R8d, "12345678", r);
            r.R8d.Should().Be(0x12345678);

            r = new RegisterSet();
            rf.ProcessRegister(R9d, "12345678", r);
            r.R9d.Should().Be(0x12345678);

            r = new RegisterSet();
            rf.ProcessRegister(R10d, "12345678", r);
            r.R10d.Should().Be(0x12345678);

            r = new RegisterSet();
            rf.ProcessRegister(R11d, "12345678", r);
            r.R11d.Should().Be(0x12345678);

            r = new RegisterSet();
            rf.ProcessRegister(R12d, "12345678", r);
            r.R12d.Should().Be(0x12345678);

            r = new RegisterSet();
            rf.ProcessRegister(R13d, "12345678", r);
            r.R13d.Should().Be(0x12345678);

            r = new RegisterSet();
            rf.ProcessRegister(R14d, "12345678", r);
            r.R14d.Should().Be(0x12345678);

            r = new RegisterSet();
            rf.ProcessRegister(R15d, "12345678", r);
            r.R15d.Should().Be(0x12345678);

            r = new RegisterSet();
            rf.ProcessRegister(Eip, "12345678", r);
            r.Eip.Should().Be(0x12345678);

            r = new RegisterSet();
            rf.ProcessRegister(Ax, "1234", r);
            r.Ax.Should().Be(0x1234);

            r = new RegisterSet();
            rf.ProcessRegister(Cx, "1234", r);
            r.Cx.Should().Be(0x1234);

            r = new RegisterSet();
            rf.ProcessRegister(Dx, "1234", r);
            r.Dx.Should().Be(0x1234);

            r = new RegisterSet();
            rf.ProcessRegister(Bx, "1234", r);
            r.Bx.Should().Be(0x1234);

            r = new RegisterSet();
            rf.ProcessRegister(Sp, "1234", r);
            r.Sp.Should().Be(0x1234);

            r = new RegisterSet();
            rf.ProcessRegister(Bp, "1234", r);
            r.Bp.Should().Be(0x1234);

            r = new RegisterSet();
            rf.ProcessRegister(Si, "1234", r);
            r.Si.Should().Be(0x1234);

            r = new RegisterSet();
            rf.ProcessRegister(Di, "1234", r);
            r.Di.Should().Be(0x1234);

            r = new RegisterSet();
            rf.ProcessRegister(R8w, "1234", r);
            r.R8w.Should().Be(0x1234);

            r = new RegisterSet();
            rf.ProcessRegister(R9w, "1234", r);
            r.R9w.Should().Be(0x1234);

            r = new RegisterSet();
            rf.ProcessRegister(R10w, "1234", r);
            r.R10w.Should().Be(0x1234);

            r = new RegisterSet();
            rf.ProcessRegister(R11w, "1234", r);
            r.R11w.Should().Be(0x1234);

            r = new RegisterSet();
            rf.ProcessRegister(R12w, "1234", r);
            r.R12w.Should().Be(0x1234);

            r = new RegisterSet();
            rf.ProcessRegister(R13w, "1234", r);
            r.R13w.Should().Be(0x1234);

            r = new RegisterSet();
            rf.ProcessRegister(R14w, "1234", r);
            r.R14w.Should().Be(0x1234);

            r = new RegisterSet();
            rf.ProcessRegister(R15w, "1234", r);
            r.R15w.Should().Be(0x1234);

            r = new RegisterSet();
            rf.ProcessRegister(Ip, "1234", r);
            r.Ip.Should().Be(0x1234);

            r = new RegisterSet();
            rf.ProcessRegister(Fl, "1234", r);
            r.Fl.Should().Be(0x1234);

            r = new RegisterSet();
            rf.ProcessRegister(Al, "12", r);
            r.Al.Should().Be(0x12);

            r = new RegisterSet();
            rf.ProcessRegister(Bl, "12", r);
            r.Bl.Should().Be(0x12);

            r = new RegisterSet();
            rf.ProcessRegister(Cl, "12", r);
            r.Cl.Should().Be(0x12);

            r = new RegisterSet();
            rf.ProcessRegister(Dl, "12", r);
            r.Dl.Should().Be(0x12);

            r = new RegisterSet();
            rf.ProcessRegister(Spl, "12", r);
            r.Spl.Should().Be(0x12);

            r = new RegisterSet();
            rf.ProcessRegister(Bpl, "12", r);
            r.Bpl.Should().Be(0x12);

            r = new RegisterSet();
            rf.ProcessRegister(Sil, "12", r);
            r.Sil.Should().Be(0x12);

            r = new RegisterSet();
            rf.ProcessRegister(Dil, "12", r);
            r.Dil.Should().Be(0x12);

            r = new RegisterSet();
            rf.ProcessRegister(R8d, "12", r);
            r.R8d.Should().Be(0x12);

            r = new RegisterSet();
            rf.ProcessRegister(R9d, "12", r);
            r.R9d.Should().Be(0x12);

            r = new RegisterSet();
            rf.ProcessRegister(R10d, "12", r);
            r.R10d.Should().Be(0x12);

            r = new RegisterSet();
            rf.ProcessRegister(R11d, "12", r);
            r.R11d.Should().Be(0x12);

            r = new RegisterSet();
            rf.ProcessRegister(R12d, "12", r);
            r.R12d.Should().Be(0x12);

            r = new RegisterSet();
            rf.ProcessRegister(R13d, "12", r);
            r.R13d.Should().Be(0x12);

            r = new RegisterSet();
            rf.ProcessRegister(R14d, "12", r);
            r.R14d.Should().Be(0x12);

            r = new RegisterSet();
            rf.ProcessRegister(R15d, "12", r);
            r.R15d.Should().Be(0x12);

            r = new RegisterSet();
            rf.ProcessRegister(Ah, "12", r);
            r.Ah.Should().Be(0x12);

            r = new RegisterSet();
            rf.ProcessRegister(Bh, "12", r);
            r.Bh.Should().Be(0x12);

            r = new RegisterSet();
            rf.ProcessRegister(Ch, "12", r);
            r.Ch.Should().Be(0x12);

            r = new RegisterSet();
            rf.ProcessRegister(Dh, "12", r);
            r.Dh.Should().Be(0x12);

            r = new RegisterSet();
            rf.ProcessRegister(Iopl, "3", r);
            r.Iopl.Should().Be(0x3);

            r = new RegisterSet();
            rf.ProcessRegister(Of, "1", r);
            r.Of.Should().BeTrue();

            r = new RegisterSet();
            rf.ProcessRegister(Df, "1", r);
            r.Df.Should().BeTrue();

            r = new RegisterSet();
            rf.ProcessRegister(If, "1", r);
            r.If.Should().BeTrue();

            r = new RegisterSet();
            rf.ProcessRegister(Tf, "1", r);
            r.Tf.Should().BeTrue();

            r = new RegisterSet();
            rf.ProcessRegister(Sf, "1", r);
            r.Sf.Should().BeTrue();

            r = new RegisterSet();
            rf.ProcessRegister(Zf, "1", r);
            r.Zf.Should().BeTrue();

            r = new RegisterSet();
            rf.ProcessRegister(Af, "1", r);
            r.Af.Should().BeTrue();

            r = new RegisterSet();
            rf.ProcessRegister(Pf, "1", r);
            r.Pf.Should().BeTrue();

            r = new RegisterSet();
            rf.ProcessRegister(Cf, "1", r);
            r.Cf.Should().BeTrue();

            r = new RegisterSet();
            rf.ProcessRegister(Vip, "1", r);
            r.Vip.Should().BeTrue();

            r = new RegisterSet();
            rf.ProcessRegister(Vif, "1", r);
            r.Vif.Should().BeTrue();
        }

    }
}