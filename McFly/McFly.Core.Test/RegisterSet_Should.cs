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
        }
    }
}