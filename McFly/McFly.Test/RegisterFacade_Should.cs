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
    }
}