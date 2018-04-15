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
            var registerSet = facade.GetCurrentRegisterSet(new Register[] {Rax, Rbx, Rcx, Rdx, Di, Edi, Ax, Eax});
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

            fac.Get(Af).Match("af=0").Groups["val"].Value.Should().Be("0");

            fac.Get(Ah).Match("ah=7c").Groups["val"].Value.Should().Be("7c");

            fac.Get(Al).Match("al=7c").Groups["val"].Value.Should().Be("7c");

            fac.Get(Ax).Match("ax=31808").Groups["val"].Value.Should().Be("31808");

            fac.Get(Bh).Match("bh=ff").Groups["val"].Value.Should().Be("ff");

            fac.Get(Bl).Match("bl=ff").Groups["val"].Value.Should().Be("ff");

            fac.Get(Bp).Match("bp=fb28").Groups["val"].Value.Should().Be("fb28");

            fac.Get(Bpl).Match("bpl=f0").Groups["val"].Value.Should().Be("f0");

            fac.Get(Brfrom).Match("brfrom=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Brto).Match("brto=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Bx).Match("bx=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Cf).Match("cf=0").Groups["val"].Value.Should().Be("0");

            fac.Get(Ch).Match("ch=9b").Groups["val"].Value.Should().Be("9b");

            fac.Get(Cl).Match("cl=a0").Groups["val"].Value.Should().Be("a0");

            fac.Get(Cs).Match("cs=0033").Groups["val"].Value.Should().Be("0033");

            fac.Get(Cx).Match("cx=9ba0").Groups["val"].Value.Should().Be("9ba0");

            fac.Get(Df).Match("df=0").Groups["val"].Value.Should().Be("0");

            fac.Get(Dh).Match("dh=0").Groups["val"].Value.Should().Be("0");

            fac.Get(Di).Match("di=8544").Groups["val"].Value.Should().Be("8544");

            fac.Get(Dil).Match("dil=0").Groups["val"].Value.Should().Be("0");

            fac.Get(Dl).Match("dl=ce").Groups["val"].Value.Should().Be("ce");

            fac.Get(Dr0).Match("dr0=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Dr1).Match("dr1=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Dr2).Match("dr2=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Dr3).Match("dr3=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Dr6).Match("dr6=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Dr7).Match("dr7=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Ds).Match("ds=002b").Groups["val"].Value.Should().Be("002b");

            fac.Get(Dx).Match("dx=f2ce").Groups["val"].Value.Should().Be("f2ce");

            fac.Get(Eax).Match("eax=3205f31c").Groups["val"].Value.Should().Be("3205f31c");

            fac.Get(Ebp).Match("ebp=3205f31c").Groups["val"].Value.Should().Be("3205f31c");

            fac.Get(Ebx).Match("ebx=3205f31c").Groups["val"].Value.Should().Be("3205f31c");

            fac.Get(Ecx).Match("ecx=3205f31c").Groups["val"].Value.Should().Be("3205f31c");

            fac.Get(Edi).Match("edi=3205f31c").Groups["val"].Value.Should().Be("3205f31c");

            fac.Get(Edx).Match("edx=3205f31c").Groups["val"].Value.Should().Be("3205f31c");

            fac.Get(Efl).Match("efl=3205f31c").Groups["val"].Value.Should().Be("3205f31c");

            fac.Get(Eip).Match("eip=3205f31c").Groups["val"].Value.Should().Be("3205f31c");

            fac.Get(Es).Match("es=0033").Groups["val"].Value.Should().Be("0033");

            fac.Get(Esi).Match("esi=004ff300").Groups["val"].Value.Should().Be("004ff300");

            fac.Get(Esp).Match("esp=004ff300").Groups["val"].Value.Should().Be("004ff300");

            fac.Get(Exfrom).Match("exfrom=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Exto).Match("exto=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Fl).Match("fl=246").Groups["val"].Value.Should().Be("246");

            fac.Get(Fpcw).Match("fpcw=027f").Groups["val"].Value.Should().Be("027f");

            fac.Get(Fpsw).Match("fpsw=027f").Groups["val"].Value.Should().Be("027f");

            fac.Get(Fptw).Match("fptw=027f").Groups["val"].Value.Should().Be("027f");

            fac.Get(Fs).Match("fs=0053").Groups["val"].Value.Should().Be("0053");

            fac.Get(Gs).Match("gs=002b").Groups["val"].Value.Should().Be("002b");

            fac.Get(If).Match("if=1").Groups["val"].Value.Should().Be("1");

            fac.Get(Iopl).Match("iopl=3").Groups["val"].Value.Should().Be("3");

            fac.Get(Ip).Match("ip=5543").Groups["val"].Value.Should().Be("5543");

            fac.Get(Mm0).Match("mm0=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Mm1).Match("mm1=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Mm2).Match("mm2=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Mm3).Match("mm3=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Mm4).Match("mm4=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Mm5).Match("mm5=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Mm6).Match("mm6=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Mm7).Match("mm7=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Mxcsr).Match("mxcsr=00001f80").Groups["val"].Value.Should().Be("00001f80");

            fac.Get(Of).Match("of=1").Groups["val"].Value.Should().Be("1");

            fac.Get(Pf).Match("pf=1").Groups["val"].Value.Should().Be("1");

            fac.Get(R10).Match("r10=000000003205f2c0").Groups["val"].Value.Should().Be("000000003205f2c0");

            fac.Get(R10b).Match("r10b=c0").Groups["val"].Value.Should().Be("c0");

            fac.Get(R10d).Match("r10d=3205f2c0").Groups["val"].Value.Should().Be("3205f2c0");

            fac.Get(R10w).Match("r10w=f2c0").Groups["val"].Value.Should().Be("f2c0");

            fac.Get(R11).Match("r11=000000003205f2c0").Groups["val"].Value.Should().Be("000000003205f2c0");

            fac.Get(R11b).Match("r11b=c0").Groups["val"].Value.Should().Be("c0");

            fac.Get(R11d).Match("r11d=3205f2c0").Groups["val"].Value.Should().Be("3205f2c0");

            fac.Get(R11w).Match("r11w=f2c0").Groups["val"].Value.Should().Be("f2c0");

            fac.Get(R12).Match("r12=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(R12b).Match("r12b=FF").Groups["val"].Value.Should().Be("FF");

            fac.Get(R12d).Match("r12d=FFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFF");

            fac.Get(R12w).Match("r12w=FFFF").Groups["val"].Value.Should().Be("FFFF");

            fac.Get(R13).Match("r13=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(R13b).Match("r13b=FF").Groups["val"].Value.Should().Be("FF");

            fac.Get(R13d).Match("r13d=FFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFF");

            fac.Get(R13w).Match("r13w=FFFF").Groups["val"].Value.Should().Be("FFFF");

            fac.Get(R14).Match("r14=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(R14b).Match("r14b=FF").Groups["val"].Value.Should().Be("FF");

            fac.Get(R14d).Match("r14d=FFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFF");

            fac.Get(R14w).Match("r14w=FFFF").Groups["val"].Value.Should().Be("FFFF");

            fac.Get(R15).Match("r15=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(R15b).Match("r15b=FF").Groups["val"].Value.Should().Be("FF");

            fac.Get(R15d).Match("r15d=FFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFF");

            fac.Get(R15w).Match("r15w=FFFF").Groups["val"].Value.Should().Be("FFFF");

            fac.Get(R8).Match("r8=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(R8b).Match("r8b=FF").Groups["val"].Value.Should().Be("FF");

            fac.Get(R8d).Match("r8d=FFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFF");

            fac.Get(R8w).Match("r8w=FFFF").Groups["val"].Value.Should().Be("FFFF");

            fac.Get(R9).Match("r9=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(R9b).Match("r9b=FF").Groups["val"].Value.Should().Be("FF");

            fac.Get(R9d).Match("r9d=FFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFF");

            fac.Get(R9w).Match("r9w=FFFF").Groups["val"].Value.Should().Be("FFFF");

            fac.Get(Rax).Match("rax=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Rbp).Match("rbp=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Rbx).Match("rbx=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Rcx).Match("rcx=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Rdi).Match("rdi=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Rdx).Match("rdx=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Rip).Match("rip=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Rsi).Match("rsi=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Rsp).Match("rsp=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Sf).Match("sf=1").Groups["val"].Value.Should().Be("1");

            fac.Get(Si).Match("si=105").Groups["val"].Value.Should().Be("105");

            fac.Get(Sil).Match("sil=5").Groups["val"].Value.Should().Be("5");

            fac.Get(Sp).Match("sp=d180").Groups["val"].Value.Should().Be("d180");

            fac.Get(Spl).Match("spl=80").Groups["val"].Value.Should().Be("80");

            fac.Get(Ss).Match("ss=002b").Groups["val"].Value.Should().Be("002b");

            Match m;
            m = fac.Get(St0)
                .Match(
                    "st0= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)");
            m.Groups["hi"].Value.Should().Be("0000");
            m.Groups["lo"].Value.Should().Be("0000000000000000");
            m = fac.Get(St1)
                .Match(
                    "st1= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)");
            m.Groups["hi"].Value.Should().Be("0000");
            m.Groups["lo"].Value.Should().Be("0000000000000000");
            m = fac.Get(St2)
                .Match(
                    "st2= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)");
            m.Groups["hi"].Value.Should().Be("0000");
            m.Groups["lo"].Value.Should().Be("0000000000000000");
            m = fac.Get(St3)
                .Match(
                    "st3= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)");
            m.Groups["hi"].Value.Should().Be("0000");
            m.Groups["lo"].Value.Should().Be("0000000000000000");
            m = fac.Get(St4)
                .Match(
                    "st4= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)");
            m.Groups["hi"].Value.Should().Be("0000");
            m.Groups["lo"].Value.Should().Be("0000000000000000");
            m = fac.Get(St5)
                .Match(
                    "st5= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)");
            m.Groups["hi"].Value.Should().Be("0000");
            m.Groups["lo"].Value.Should().Be("0000000000000000");
            m = fac.Get(St6)
                .Match(
                    "st6= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)");
            m.Groups["hi"].Value.Should().Be("0000");
            m.Groups["lo"].Value.Should().Be("0000000000000000");
            m = fac.Get(St7)
                .Match(
                    "st7= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)");
            m.Groups["hi"].Value.Should().Be("0000");
            m.Groups["lo"].Value.Should().Be("0000000000000000");

            fac.Get(Tf).Match("tf=1").Groups["val"].Value.Should().Be("1");

            fac.Get(Vif).Match("vif=1").Groups["val"].Value.Should().Be("1");

            fac.Get(Vip).Match("vip=1").Groups["val"].Value.Should().Be("1");

            fac.Get(Xmm0).Match("xmm0=           0            0            0            0").Groups["val"].Value.Should()
                .Be("           0            0            0            0");

            fac.Get(Xmm0h).Match("xmm0h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm0l).Match("xmm0l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm1).Match("xmm1=           0            0            0            0").Groups["val"].Value.Should()
                .Be("           0            0            0            0");

            fac.Get(Xmm10).Match("xmm10=           0            0            0            0").Groups["val"].Value.Should()
                .Be("           0            0            0            0");

            fac.Get(Xmm10h).Match("xmm10h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm10l).Match("xmm10l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm11).Match("xmm11=           0            0            0            0").Groups["val"].Value.Should()
                .Be("           0            0            0            0");

            fac.Get(Xmm11h).Match("xmm11h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm11l).Match("xmm11l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm12).Match("xmm12=           0            0            0            0").Groups["val"].Value.Should()
                .Be("           0            0            0            0");

            fac.Get(Xmm12h).Match("xmm12h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm12l).Match("xmm12l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm13).Match("xmm13=           0            0            0            0").Groups["val"].Value.Should()
                .Be("           0            0            0            0");

            fac.Get(Xmm13h).IsMatch("xmm13h=FFFFFFFFFFFFFFFF").Should().BeTrue();

            fac.Get(Xmm13l).IsMatch("xmm13l=FFFFFFFFFFFFFFFF").Should().BeTrue();

            fac.Get(Xmm14).Match("xmm14=           0            0            0            0").Groups["val"].Value.Should()
                .Be("           0            0            0            0");

            fac.Get(Xmm14h).Match("xmm14h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm14l).Match("xmm14l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm15).Match("xmm15=           0            0            0            0").Groups["val"].Value.Should()
                .Be("           0            0            0            0");

            fac.Get(Xmm15h).Match("xmm15h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm15l).Match("xmm15l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm1h).Match("xmm1h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm1l).Match("xmm1l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm2).Match("xmm2=           0            0            0            0").Groups["val"].Value.Should()
                .Be("           0            0            0            0");

            fac.Get(Xmm2h).Match("xmm2h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm2l).Match("xmm2l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm3).Match("xmm3=           0            0            0            0").Groups["val"].Value.Should()
                .Be("           0            0            0            0");

            fac.Get(Xmm3h).Match("xmm3h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm3l).Match("xmm3l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm4).Match("xmm4=           0            0            0            0").Groups["val"].Value.Should()
                .Be("           0            0            0            0");

            fac.Get(Xmm4h).Match("xmm4h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm4l).Match("xmm4l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm5).Match("xmm5=           0            0            0            0").Groups["val"].Value.Should()
                .Be("           0            0            0            0");

            fac.Get(Xmm5h).Match("xmm5h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm5l).Match("xmm5l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm6).Match("xmm6=           0            0            0            0").Groups["val"].Value.Should()
                .Be("           0            0            0            0");

            fac.Get(Xmm6h).Match("xmm6h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm6l).Match("xmm6l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm7).Match("xmm7=           0            0            0            0").Groups["val"].Value.Should()
                .Be("           0            0            0            0");

            fac.Get(Xmm7h).Match("xmm7h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm7l).Match("xmm7l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm8).Match("xmm8=           0            0            0            0").Groups["val"].Value.Should()
                .Be("           0            0            0            0");

            fac.Get(Xmm8h).Match("xmm8h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm8l).Match("xmm8l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm9).Match("xmm9=           0            0            0            0").Groups["val"].Value.Should()
                .Be("           0            0            0            0");

            fac.Get(Xmm9h).Match("xmm9h=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Xmm9l).Match("xmm9l=FFFFFFFFFFFFFFFF").Groups["val"].Value.Should().Be("FFFFFFFFFFFFFFFF");

            fac.Get(Ymm0)
                .Match(
                    "ymm0=           0            0            0            0            0            0            0            0")
                .Groups["val"].Value.Should().Be("           0            0            0            0            0            0            0            0");

            fac.Get(Ymm0h).IsMatch("ymm0h=           0            0            0            0").Should().BeTrue();

            fac.Get(Ymm0l).IsMatch("ymm0l=           0            0            0            0").Should().BeTrue();
            fac.Get(Ymm1)
                            .Match(
                                "ymm1=           0            0            0            0            0            0            0            0")
                            .Groups["val"].Value.Should().Be("           0            0            0            0            0            0            0            0");

            fac.Get(Ymm1h).IsMatch("ymm1h=           0            0            0            0").Should().BeTrue();

            fac.Get(Ymm1l).IsMatch("ymm1l=           0            0            0            0").Should().BeTrue();
            fac.Get(Ymm2)
                            .Match(
                                "ymm2=           0            0            0            0            0            0            0            0")
                            .Groups["val"].Value.Should().Be("           0            0            0            0            0            0            0            0");

            fac.Get(Ymm2h).IsMatch("ymm2h=           0            0            0            0").Should().BeTrue();

            fac.Get(Ymm2l).IsMatch("ymm2l=           0            0            0            0").Should().BeTrue();
            fac.Get(Ymm3)
                            .Match(
                                "ymm3=           0            0            0            0            0            0            0            0")
                            .Groups["val"].Value.Should().Be("           0            0            0            0            0            0            0            0");

            fac.Get(Ymm3h).IsMatch("ymm3h=           0            0            0            0").Should().BeTrue();

            fac.Get(Ymm3l).IsMatch("ymm3l=           0            0            0            0").Should().BeTrue();
            fac.Get(Ymm4)
                            .Match(
                                "ymm4=           0            0            0            0            0            0            0            0")
                            .Groups["val"].Value.Should().Be("           0            0            0            0            0            0            0            0");

            fac.Get(Ymm4h).IsMatch("ymm4h=           0            0            0            0").Should().BeTrue();

            fac.Get(Ymm4l).IsMatch("ymm4l=           0            0            0            0").Should().BeTrue();
            fac.Get(Ymm5)
                            .Match(
                                "ymm5=           0            0            0            0            0            0            0            0")
                            .Groups["val"].Value.Should().Be("           0            0            0            0            0            0            0            0");

            fac.Get(Ymm5h).IsMatch("ymm5h=           0            0            0            0").Should().BeTrue();

            fac.Get(Ymm5l).IsMatch("ymm5l=           0            0            0            0").Should().BeTrue();
            fac.Get(Ymm6)
                            .Match(
                                "ymm6=           0            0            0            0            0            0            0            0")
                            .Groups["val"].Value.Should().Be("           0            0            0            0            0            0            0            0");

            fac.Get(Ymm6h).IsMatch("ymm6h=           0            0            0            0").Should().BeTrue();

            fac.Get(Ymm6l).IsMatch("ymm6l=           0            0            0            0").Should().BeTrue();
            fac.Get(Ymm7)
                            .Match(
                                "ymm7=           0            0            0            0            0            0            0            0")
                            .Groups["val"].Value.Should().Be("           0            0            0            0            0            0            0            0");

            fac.Get(Ymm7h).IsMatch("ymm7h=           0            0            0            0").Should().BeTrue();

            fac.Get(Ymm7l).IsMatch("ymm7l=           0            0            0            0").Should().BeTrue();
            fac.Get(Ymm8)
                            .Match(
                                "ymm8=           0            0            0            0            0            0            0            0")
                            .Groups["val"].Value.Should().Be("           0            0            0            0            0            0            0            0");

            fac.Get(Ymm8h).IsMatch("ymm8h=           0            0            0            0").Should().BeTrue();

            fac.Get(Ymm8l).IsMatch("ymm8l=           0            0            0            0").Should().BeTrue();
            fac.Get(Ymm9)
                            .Match(
                                "ymm9=           0            0            0            0            0            0            0            0")
                            .Groups["val"].Value.Should().Be("           0            0            0            0            0            0            0            0");

            fac.Get(Ymm9h).IsMatch("ymm9h=           0            0            0            0").Should().BeTrue();

            fac.Get(Ymm9l).IsMatch("ymm9l=           0            0            0            0").Should().BeTrue();
            fac.Get(Ymm10)
                            .Match(
                                "ymm10=           0            0            0            0            0            0            0            0")
                            .Groups["val"].Value.Should().Be("           0            0            0            0            0            0            0            0");

            fac.Get(Ymm10h).IsMatch("ymm10h=           0            0            0            0").Should().BeTrue();

            fac.Get(Ymm10l).IsMatch("ymm10l=           0            0            0            0").Should().BeTrue();
            fac.Get(Ymm11)
                            .Match(
                                "ymm11=           0            0            0            0            0            0            0            0")
                            .Groups["val"].Value.Should().Be("           0            0            0            0            0            0            0            0");

            fac.Get(Ymm11h).IsMatch("ymm11h=           0            0            0            0").Should().BeTrue();

            fac.Get(Ymm11l).IsMatch("ymm11l=           0            0            0            0").Should().BeTrue();
            fac.Get(Ymm12)
                            .Match(
                                "ymm12=           0            0            0            0            0            0            0            0")
                            .Groups["val"].Value.Should().Be("           0            0            0            0            0            0            0            0");

            fac.Get(Ymm12h).IsMatch("ymm12h=           0            0            0            0").Should().BeTrue();

            fac.Get(Ymm12l).IsMatch("ymm12l=           0            0            0            0").Should().BeTrue();
            fac.Get(Ymm13)
                            .Match(
                                "ymm13=           0            0            0            0            0            0            0            0")
                            .Groups["val"].Value.Should().Be("           0            0            0            0            0            0            0            0");

            fac.Get(Ymm13h).IsMatch("ymm13h=           0            0            0            0").Should().BeTrue();

            fac.Get(Ymm13l).IsMatch("ymm13l=           0            0            0            0").Should().BeTrue();
            fac.Get(Ymm14)
                            .Match(
                                "ymm14=           0            0            0            0            0            0            0            0")
                            .Groups["val"].Value.Should().Be("           0            0            0            0            0            0            0            0");

            fac.Get(Ymm14h).IsMatch("ymm14h=           0            0            0            0").Should().BeTrue();

            fac.Get(Ymm14l).IsMatch("ymm14l=           0            0            0            0").Should().BeTrue();
            fac.Get(Ymm15)
                            .Match(
                                "ymm15=           0            0            0            0            0            0            0            0")
                            .Groups["val"].Value.Should().Be("           0            0            0            0            0            0            0            0");

            fac.Get(Ymm15h).IsMatch("ymm15h=           0            0            0            0").Should().BeTrue();

            fac.Get(Ymm15l).IsMatch("ymm15l=           0            0            0            0").Should().BeTrue();





            fac.Get(Zf).IsMatch("zf=1").Should().BeTrue();
            fac.Get(Zf).IsMatch("z=11").Should().BeFalse();
        }
    }
}