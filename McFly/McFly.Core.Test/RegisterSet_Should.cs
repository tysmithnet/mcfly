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
            r.Process("fopcode", "0x0123");
            r.Fopcode.Should().Be(0x123);

            r = new RegisterSet();
            r.Process("fpip", "0x0123");
            r.Fpip.Should().Be(0x123);

            r = new RegisterSet();
            r.Process("fpipsel", "0x0123");
            r.Fpipsel.Should().Be(0x123);

            r = new RegisterSet();
            r.Process("fpdp", "0x0123");
            r.Fpdp.Should().Be(0x123);

            r = new RegisterSet();
            r.Process("fpdpsel", "0x0123");
            r.Fpdpsel.Should().Be(0x123);

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
            r.Process("ymm0", "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567");
            r.Ymm0.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm0.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm0l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            r.Process("ymm1", "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567");
            r.Ymm1.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm1.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm1l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            r.Process("ymm2", "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567");
            r.Ymm2.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm2.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm2l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            r.Process("ymm3", "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567");
            r.Ymm3.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm3.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm3l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            r.Process("ymm4", "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567");
            r.Ymm4.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm4.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm4l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            r.Process("ymm5", "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567");
            r.Ymm5.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm5.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm5l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            r.Process("ymm6", "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567");
            r.Ymm6.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm6.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm6l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            r.Process("ymm7", "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567");
            r.Ymm7.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm7.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm7l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            r.Process("ymm8", "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567");
            r.Ymm8.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm8.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm8l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            r.Process("ymm9", "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567");
            r.Ymm9.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm9.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm9l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            r.Process("ymm10", "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567");
            r.Ymm10.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm10.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm10l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            r.Process("ymm11", "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567");
            r.Ymm11.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm11.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm11l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            r.Process("ymm12", "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567");
            r.Ymm12.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm12.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm12l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            r.Process("ymm13", "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567");
            r.Ymm13.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm13.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm13l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            r.Process("ymm14", "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567");
            r.Ymm14.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm14.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm14l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            r.Process("ymm15", "    deadbeef     feedcafe     11223344     55667788     aabbccdd     facefade     deafcafe     01234567");
            r.Ymm15.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa, 0x88, 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0xfe, 0xca, 0xed, 0xfe, 0xef, 0xbe, 0xad, 0xde);
            r.Xmm15.Should().Equal(0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde, 0xde, 0xfa, 0xce, 0xfa, 0xdd, 0xcc, 0xbb, 0xaa);
            r.Xmm15l.Should().Be(BitConverter.ToUInt64(new byte[] { 0x67, 0x45, 0x23, 0x01, 0xfe, 0xca, 0xaf, 0xde }, 0));

            r = new RegisterSet();
            r.Process("xmm0", "    12345678     deadbeef     abcdabcd     01020304");
            r.Xmm0.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm0.Should().Equal(r.Xmm0.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("xmm1", "    12345678     deadbeef     abcdabcd     01020304");
            r.Xmm1.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm1.Should().Equal(r.Xmm1.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("xmm2", "    12345678     deadbeef     abcdabcd     01020304");
            r.Xmm2.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm2.Should().Equal(r.Xmm2.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("xmm3", "    12345678     deadbeef     abcdabcd     01020304");
            r.Xmm3.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm3.Should().Equal(r.Xmm3.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("xmm4", "    12345678     deadbeef     abcdabcd     01020304");
            r.Xmm4.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm4.Should().Equal(r.Xmm4.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("xmm5", "    12345678     deadbeef     abcdabcd     01020304");
            r.Xmm5.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm5.Should().Equal(r.Xmm5.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("xmm6", "    12345678     deadbeef     abcdabcd     01020304");
            r.Xmm6.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm6.Should().Equal(r.Xmm6.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("xmm7", "    12345678     deadbeef     abcdabcd     01020304");
            r.Xmm7.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm7.Should().Equal(r.Xmm7.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("xmm8", "    12345678     deadbeef     abcdabcd     01020304");
            r.Xmm8.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm8.Should().Equal(r.Xmm8.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("xmm9", "    12345678     deadbeef     abcdabcd     01020304");
            r.Xmm9.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm9.Should().Equal(r.Xmm9.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("xmm10", "    12345678     deadbeef     abcdabcd     01020304");
            r.Xmm10.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm10.Should().Equal(r.Xmm10.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("xmm11", "    12345678     deadbeef     abcdabcd     01020304");
            r.Xmm11.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm11.Should().Equal(r.Xmm11.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("xmm12", "    12345678     deadbeef     abcdabcd     01020304");
            r.Xmm12.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm12.Should().Equal(r.Xmm12.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("xmm13", "    12345678     deadbeef     abcdabcd     01020304");
            r.Xmm13.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm13.Should().Equal(r.Xmm13.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("xmm14", "    12345678     deadbeef     abcdabcd     01020304");
            r.Xmm14.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm14.Should().Equal(r.Xmm14.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("xmm15", "    12345678     deadbeef     abcdabcd     01020304");
            r.Xmm15.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm15.Should().Equal(r.Xmm15.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("xmm0l", "deadbeeffacecafe");
            r.Xmm0l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm0.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm0.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            r.Process("xmm1l", "deadbeeffacecafe");
            r.Xmm1l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm1.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm1.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            r.Process("xmm2l", "deadbeeffacecafe");
            r.Xmm2l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm2.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm2.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            r.Process("xmm3l", "deadbeeffacecafe");
            r.Xmm3l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm3.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm3.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            r.Process("xmm4l", "deadbeeffacecafe");
            r.Xmm4l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm4.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm4.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            r.Process("xmm5l", "deadbeeffacecafe");
            r.Xmm5l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm5.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm5.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            r.Process("xmm6l", "deadbeeffacecafe");
            r.Xmm6l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm6.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm6.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            r.Process("xmm7l", "deadbeeffacecafe");
            r.Xmm7l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm7.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm7.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            r.Process("xmm8l", "deadbeeffacecafe");
            r.Xmm8l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm8.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm8.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            r.Process("xmm9l", "deadbeeffacecafe");
            r.Xmm9l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm9.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm9.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            r.Process("xmm10l", "deadbeeffacecafe");
            r.Xmm10l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm10.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm10.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            r.Process("xmm11l", "deadbeeffacecafe");
            r.Xmm11l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm11.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm11.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            r.Process("xmm12l", "deadbeeffacecafe");
            r.Xmm12l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm12.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm12.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            r.Process("xmm13l", "deadbeeffacecafe");
            r.Xmm13l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm13.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm13.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            r.Process("xmm14l", "deadbeeffacecafe");
            r.Xmm14l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm14.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm14.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            r.Process("xmm15l", "deadbeeffacecafe");
            r.Xmm15l.Should().Be(0xdeadbeeffacecafe);
            r.Ymm15.Should()
                .Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                    Enumerable.Repeat<byte>(0, 24)));
            r.Xmm15.Should().Equal(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }.Concat(
                Enumerable.Repeat<byte>(0, 8)));

            r = new RegisterSet();
            r.Process("xmm0h", "deadbeeffacecafe");
            r.Xmm0h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm0.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm0.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm0l.Should().Be(0);

            r = new RegisterSet();
            r.Process("xmm1h", "deadbeeffacecafe");
            r.Xmm1h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm1.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm1.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm1l.Should().Be(0);

            r = new RegisterSet();
            r.Process("xmm2h", "deadbeeffacecafe");
            r.Xmm2h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm2.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm2.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm2l.Should().Be(0);

            r = new RegisterSet();
            r.Process("xmm3h", "deadbeeffacecafe");
            r.Xmm3h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm3.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm3.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm3l.Should().Be(0);

            r = new RegisterSet();
            r.Process("xmm4h", "deadbeeffacecafe");
            r.Xmm4h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm4.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm4.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm4l.Should().Be(0);

            r = new RegisterSet();
            r.Process("xmm5h", "deadbeeffacecafe");
            r.Xmm5h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm5.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm5.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm5l.Should().Be(0);

            r = new RegisterSet();
            r.Process("xmm6h", "deadbeeffacecafe");
            r.Xmm6h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm6.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm6.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm6l.Should().Be(0);

            r = new RegisterSet();
            r.Process("xmm7h", "deadbeeffacecafe");
            r.Xmm7h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm7.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm7.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm7l.Should().Be(0);

            r = new RegisterSet();
            r.Process("xmm8h", "deadbeeffacecafe");
            r.Xmm8h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm8.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm8.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm8l.Should().Be(0);

            r = new RegisterSet();
            r.Process("xmm9h", "deadbeeffacecafe");
            r.Xmm9h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm9.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm9.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm9l.Should().Be(0);

            r = new RegisterSet();
            r.Process("xmm10h", "deadbeeffacecafe");
            r.Xmm10h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm10.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm10.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm10l.Should().Be(0);

            r = new RegisterSet();
            r.Process("xmm11h", "deadbeeffacecafe");
            r.Xmm11h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm11.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm11.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm11l.Should().Be(0);

            r = new RegisterSet();
            r.Process("xmm12h", "deadbeeffacecafe");
            r.Xmm12h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm12.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm12.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm12l.Should().Be(0);

            r = new RegisterSet();
            r.Process("xmm13h", "deadbeeffacecafe");
            r.Xmm13h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm13.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm13.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm13l.Should().Be(0);

            r = new RegisterSet();
            r.Process("xmm14h", "deadbeeffacecafe");
            r.Xmm14h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm14.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm14.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm14l.Should().Be(0);

            r = new RegisterSet();
            r.Process("xmm15h", "deadbeeffacecafe");
            r.Xmm15h.Should().Be(0xdeadbeeffacecafe);
            r.Ymm15.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde })
                .Concat(Enumerable.Repeat<byte>(0, 16)));
            r.Xmm15.Should().Equal(Enumerable.Repeat<byte>(0, 8)
                .Concat(new byte[] { 0xfe, 0xca, 0xce, 0xfa, 0xef, 0xbe, 0xad, 0xde }));
            r.Xmm15l.Should().Be(0);

            r = new RegisterSet();
            r.Process("ymm0h", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm0.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm0.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            r.Process("ymm1h", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm1.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm1.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            r.Process("ymm2h", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm2.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm2.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            r.Process("ymm3h", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm3.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm3.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            r.Process("ymm4h", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm4.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm4.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            r.Process("ymm5h", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm5.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm5.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            r.Process("ymm6h", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm6.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm6.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            r.Process("ymm7h", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm7.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm7.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            r.Process("ymm8h", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm8.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm8.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            r.Process("ymm9h", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm9.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm9.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            r.Process("ymm10h", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm10.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm10.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            r.Process("ymm11h", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm11.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm11.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            r.Process("ymm12h", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm12.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm12.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            r.Process("ymm13h", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm13.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm13.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            r.Process("ymm14h", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm14.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm14.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            r.Process("ymm15h", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm15.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12);
            r.Xmm15.Should().Equal(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

            r = new RegisterSet();
            r.Process("ymm0l", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm0l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm0.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm0.Should().Equal(r.Xmm0.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("ymm1l", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm1l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm1.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm1.Should().Equal(r.Xmm1.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("ymm2l", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm2l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm2.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm2.Should().Equal(r.Xmm2.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("ymm3l", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm3l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm3.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm3.Should().Equal(r.Xmm3.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("ymm4l", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm4l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm4.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm4.Should().Equal(r.Xmm4.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("ymm5l", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm5l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm5.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm5.Should().Equal(r.Xmm5.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("ymm6l", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm6l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm6.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm6.Should().Equal(r.Xmm6.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("ymm7l", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm7l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm7.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm7.Should().Equal(r.Xmm7.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("ymm8l", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm8l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm8.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm8.Should().Equal(r.Xmm8.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("ymm9l", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm9l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm9.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm9.Should().Equal(r.Xmm9.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("ymm10l", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm10l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm10.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm10.Should().Equal(r.Xmm10.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("ymm11l", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm11l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm11.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm11.Should().Equal(r.Xmm11.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("ymm12l", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm12l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm12.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm12.Should().Equal(r.Xmm12.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("ymm13l", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm13l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm13.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm13.Should().Equal(r.Xmm13.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("ymm14l", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm14l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm14.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm14.Should().Equal(r.Xmm14.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("ymm15l", "    12345678     deadbeef     abcdabcd     01020304");
            r.Ymm15l.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Xmm15.Should().Equal(new[] { 0x04, 0x03, 0x02, 0x01, 0xcd, 0xab, 0xcd, 0xab, 0xef, 0xbe, 0xad, 0xde, 0x78, 0x56, 0x34, 0x12 });
            r.Ymm15.Should().Equal(r.Xmm15.Concat(Enumerable.Repeat<byte>(0, 16)));

            r = new RegisterSet();
            r.Process("exfrom", "12345678deadbeef");
            r.Exfrom.Should().Be(0x12345678deadbeef);

            r = new RegisterSet();
            r.Process("exto", "12345678deadbeef");
            r.Exto.Should().Be(0x12345678deadbeef);

            r = new RegisterSet();
            r.Process("brfrom", "12345678deadbeef");
            r.Brfrom.Should().Be(0x12345678deadbeef);

            r = new RegisterSet();
            r.Process("brto", "12345678deadbeef");
            r.Brto.Should().Be(0x12345678deadbeef);

            r = new RegisterSet();
            r.Process("eax", "12345678");
            r.Eax.Should().Be(0x12345678);

            r = new RegisterSet();
            r.Process("ecx", "12345678");
            r.Ecx.Should().Be(0x12345678);

            r = new RegisterSet();
            r.Process("edx", "12345678");
            r.Edx.Should().Be(0x12345678);

            r = new RegisterSet();
            r.Process("ebx", "12345678");
            r.Ebx.Should().Be(0x12345678);

            r = new RegisterSet();
            r.Process("esp", "12345678");
            r.Esp.Should().Be(0x12345678);

            r = new RegisterSet();
            r.Process("ebp", "12345678");
            r.Ebp.Should().Be(0x12345678);

            r = new RegisterSet();
            r.Process("esi", "12345678");
            r.Esi.Should().Be(0x12345678);

            r = new RegisterSet();
            r.Process("edi", "12345678");
            r.Edi.Should().Be(0x12345678);

            r = new RegisterSet();
            r.Process("r8d", "12345678");
            r.R8d.Should().Be(0x12345678);

            r = new RegisterSet();
            r.Process("r9d", "12345678");
            r.R9d.Should().Be(0x12345678);

            r = new RegisterSet();
            r.Process("r10d", "12345678");
            r.R10d.Should().Be(0x12345678);

            r = new RegisterSet();
            r.Process("r11d", "12345678");
            r.R11d.Should().Be(0x12345678);

            r = new RegisterSet();
            r.Process("r12d", "12345678");
            r.R12d.Should().Be(0x12345678);

            r = new RegisterSet();
            r.Process("r13d", "12345678");
            r.R13d.Should().Be(0x12345678);

            r = new RegisterSet();
            r.Process("r14d", "12345678");
            r.R14d.Should().Be(0x12345678);

            r = new RegisterSet();
            r.Process("r15d", "12345678");
            r.R15d.Should().Be(0x12345678);

            r = new RegisterSet();
            r.Process("eip", "12345678");
            r.Eip.Should().Be(0x12345678);

            r = new RegisterSet();
            r.Process("ax", "1234");
            r.Ax.Should().Be(0x1234);

            r = new RegisterSet();
            r.Process("cx", "1234");
            r.Cx.Should().Be(0x1234);

            r = new RegisterSet();
            r.Process("dx", "1234");
            r.Dx.Should().Be(0x1234);

            r = new RegisterSet();
            r.Process("bx", "1234");
            r.Bx.Should().Be(0x1234);

            r = new RegisterSet();
            r.Process("sp", "1234");
            r.Sp.Should().Be(0x1234);

            r = new RegisterSet();
            r.Process("bp", "1234");
            r.Bp.Should().Be(0x1234);

            r = new RegisterSet();
            r.Process("si", "1234");
            r.Si.Should().Be(0x1234);

            r = new RegisterSet();
            r.Process("di", "1234");
            r.Di.Should().Be(0x1234);

            r = new RegisterSet();
            r.Process("r8w", "1234");
            r.R8w.Should().Be(0x1234);

            r = new RegisterSet();
            r.Process("r9w", "1234");
            r.R9w.Should().Be(0x1234);

            r = new RegisterSet();
            r.Process("r10w", "1234");
            r.R10w.Should().Be(0x1234);

            r = new RegisterSet();
            r.Process("r11w", "1234");
            r.R11w.Should().Be(0x1234);

            r = new RegisterSet();
            r.Process("r12w", "1234");
            r.R12w.Should().Be(0x1234);

            r = new RegisterSet();
            r.Process("r13w", "1234");
            r.R13w.Should().Be(0x1234);

            r = new RegisterSet();
            r.Process("r14w", "1234");
            r.R14w.Should().Be(0x1234);

            r = new RegisterSet();
            r.Process("r15w", "1234");
            r.R15w.Should().Be(0x1234);

            r = new RegisterSet();
            r.Process("ip", "1234");
            r.Ip.Should().Be(0x1234);

            r = new RegisterSet();
            r.Process("fl", "1234");
            r.Fl.Should().Be(0x1234);

            r = new RegisterSet();
            r.Process("al", "12");
            r.Al.Should().Be(0x12);

            r = new RegisterSet();
            r.Process("bl", "12");
            r.Bl.Should().Be(0x12);

            r = new RegisterSet();
            r.Process("cl", "12");
            r.Cl.Should().Be(0x12);

            r = new RegisterSet();
            r.Process("dl", "12");
            r.Dl.Should().Be(0x12);

            r = new RegisterSet();
            r.Process("spl", "12");
            r.Spl.Should().Be(0x12);

            r = new RegisterSet();
            r.Process("bpl", "12");
            r.Bpl.Should().Be(0x12);

            r = new RegisterSet();
            r.Process("sil", "12");
            r.Sil.Should().Be(0x12);

            r = new RegisterSet();
            r.Process("dil", "12");
            r.Dil.Should().Be(0x12);

            r = new RegisterSet();
            r.Process("r8b", "12");
            r.R8d.Should().Be(0x12);

            r = new RegisterSet();
            r.Process("r9b", "12");
            r.R9d.Should().Be(0x12);

            r = new RegisterSet();
            r.Process("r10b", "12");
            r.R10d.Should().Be(0x12);

            r = new RegisterSet();
            r.Process("r11b", "12");
            r.R11d.Should().Be(0x12);

            r = new RegisterSet();
            r.Process("r12b", "12");
            r.R12d.Should().Be(0x12);

            r = new RegisterSet();
            r.Process("r13b", "12");
            r.R13d.Should().Be(0x12);

            r = new RegisterSet();
            r.Process("r14b", "12");
            r.R14d.Should().Be(0x12);

            r = new RegisterSet();
            r.Process("r15b", "12");
            r.R15d.Should().Be(0x12);

            r = new RegisterSet();
            r.Process("ah", "12");
            r.Ah.Should().Be(0x12);

            r = new RegisterSet();
            r.Process("bh", "12");
            r.Bh.Should().Be(0x12);

            r = new RegisterSet();
            r.Process("ch", "12");
            r.Ch.Should().Be(0x12);

            r = new RegisterSet();
            r.Process("dh", "12");
            r.Dh.Should().Be(0x12);

            r = new RegisterSet();
            r.Process("iopl", "3");
            r.Iopl.Should().Be(0x3);

            r = new RegisterSet();
            r.Process("of", "1");
            r.Of.Should().BeTrue();

            r = new RegisterSet();
            r.Process("df", "1");
            r.Df.Should().BeTrue();

            r = new RegisterSet();
            r.Process("if", "1");
            r.If.Should().BeTrue();

            r = new RegisterSet();
            r.Process("tf", "1");
            r.Tf.Should().BeTrue();

            r = new RegisterSet();
            r.Process("sf", "1");
            r.Sf.Should().BeTrue();

            r = new RegisterSet();
            r.Process("zf", "1");
            r.Zf.Should().BeTrue();

            r = new RegisterSet();
            r.Process("af", "1");
            r.Af.Should().BeTrue();

            r = new RegisterSet();
            r.Process("pf", "1");
            r.Pf.Should().BeTrue();

            r = new RegisterSet();
            r.Process("cf", "1");
            r.Cf.Should().BeTrue();

            r = new RegisterSet();
            r.Process("vip", "1");
            r.Vip.Should().BeTrue();

            r = new RegisterSet();
            r.Process("vif", "1");
            r.Vif.Should().BeTrue();
        }

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