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
            var registerSet = facade.GetCurrentRegisterSet(new Register[] {Eax, Ebx, Ecx, Edx, Esi, Edi, Esp, Ebp, Eip, Efl, Cs, Ds, Es, Fs, Gs, Ss, Dr0, Dr1, Dr2, Dr3, Dr6, Dr7, Di, Si, Bx, Dx, Cx, Ax, Bp, Ip, Fl, Sp, Bl, Dl, Cl, Al, Bh, Dh, Ch, Ah, Iopl, Of, Df, If, Tf, Sf, Zf, Af, Pf, Cf, Vip, Vif, Mxcsr, Xmm0, Xmm1, Xmm2, Xmm3, Xmm4, Xmm5, Xmm6, Xmm7, Mm0, Mm1, Mm2, Mm3, Mm4, Mm5, Mm6, Mm7, Ymm0, Ymm1, Ymm2, Ymm3, Ymm4, Ymm5, Ymm6, Ymm7, Xmm0l, Xmm1l, Xmm2l, Xmm3l, Xmm4l, Xmm5l, Xmm6l, Xmm7l, Xmm0h, Xmm1h, Xmm2h, Xmm3h, Xmm4h, Xmm5h, Xmm6h, Xmm7h, Fpcw, Fpsw, Fptw, Fopcode, Fpip, Fpipsel, Fpdp, Fpdpsel, St0, St1, St2, St3, St4, St5, St6, St7
            });
            registerSet.Eax.Should().Be(0x12f77c40);
            registerSet.Ebx.Should().Be(0x001e0000);
            registerSet.Ecx.Should().Be(0x77c58e7e);
        }
    }
}