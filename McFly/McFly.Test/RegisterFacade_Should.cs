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

            fac.Get(Af).IsMatch("af=0").Should().BeTrue();
            fac.Get(Af).IsMatch("a=0").Should().BeFalse();

            fac.Get(Ah).IsMatch("ah=7c").Should().BeTrue();
            fac.Get(Ah).IsMatch("a=7c").Should().BeFalse();

            fac.Get(Al).IsMatch("al=7c").Should().BeTrue();
            fac.Get(Al).IsMatch("a=7c").Should().BeFalse();

            fac.Get(Ax).IsMatch("ax=31808").Should().BeTrue();
            fac.Get(Ax).IsMatch("a=31808").Should().BeFalse();

            fac.Get(Bh).IsMatch("bh=ff").Should().BeTrue();
            fac.Get(Bh).IsMatch("b=ff").Should().BeFalse();

            fac.Get(Bl).IsMatch("bl=ff").Should().BeTrue();
            fac.Get(Bl).IsMatch("b=ff").Should().BeFalse();

            fac.Get(Bp).IsMatch("bp=fb28").Should().BeTrue();
            fac.Get(Bp).IsMatch("b=fb28").Should().BeFalse();

            fac.Get(Bpl).IsMatch("bpl=f0").Should().BeTrue();
            fac.Get(Bpl).IsMatch("b=f0").Should().BeFalse();

            fac.Get(Brfrom).IsMatch("brfrom=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Brfrom).IsMatch("b=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Brto).IsMatch("brto=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Brto).IsMatch("b=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Bx).IsMatch("bx=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Bx).IsMatch("b=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Cf).IsMatch("cf=0").Should().BeTrue();
            fac.Get(Cf).IsMatch("c=1").Should().BeFalse();

            fac.Get(Ch).IsMatch("ch=9b").Should().BeTrue();
            fac.Get(Ch).IsMatch("c=9b").Should().BeFalse();

            fac.Get(Cl).IsMatch("cl=a0").Should().BeTrue();
            fac.Get(Cl).IsMatch("c=a0").Should().BeFalse();

            fac.Get(Cs).IsMatch("cs=0033").Should().BeTrue();
            fac.Get(Cs).IsMatch("c=0033").Should().BeFalse();

            fac.Get(Cx).IsMatch("cx=9ba0").Should().BeTrue();
            fac.Get(Cx).IsMatch("c=9ba0").Should().BeFalse();

            fac.Get(Df).IsMatch("df=0").Should().BeTrue();
            fac.Get(Df).IsMatch("d=0").Should().BeFalse();

            fac.Get(Dh).IsMatch("dh=0").Should().BeTrue();
            fac.Get(Dh).IsMatch("d=0").Should().BeFalse();

            fac.Get(Di).IsMatch("di=8544").Should().BeTrue();
            fac.Get(Di).IsMatch("d=8544").Should().BeFalse();

            fac.Get(Dil).IsMatch("dil=0").Should().BeTrue();
            fac.Get(Dil).IsMatch("d=0").Should().BeFalse();

            fac.Get(Dl).IsMatch("dl=ce").Should().BeTrue();
            fac.Get(Dl).IsMatch("d=ce").Should().BeFalse();

            fac.Get(Dr0).IsMatch("dr0=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Dr0).IsMatch("d=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Dr1).IsMatch("dr1=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Dr1).IsMatch("d=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Dr2).IsMatch("dr2=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Dr2).IsMatch("d=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Dr3).IsMatch("dr3=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Dr3).IsMatch("d=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Dr6).IsMatch("dr6=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Dr6).IsMatch("d=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Dr7).IsMatch("dr7=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Dr7).IsMatch("d=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ds).IsMatch("ds=002b").Should().BeTrue();
            fac.Get(Ds).IsMatch("d=002b").Should().BeFalse();

            fac.Get(Dx).IsMatch("dx=f2ce").Should().BeTrue();
            fac.Get(Dx).IsMatch("d=f2ce").Should().BeFalse();

            fac.Get(Eax).IsMatch("eax=3205f31c").Should().BeTrue();
            fac.Get(Eax).IsMatch("ea=3205f31c").Should().BeFalse();

            fac.Get(Ebp).IsMatch("ebp=3205f31c").Should().BeTrue();
            fac.Get(Ebp).IsMatch("e=3205f31c").Should().BeFalse();

            fac.Get(Ebx).IsMatch("ebx=3205f31c").Should().BeTrue();
            fac.Get(Ebx).IsMatch("e=3205f31c").Should().BeFalse();

            fac.Get(Ecx).IsMatch("ecx=3205f31c").Should().BeTrue();
            fac.Get(Ecx).IsMatch("e=3205f31c").Should().BeFalse();

            fac.Get(Edi).IsMatch("edi=3205f31c").Should().BeTrue();
            fac.Get(Edi).IsMatch("e=3205f31c").Should().BeFalse();

            fac.Get(Edx).IsMatch("edx=3205f31c").Should().BeTrue();
            fac.Get(Edx).IsMatch("e=3205f31c").Should().BeFalse();

            fac.Get(Efl).IsMatch("efl=3205f31c").Should().BeTrue();
            fac.Get(Efl).IsMatch("e=3205f31c").Should().BeFalse();

            fac.Get(Eip).IsMatch("eip=3205f31c").Should().BeTrue();
            fac.Get(Eip).IsMatch("e=3205f31c").Should().BeFalse();

            fac.Get(Es).IsMatch("es=0033").Should().BeTrue();
            fac.Get(Es).IsMatch("e=0033").Should().BeFalse();

            fac.Get(Esi).IsMatch("esi=004ff300").Should().BeTrue();
            fac.Get(Esi).IsMatch("e=004ff300").Should().BeFalse();

            fac.Get(Esp).IsMatch("esp=004ff300").Should().BeTrue();
            fac.Get(Esp).IsMatch("e=004ff300").Should().BeFalse();

            fac.Get(Exfrom).IsMatch("exfrom=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Exfrom).IsMatch("e=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Exto).IsMatch("exto=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Exto).IsMatch("e=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Fl).IsMatch("fl=246").Should().BeTrue();
            fac.Get(Fl).IsMatch("f=246").Should().BeFalse();

            fac.Get(Fpcw).IsMatch("fpcw=027f").Should().BeTrue();
            fac.Get(Fpcw).IsMatch("f=027f").Should().BeFalse();

            fac.Get(Fpsw).IsMatch("fpsw=027f").Should().BeTrue();
            fac.Get(Fpsw).IsMatch("f=027f").Should().BeFalse();

            fac.Get(Fptw).IsMatch("fptw=027f").Should().BeTrue();
            fac.Get(Fptw).IsMatch("f=027f").Should().BeFalse();

            fac.Get(Fs).IsMatch("fs=0053").Should().BeTrue();
            fac.Get(Fs).IsMatch("f=0053").Should().BeFalse();

            fac.Get(Gs).IsMatch("gs=002b").Should().BeTrue();
            fac.Get(Gs).IsMatch("g=002b").Should().BeFalse();

            fac.Get(If).IsMatch("if=1").Should().BeTrue();
            fac.Get(If).IsMatch("i=1").Should().BeFalse();

            fac.Get(Iopl).IsMatch("iopl=3").Should().BeTrue();
            fac.Get(Iopl).IsMatch("i=3").Should().BeFalse();

            fac.Get(Ip).IsMatch("ip=5543").Should().BeTrue();
            fac.Get(Ip).IsMatch("i=5543").Should().BeFalse();

            fac.Get(Mm0).IsMatch("mm0=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Mm0).IsMatch("m=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Mm1).IsMatch("mm1=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Mm1).IsMatch("m=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Mm2).IsMatch("mm2=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Mm2).IsMatch("m=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Mm3).IsMatch("mm3=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Mm3).IsMatch("m=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Mm4).IsMatch("mm4=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Mm4).IsMatch("m=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Mm5).IsMatch("mm5=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Mm5).IsMatch("m=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Mm6).IsMatch("mm6=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Mm6).IsMatch("m=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Mm7).IsMatch("mm7=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Mm7).IsMatch("m=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Mxcsr).IsMatch("mxcsr=00001f80").Should().BeTrue();
            fac.Get(Mxcsr).IsMatch("m=00001f80").Should().BeFalse();

            fac.Get(Of).IsMatch("of=1").Should().BeTrue();
            fac.Get(Of).IsMatch("o=1").Should().BeFalse();

            fac.Get(Pf).IsMatch("pf=1").Should().BeTrue();
            fac.Get(Pf).IsMatch("p=1").Should().BeFalse();

            fac.Get(R10).IsMatch("r10=000000003205f2c0").Should().BeTrue();
            fac.Get(R10).IsMatch("r=000000003205f2c0").Should().BeFalse();

            fac.Get(R10b).IsMatch("r10b=c0").Should().BeTrue();
            fac.Get(R10b).IsMatch("r=c0").Should().BeFalse();

            fac.Get(R10d).IsMatch("r10d=3205f2c0").Should().BeTrue();
            fac.Get(R10d).IsMatch("r=000000003205f2c0").Should().BeFalse();

            fac.Get(R10w).IsMatch("r10w=f2c0").Should().BeTrue();
            fac.Get(R10w).IsMatch("r=000000003205f2c0").Should().BeFalse();

            fac.Get(R11).IsMatch("r11=000000003205f2c0").Should().BeTrue();
            fac.Get(R11).IsMatch("r=000000003205f2c0").Should().BeFalse();

            fac.Get(R11b).IsMatch("r11b=c0").Should().BeTrue();
            fac.Get(R11b).IsMatch("r=c0").Should().BeFalse();

            fac.Get(R11d).IsMatch("r11d=3205f2c0").Should().BeTrue();
            fac.Get(R11d).IsMatch("r=3205f2c0").Should().BeFalse();

            fac.Get(R11w).IsMatch("r11w=f2c0").Should().BeTrue();
            fac.Get(R11w).IsMatch("r=f2c0").Should().BeFalse();

            fac.Get(R12).IsMatch("r12=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(R12).IsMatch("r=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(R12b).IsMatch("r12b=FF").Should().BeTrue();
            fac.Get(R12b).IsMatch("r=FF").Should().BeFalse();

            fac.Get(R12d).IsMatch("r12d=FFFFFFFF").Should().BeTrue();
            fac.Get(R12d).IsMatch("r=FFFFFFFF").Should().BeFalse();

            fac.Get(R12w).IsMatch("r12w=FFFF").Should().BeTrue();
            fac.Get(R12w).IsMatch("r=FFFF").Should().BeFalse();

            fac.Get(R13).IsMatch("r13=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(R13).IsMatch("r=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(R13b).IsMatch("r13b=FF").Should().BeTrue();
            fac.Get(R13b).IsMatch("r=FF").Should().BeFalse();

            fac.Get(R13d).IsMatch("r13d=FFFFFFFF").Should().BeTrue();
            fac.Get(R13d).IsMatch("r=FFFFFFFF").Should().BeFalse();

            fac.Get(R13w).IsMatch("r13w=FFFF").Should().BeTrue();
            fac.Get(R13w).IsMatch("r=FFFF").Should().BeFalse();

            fac.Get(R14).IsMatch("r14=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(R14).IsMatch("r=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(R14b).IsMatch("r14b=FF").Should().BeTrue();
            fac.Get(R14b).IsMatch("r=FF").Should().BeFalse();

            fac.Get(R14d).IsMatch("r14d=FFFFFFFF").Should().BeTrue();
            fac.Get(R14d).IsMatch("r=FFFFFFFF").Should().BeFalse();

            fac.Get(R14w).IsMatch("r14w=FFFF").Should().BeTrue();
            fac.Get(R14w).IsMatch("r=FFFF").Should().BeFalse();

            fac.Get(R15).IsMatch("r15=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(R15).IsMatch("r=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(R15b).IsMatch("r15b=FF").Should().BeTrue();
            fac.Get(R15b).IsMatch("r=FF").Should().BeFalse();

            fac.Get(R15d).IsMatch("r15d=FFFFFFFF").Should().BeTrue();
            fac.Get(R15d).IsMatch("r=FFFFFFFF").Should().BeFalse();

            fac.Get(R15w).IsMatch("r15w=FFFF").Should().BeTrue();
            fac.Get(R15w).IsMatch("r=FFFF").Should().BeFalse();

            fac.Get(R8).IsMatch("r8=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(R8).IsMatch("r=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(R8b).IsMatch("r8b=FF").Should().BeTrue();
            fac.Get(R8b).IsMatch("r=FF").Should().BeFalse();

            fac.Get(R8d).IsMatch("r8d=FFFFFFFF").Should().BeTrue();
            fac.Get(R8d).IsMatch("r=FFFFFFFF").Should().BeFalse();

            fac.Get(R8w).IsMatch("r8w=FFFF").Should().BeTrue();
            fac.Get(R8w).IsMatch("r=FFFF").Should().BeFalse();

            fac.Get(R9).IsMatch("r9=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(R9).IsMatch("r=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(R9b).IsMatch("r9b=FF").Should().BeTrue();
            fac.Get(R9b).IsMatch("r=FF").Should().BeFalse();

            fac.Get(R9d).IsMatch("r9d=FFFFFFFF").Should().BeTrue();
            fac.Get(R9d).IsMatch("r=FFFFFFFF").Should().BeFalse();

            fac.Get(R9w).IsMatch("r9w=FFFF").Should().BeTrue();
            fac.Get(R9w).IsMatch("r=FFFF").Should().BeFalse();

            fac.Get(Rax).IsMatch("rax=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Rax).IsMatch("r=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Rbp).IsMatch("rbp=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Rbp).IsMatch("r=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Rbx).IsMatch("rbx=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Rbx).IsMatch("r=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Rcx).IsMatch("rcx=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Rcx).IsMatch("r=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Rdi).IsMatch("rdi=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Rdi).IsMatch("r=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Rdx).IsMatch("rdx=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Rdx).IsMatch("r=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Rip).IsMatch("rip=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Rip).IsMatch("r=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Rsi).IsMatch("rsi=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Rsi).IsMatch("r=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Rsp).IsMatch("rsp=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Rsp).IsMatch("r=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Sf).IsMatch("sf=1").Should().BeTrue();
            fac.Get(Sf).IsMatch("s=1").Should().BeFalse();

            fac.Get(Si).IsMatch("si=105").Should().BeTrue();
            fac.Get(Si).IsMatch("s=105").Should().BeFalse();

            fac.Get(Sil).IsMatch("sil=5").Should().BeTrue();
            fac.Get(Sil).IsMatch("s=5").Should().BeFalse();

            fac.Get(Sp).IsMatch("sp=d180").Should().BeTrue();
            fac.Get(Sp).IsMatch("s=d180").Should().BeFalse();

            fac.Get(Spl).IsMatch("spl=80").Should().BeTrue();
            fac.Get(Spl).IsMatch("s=80").Should().BeFalse();

            fac.Get(Ss).IsMatch("ss=002b").Should().BeTrue();
            fac.Get(Ss).IsMatch("s=002b").Should().BeFalse();

            fac.Get(St0)
                .IsMatch(
                    "st0= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)")
                .Should().BeTrue();
            fac.Get(St0)
                .IsMatch(
                    "st1= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)")
                .Should().BeFalse();

            fac.Get(St1)
                .IsMatch(
                    "st1= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)")
                .Should().BeTrue();
            fac.Get(St1)
                .IsMatch(
                    "st2= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)")
                .Should().BeFalse();

            fac.Get(St2)
                .IsMatch(
                    "st2= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)")
                .Should().BeTrue();
            fac.Get(St2)
                .IsMatch(
                    "st3= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)")
                .Should().BeFalse();

            fac.Get(St3)
                .IsMatch(
                    "st3= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)")
                .Should().BeTrue();
            fac.Get(St3)
                .IsMatch(
                    "st4= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)")
                .Should().BeFalse();

            fac.Get(St4)
                .IsMatch(
                    "st4= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)")
                .Should().BeTrue();
            fac.Get(St4)
                .IsMatch(
                    "st5= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)")
                .Should().BeFalse();

            fac.Get(St5)
                .IsMatch(
                    "st5= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)")
                .Should().BeTrue();
            fac.Get(St5)
                .IsMatch(
                    "st6= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)")
                .Should().BeFalse();

            fac.Get(St6)
                .IsMatch(
                    "st6= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)")
                .Should().BeTrue();
            fac.Get(St6)
                .IsMatch(
                    "st7= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)")
                .Should().BeFalse();

            fac.Get(St7)
                .IsMatch(
                    "st7= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)")
                .Should().BeTrue();
            fac.Get(St7)
                .IsMatch(
                    "st8= 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000e+0000 (0:0000:0000000000000000)")
                .Should().BeFalse();

            fac.Get(Tf).IsMatch("tf=1").Should().BeTrue();
            fac.Get(Tf).IsMatch("t=1").Should().BeFalse();

            fac.Get(Vif).IsMatch("vif=1").Should().BeTrue();
            fac.Get(Vif).IsMatch("v=1").Should().BeFalse();

            fac.Get(Vip).IsMatch("vip=1").Should().BeTrue();
            fac.Get(Vip).IsMatch("v=1").Should().BeFalse();

            fac.Get(Xmm0).IsMatch("xmm0=           0            0            0            0").Should().BeTrue();
            fac.Get(Xmm0).IsMatch("xmm0=           0            0            0            0").Should().BeFalse();

            fac.Get(Xmm0h).IsMatch("xmm0h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm0h).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm0l).IsMatch("xmm0l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm0l).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm1).IsMatch("xmm0=           0            0            0            0").Should().BeTrue();
            fac.Get(Xmm1).IsMatch("xmm0=           0            0            0            0").Should().BeFalse();

            fac.Get(Xmm10).IsMatch("xmm0=           0            0            0            0").Should().BeTrue();
            fac.Get(Xmm10).IsMatch("xmm0=           0            0            0            0").Should().BeFalse();

            fac.Get(Xmm10h).IsMatch("xmm10h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm10h).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm10l).IsMatch("xmm10l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm10l).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm11).IsMatch("xmm0=           0            0            0            0").Should().BeTrue();
            fac.Get(Xmm11).IsMatch("xmm0=           0            0            0            0").Should().BeFalse();

            fac.Get(Xmm11h).IsMatch("xmm11h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm11h).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm11l).IsMatch("xmm11l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm11l).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm12).IsMatch("xmm0=           0            0            0            0").Should().BeTrue();
            fac.Get(Xmm12).IsMatch("xmm0=           0            0            0            0").Should().BeFalse();

            fac.Get(Xmm12h).IsMatch("xmm12h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm12h).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm12l).IsMatch("xmm12l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm12l).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm13).IsMatch("xmm0=           0            0            0            0").Should().BeTrue();
            fac.Get(Xmm13).IsMatch("xmm0=           0            0            0            0").Should().BeFalse();

            fac.Get(Xmm13h).IsMatch("xmm13h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm13h).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm13l).IsMatch("xmm13l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm13l).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm14).IsMatch("xmm0=           0            0            0            0").Should().BeTrue();
            fac.Get(Xmm14).IsMatch("xmm0=           0            0            0            0").Should().BeFalse();

            fac.Get(Xmm14h).IsMatch("xmm14h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm14h).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm14l).IsMatch("xmm14l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm14l).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm15).IsMatch("xmm0=           0            0            0            0").Should().BeTrue();
            fac.Get(Xmm15).IsMatch("xmm0=           0            0            0            0").Should().BeFalse();

            fac.Get(Xmm15h).IsMatch("xmm15h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm15h).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm15l).IsMatch("xmm15l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm15l).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm1h).IsMatch("xmm1h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm1h).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm1l).IsMatch("xmm1l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm1l).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm2).IsMatch("xmm0=           0            0            0            0").Should().BeTrue();
            fac.Get(Xmm2).IsMatch("xmm0=           0            0            0            0").Should().BeFalse();

            fac.Get(Xmm2h).IsMatch("xmm2h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm2h).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm2l).IsMatch("xmm2l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm2l).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm3).IsMatch("xmm0=           0            0            0            0").Should().BeTrue();
            fac.Get(Xmm3).IsMatch("xmm0=           0            0            0            0").Should().BeFalse();

            fac.Get(Xmm3h).IsMatch("xmm3h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm3h).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm3l).IsMatch("xmm3l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm3l).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm4).IsMatch("xmm0=           0            0            0            0").Should().BeTrue();
            fac.Get(Xmm4).IsMatch("xmm0=           0            0            0            0").Should().BeFalse();

            fac.Get(Xmm4h).IsMatch("xmm4h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm4h).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm4l).IsMatch("xmm4l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm4l).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm5).IsMatch("xmm0=           0            0            0            0").Should().BeTrue();
            fac.Get(Xmm5).IsMatch("xmm0=           0            0            0            0").Should().BeFalse();

            fac.Get(Xmm5h).IsMatch("xmm5h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm5h).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm5l).IsMatch("xmm5l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm5l).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm6).IsMatch("xmm0=           0            0            0            0").Should().BeTrue();
            fac.Get(Xmm6).IsMatch("xmm0=           0            0            0            0").Should().BeFalse();

            fac.Get(Xmm6h).IsMatch("xmm6h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm6h).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm6l).IsMatch("xmm6l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm6l).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm7).IsMatch("xmm0=           0            0            0            0").Should().BeTrue();
            fac.Get(Xmm7).IsMatch("xmm0=           0            0            0            0").Should().BeFalse();

            fac.Get(Xmm7h).IsMatch("xmm7h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm7h).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm7l).IsMatch("xmm7l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm7l).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm8).IsMatch("xmm0=           0            0            0            0").Should().BeTrue();
            fac.Get(Xmm8).IsMatch("xmm0=           0            0            0            0").Should().BeFalse();

            fac.Get(Xmm8h).IsMatch("xmm8h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm8h).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm8l).IsMatch("xmm8l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm8l).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm9).IsMatch("xmm0=           0            0            0            0").Should().BeTrue();
            fac.Get(Xmm9).IsMatch("xmm0=           0            0            0            0").Should().BeFalse();

            fac.Get(Xmm9h).IsMatch("xmm9h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm9h).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Xmm9l).IsMatch("xmm9l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Xmm9l).IsMatch("x=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm0)
                .IsMatch(
                    "ymm0=           0            0            0            0            0            0            0            0")
                .Should().BeTrue();
            fac.Get(Ymm0)
                .IsMatch(
                    "ymm0=           0            0            0            0            0            0            0            0")
                .Should().BeFalse();

            fac.Get(Ymm0h).IsMatch("ymm0h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm0h).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm0l).IsMatch("ymm0l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm0l).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm1).IsMatch("ymm1=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm1).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm10)
                .IsMatch(
                    "ymm0=           0            0            0            0            0            0            0            0")
                .Should().BeTrue();
            fac.Get(Ymm10)
                .IsMatch(
                    "ymm10=           0            0            0            0            0            0            0            0")
                .Should().BeFalse();

            fac.Get(Ymm10h).IsMatch("ymm10h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm10h).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm10l).IsMatch("ymm10l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm10l).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm11)
                .IsMatch(
                    "ymm11=           0            0            0            0            0            0            0            0")
                .Should().BeTrue();
            fac.Get(Ymm11)
                .IsMatch(
                    "ym11=           0            0            0            0            0            0            0            0")
                .Should().BeFalse();

            fac.Get(Ymm11h).IsMatch("ymm11h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm11h).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm11l).IsMatch("ymm11l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm11l).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm12)
                .IsMatch(
                    "ymm12=           0            0            0            0            0            0            0            0")
                .Should().BeTrue();
            fac.Get(Ymm12)
                .IsMatch(
                    "ymm12=           0            0            0            0            0            0            ")
                .Should().BeFalse();

            fac.Get(Ymm12h).IsMatch("ymm12h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm12h).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm12l).IsMatch("ymm12l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm12l).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm13)
                .IsMatch(
                    "ymm13=           0            0            0            0            0            0            0            0")
                .Should().BeTrue();
            fac.Get(Ymm13).IsMatch("ymm13=           0            0            0            0            ").Should()
                .BeFalse();

            fac.Get(Ymm13h).IsMatch("ymm13h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm13h).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm13l).IsMatch("ymm13l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm13l).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm14)
                .IsMatch(
                    "ymm14=           0            0            0            0            0            0            0            0")
                .Should().BeTrue();
            fac.Get(Ymm14)
                .IsMatch("ymm14= 0            0            0            0            0            0            0")
                .Should().BeFalse();

            fac.Get(Ymm14h).IsMatch("ymm14h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm14h).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm14l).IsMatch("ymm14l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm14l).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm15)
                .IsMatch(
                    "ymm15=           0            0            0            0            0            0            0            0")
                .Should().BeTrue();
            fac.Get(Ymm15)
                .IsMatch(
                    "ymm155=           0            0            0            0            0            0            0            0")
                .Should().BeFalse();

            fac.Get(Ymm15h).IsMatch("ymm15h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm15h).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm15l).IsMatch("ymm15l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm15l).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm1h).IsMatch("ymm1h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm1h).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm1l).IsMatch("ymm1l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm1l).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm2)
                .IsMatch(
                    "ymm2=           0            0            0            0            0            0            0            0")
                .Should().BeTrue();
            fac.Get(Ymm2)
                .IsMatch(
                    "ymm2           0            0            0            0            0            0            0            0")
                .Should().BeFalse();

            fac.Get(Ymm2h).IsMatch("ymm2h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm2h).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm2l).IsMatch("ymm2l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm2l).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm3)
                .IsMatch(
                    "ymm3=           0            0            0            0            0            0            0            0")
                .Should().BeTrue();
            fac.Get(Ymm3)
                .IsMatch(
                    "ym3=           0            0            0            0            0            0            0            0")
                .Should().BeFalse();

            fac.Get(Ymm3h).IsMatch("ymm3h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm3h).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm3l).IsMatch("ymm3l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm3l).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm4)
                .IsMatch(
                    "ymm4=           0            0            0            0            0            0            0            0")
                .Should().BeTrue();
            fac.Get(Ymm4)
                .IsMatch(
                    "ymm4=0            0            0            0            0            0            0            0")
                .Should().BeFalse();

            fac.Get(Ymm4h).IsMatch("ymm4h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm4h).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm4l).IsMatch("ymm4l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm4l).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm5)
                .IsMatch(
                    "ymm5=           0            0            0            0            0            0            0            0")
                .Should().BeTrue();
            fac.Get(Ymm5)
                .IsMatch(
                    "ym5=           0            0            0            0            0            0            0            0")
                .Should().BeFalse();

            fac.Get(Ymm5h).IsMatch("ymm5h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm5h).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm5l).IsMatch("ymm5l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm5l).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm6)
                .IsMatch(
                    "ymm6=           0            0            0            0            0            0            0            0")
                .Should().BeTrue();
            fac.Get(Ymm6)
                .IsMatch(
                    "ymm6=             0            0            0            0            0            0            0")
                .Should().BeFalse();

            fac.Get(Ymm6h).IsMatch("ymm6h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm6h).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm6l).IsMatch("ymm6l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm6l).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm7)
                .IsMatch(
                    "ymm7=           0            0            0            0            0            0            0            0")
                .Should().BeTrue();
            fac.Get(Ymm7)
                .IsMatch(
                    "ym7=           0            0            0            0            0            0            0            0")
                .Should().BeFalse();

            fac.Get(Ymm7h).IsMatch("ymm7h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm7h).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm7l).IsMatch("ymm7l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm7l).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm8)
                .IsMatch(
                    "ymm8=           0            0            0            0            0            0            0            0")
                .Should().BeTrue();
            fac.Get(Ymm8)
                .IsMatch(
                    "ym8=           0            0            0            0            0            0            0            0")
                .Should().BeFalse();

            fac.Get(Ymm8h).IsMatch("ymm8h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm8h).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm8l).IsMatch("ymm8l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm8l).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm9)
                .IsMatch(
                    "ymm9=           0            0            0            0            0            0            0            0")
                .Should().BeTrue();
            fac.Get(Ymm9)
                .IsMatch(
                    "ymm9==           0            0            0            0            0            0            0            0")
                .Should().BeFalse();

            fac.Get(Ymm9h).IsMatch("ymm9h=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm9h).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Ymm9l).IsMatch("ymm9l=FFFFFFFFFFFFFFFF").Should().BeTrue();
            fac.Get(Ymm9l).IsMatch("y=FFFFFFFFFFFFFFFF").Should().BeFalse();

            fac.Get(Zf).IsMatch("zf=1").Should().BeTrue();
            fac.Get(Zf).IsMatch("z=11").Should().BeFalse();
        }
    }
}