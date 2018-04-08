// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tsmithnet
// Created          : 02-28-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 04-07-2018
// ***********************************************************************
// <copyright file="RegisterSet.cs" company="McFly.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace McFly.Core.Registers
{
    /// <summary>
    ///     Represents the collection of all register values at a particular instance in time for a specific thread
    /// </summary>
    public class RegisterSet
    {
        private byte[] _st0;
        private byte[] _st1;
        private byte[] _st2;
        private byte[] _st3;
        private byte[] _st4;
        private byte[] _st5;
        private byte[] _st6;
        private byte[] _st7;
        private byte[] _xmm0;
        private byte[] _xmm1;
        private byte[] _xmm10;
        private byte[] _xmm11;
        private byte[] _xmm12;
        private byte[] _xmm13;
        private byte[] _xmm14;
        private byte[] _xmm15;
        private byte[] _xmm2;
        private byte[] _xmm3;
        private byte[] _xmm4;
        private byte[] _xmm5;
        private byte[] _xmm6;
        private byte[] _xmm7;
        private byte[] _xmm8;
        private byte[] _xmm9;
        private byte[] _ymm0;
        private byte[] _ymm1;
        private byte[] _ymm10;
        private byte[] _ymm11;
        private byte[] _ymm12;
        private byte[] _ymm13;
        private byte[] _ymm14;
        private byte[] _ymm15;
        private byte[] _ymm2;
        private byte[] _ymm3;
        private byte[] _ymm4;
        private byte[] _ymm5;
        private byte[] _ymm6;
        private byte[] _ymm7;
        private byte[] _ymm8;
        private byte[] _ymm9;

        /// <summary>
        ///     Interprets the arguments as changes to the register set
        ///     e.g. Process("rax", "16", 10) will set the value of the rax register to 16
        /// </summary>
        /// <param name="register">The register.</param>
        /// <param name="input">The input.</param>
        /// <param name="radix">The radix.</param>
        /// <exception cref="ArgumentNullException">
        ///     register
        ///     or
        ///     input
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">register</exception>
        /// <exception cref="System.ArgumentNullException">
        ///     register
        ///     or
        ///     input
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">register</exception>
        public void Process(string register, string input, int radix = 16)
        {
            register = register ?? throw new ArgumentNullException(nameof(register));
            input = input ?? throw new ArgumentNullException(nameof(input));

            var first = Register.AllRegisters.FirstOrDefault(x =>
                x.Name.Equals(register, StringComparison.OrdinalIgnoreCase));
            if (first == null) return;
            switch (first.Name.ToLower())
            {
                case "rax":
                    Rax = Convert.ToUInt64(input, radix);
                    break;
                case "rbx":
                    Rbx = Convert.ToUInt64(input, radix);
                    break;
                case "rcx":
                    Rcx = Convert.ToUInt64(input, radix);
                    break;
                case "rdx":
                    Rdx = Convert.ToUInt64(input, radix);
                    break;
                case "rsp":
                    Rsp = Convert.ToUInt64(input, radix);
                    break;
                case "rbp":
                    Rbp = Convert.ToUInt64(input, radix);
                    break;
                case "rsi":
                    Rsi = Convert.ToUInt64(input, radix);
                    break;
                case "rdi":
                    Rdi = Convert.ToUInt64(input, radix);
                    break;
                case "r8":
                    R8 = Convert.ToUInt64(input, radix);
                    break;
                case "r9":
                    R9 = Convert.ToUInt64(input, radix);
                    break;
                case "r10":
                    R10 = Convert.ToUInt64(input, radix);
                    break;
                case "r11":
                    R11 = Convert.ToUInt64(input, radix);
                    break;
                case "r12":
                    R12 = Convert.ToUInt64(input, radix);
                    break;
                case "r13":
                    R13 = Convert.ToUInt64(input, radix);
                    break;
                case "r14":
                    R14 = Convert.ToUInt64(input, radix);
                    break;
                case "r15":
                    R15 = Convert.ToUInt64(input, radix);
                    break;
                case "rip":
                    Rip = Convert.ToUInt64(input, radix);
                    break;
                case "efl":
                    Efl = Convert.ToUInt32(input, radix);
                    break;
                case "cs":
                    Cs = Convert.ToUInt16(input, radix);
                    break;
                case "ds":
                    Ds = Convert.ToUInt16(input, radix);
                    break;
                case "es":
                    Es = Convert.ToUInt16(input, radix);
                    break;
                case "fs":
                    Fs = Convert.ToUInt16(input, radix);
                    break;
                case "gs":
                    Gs = Convert.ToUInt16(input, radix);
                    break;
                case "ss":
                    Ss = Convert.ToUInt16(input, radix);
                    break;
                case "dr0":
                    Dr0 = Convert.ToUInt64(input, radix);
                    break;
                case "dr1":
                    Dr1 = Convert.ToUInt64(input, radix);
                    break;
                case "dr2":
                    Dr2 = Convert.ToUInt64(input, radix);
                    break;
                case "dr3":
                    Dr3 = Convert.ToUInt64(input, radix);
                    break;
                case "dr6":
                    Dr6 = Convert.ToUInt64(input, radix);
                    break;
                case "dr7":
                    Dr7 = Convert.ToUInt64(input, radix);
                    break;
                case "fpcw":
                    Fpcw = Convert.ToUInt16(input, radix);
                    break;
                case "fpsw":
                    Fpsw = Convert.ToUInt16(input, radix);
                    break;
                case "fptw":
                    Fptw = Convert.ToUInt16(input, radix);
                    break;
                case "st0":
                {
                    var regex = new Regex(@"[a-f0-9]+:(?<hi>[a-f0-9]+):(?<lo>[a-f0-9]+)", RegexOptions.IgnoreCase);
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var high = match.Groups["hi"].Value;
                    var low = match.Groups["lo"].Value;
                    var builder = new ByteArrayBuilder();
                    var bytes = builder.AppdendHexString(high).AppdendHexString(low).Reverse().Build();
                    St0 = bytes;
                    break;
                }
                case "st1":
                {
                    var regex = new Regex(@"[a-f0-9]+:(?<hi>[a-f0-9]+):(?<lo>[a-f0-9]+)", RegexOptions.IgnoreCase);
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var high = match.Groups["hi"].Value;
                    var low = match.Groups["lo"].Value;
                    var builder = new ByteArrayBuilder();
                    var bytes = builder.AppdendHexString(high).AppdendHexString(low).Reverse().Build();
                    St1 = bytes;
                    break;
                }
                case "st2":
                {
                    var regex = new Regex(@"[a-f0-9]+:(?<hi>[a-f0-9]+):(?<lo>[a-f0-9]+)", RegexOptions.IgnoreCase);
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var high = match.Groups["hi"].Value;
                    var low = match.Groups["lo"].Value;
                    var builder = new ByteArrayBuilder();
                    var bytes = builder.AppdendHexString(high).AppdendHexString(low).Reverse().Build();
                    St2 = bytes;
                    break;
                }
                case "st3":
                {
                    var regex = new Regex(@"[a-f0-9]+:(?<hi>[a-f0-9]+):(?<lo>[a-f0-9]+)", RegexOptions.IgnoreCase);
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var high = match.Groups["hi"].Value;
                    var low = match.Groups["lo"].Value;
                    var builder = new ByteArrayBuilder();
                    var bytes = builder.AppdendHexString(high).AppdendHexString(low).Reverse().Build();
                    St3 = bytes;
                    break;
                }
                case "st4":
                {
                    var regex = new Regex(@"[a-f0-9]+:(?<hi>[a-f0-9]+):(?<lo>[a-f0-9]+)", RegexOptions.IgnoreCase);
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var high = match.Groups["hi"].Value;
                    var low = match.Groups["lo"].Value;
                    var builder = new ByteArrayBuilder();
                    var bytes = builder.AppdendHexString(high).AppdendHexString(low).Reverse().Build();
                    St4 = bytes;
                    break;
                }
                case "st5":
                {
                    var regex = new Regex(@"[a-f0-9]+:(?<hi>[a-f0-9]+):(?<lo>[a-f0-9]+)", RegexOptions.IgnoreCase);
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var high = match.Groups["hi"].Value;
                    var low = match.Groups["lo"].Value;
                    var builder = new ByteArrayBuilder();
                    var bytes = builder.AppdendHexString(high).AppdendHexString(low).Reverse().Build();
                    St5 = bytes;
                    break;
                }
                case "st6":
                {
                    var regex = new Regex(@"[a-f0-9]+:(?<hi>[a-f0-9]+):(?<lo>[a-f0-9]+)", RegexOptions.IgnoreCase);
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var high = match.Groups["hi"].Value;
                    var low = match.Groups["lo"].Value;
                    var builder = new ByteArrayBuilder();
                    var bytes = builder.AppdendHexString(high).AppdendHexString(low).Reverse().Build();
                    St6 = bytes;
                    break;
                }
                case "st7":
                {
                    var regex = new Regex(@"[a-f0-9]+:(?<hi>[a-f0-9]+):(?<lo>[a-f0-9]+)", RegexOptions.IgnoreCase);
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var high = match.Groups["hi"].Value;
                    var low = match.Groups["lo"].Value;
                    var builder = new ByteArrayBuilder();
                    var bytes = builder.AppdendHexString(high).AppdendHexString(low).Reverse().Build();
                    St7 = bytes;
                    break;
                }
                case "mm0":
                    Mm0 = Convert.ToUInt64(input, radix);
                    break;
                case "mm1":
                    Mm1 = Convert.ToUInt64(input, radix);
                    break;
                case "mm2":
                    Mm2 = Convert.ToUInt64(input, radix);
                    break;
                case "mm3":
                    Mm3 = Convert.ToUInt64(input, radix);
                    break;
                case "mm4":
                    Mm4 = Convert.ToUInt64(input, radix);
                    break;
                case "mm5":
                    Mm5 = Convert.ToUInt64(input, radix);
                    break;
                case "mm6":
                    Mm6 = Convert.ToUInt64(input, radix);
                    break;
                case "mm7":
                    Mm7 = Convert.ToUInt64(input, radix);
                    break;
                case "mxcsr":
                    Mxcsr = Convert.ToUInt32(input, radix);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(register)} has a value of {register} which is not a valid register");
            }
        }

        public bool? Af
        {
            get => Efl.HasValue ? (bool?) ((Efl & 0x0010) > 0) : null;
            set
            {
                if (!value.HasValue) return;
                uint mask = 0x0010;
                if (value.Value)
                    Efl = Efl |= mask;
                else
                    Efl = Efl &= ~mask;
            }
        }

        public byte? Ah
        {
            get => Ax?.Hi8();
            set
            {
                if (!value.HasValue) return;
                Ax = Ax?.Hi8(value.Value);
            }
        }

        public byte? Al
        {
            get => Ax?.Lo8();
            set
            {
                if (!value.HasValue) return;
                Ax = Ax?.Lo8(value.Value);
            }
        }

        public ushort? Ax
        {
            get => Eax?.Lo16();
            set
            {
                if (!value.HasValue) return;
                Eax = Eax?.Lo16(value.Value);
            }
        }

        public byte? Bh
        {
            get => Bx?.Hi8();
            set
            {
                if (!value.HasValue) return;
                Bx = Bx?.Hi8(value.Value);
            }
        }

        public byte? Bl
        {
            get => Bx?.Lo8();
            set
            {
                if (!value.HasValue) return;
                Bx = Bx?.Lo8(value.Value);
            }
        }

        public ushort? Bp
        {
            get => Ebp?.Lo16();
            set
            {
                if (!value.HasValue) return;
                Ebp = Ebp?.Lo16(value.Value);
            }
        }

        public byte? Bpl
        {
            get => Bp?.Lo8();
            set
            {
                if (!value.HasValue) return;
                Bp = Bp?.Lo8(value.Value);
            }
        }

        public ulong? Brfrom { get; set; }
        public ulong? Brto { get; set; }

        public ushort? Bx
        {
            get => Ebx?.Lo16();
            set
            {
                if (!value.HasValue) return;
                Ebx = Ebx?.Lo16(value.Value);
            }
        }

        public bool? Cf
        {
            get => Efl.HasValue ? (bool?) ((Efl & 0x0001) > 0) : null;
            set
            {
                if (!value.HasValue) return;
                uint mask = 0x0001;
                if (value.Value)
                    Efl = Efl |= mask;
                else
                    Efl = Efl &= ~mask;
            }
        }

        public byte? Ch
        {
            get => Cx?.Hi8();
            set
            {
                if (!value.HasValue) return;
                Cx = Cx?.Hi8(value.Value);
            }
        }

        public byte? Cl
        {
            get => Cx?.Lo8();
            set
            {
                if (!value.HasValue) return;
                Cx = Cx?.Lo8(value.Value);
            }
        }

        public ushort? Cs { get; set; }

        public ushort? Cx
        {
            get => Ecx?.Lo16();
            set
            {
                if (!value.HasValue) return;
                Ecx = Ecx?.Lo16(value.Value);
            }
        }

        public bool? Df
        {
            get => Efl.HasValue ? (bool?) ((Efl & 0x0400) > 0) : null;
            set
            {
                if (!value.HasValue) return;
                uint mask = 0x0400;
                if (value.Value)
                    Efl = Efl |= mask;
                else
                    Efl = Efl &= ~mask;
            }
        }

        public byte? Dh
        {
            get => Dx?.Hi8();
            set
            {
                if (!value.HasValue) return;
                Dx = Dx?.Hi8(value.Value);
            }
        }

        public ushort? Di
        {
            get => Edi?.Lo16();
            set
            {
                if (!value.HasValue) return;
                Edi = Eax?.Lo16(value.Value);
            }
        }

        public byte? Dil
        {
            get => Di?.Lo8();
            set
            {
                if (!value.HasValue) return;
                Di = Di?.Lo8(value.Value);
            }
        }

        public byte? Dl
        {
            get => Dx?.Lo8();
            set
            {
                if (!value.HasValue) return;
                Dx = Dx?.Lo8(value.Value);
            }
        }

        public ulong? Dr0 { get; set; }
        public ulong? Dr1 { get; set; }
        public ulong? Dr2 { get; set; }
        public ulong? Dr3 { get; set; }
        public ulong? Dr6 { get; set; }
        public ulong? Dr7 { get; set; }
        public ushort? Ds { get; set; }

        public ushort? Dx
        {
            get => Edx?.Lo16();
            set
            {
                if (!value.HasValue) return;
                Edx = Edx?.Lo16(value.Value);
            }
        }

        public uint? Eax
        {
            get => Rax?.Lo32();
            set
            {
                if (!value.HasValue) return;
                Rax = Rax?.Lo32(value.Value);
            }
        }

        public uint? Ebp
        {
            get => Rbp?.Lo32();
            set
            {
                if (!value.HasValue) return;
                Rbp = Rbp?.Lo32(value.Value);
            }
        }

        public uint? Ebx
        {
            get => Rbx?.Lo32();
            set
            {
                if (!value.HasValue) return;
                Rbx = Rbx?.Lo32(value.Value);
            }
        }

        public uint? Ecx
        {
            get => Rcx?.Lo32();
            set
            {
                if (!value.HasValue) return;
                Rcx = Rcx?.Lo32(value.Value);
            }
        }

        public uint? Edi
        {
            get => Rdi?.Lo32();
            set
            {
                if (!value.HasValue) return;
                Rdi = Rdi?.Lo32(value.Value);
            }
        }

        public uint? Edx
        {
            get => Rdx?.Lo32();
            set
            {
                if (!value.HasValue) return;
                Rdx = Rdx?.Lo32(value.Value);
            }
        }

        public uint? Efl { get; set; }

        public uint? Eip
        {
            get => Rip?.Lo32();
            set
            {
                if (!value.HasValue) return;
                Rip = Rip?.Lo32(value.Value);
            }
        }

        public ushort? Es { get; set; }

        public uint? Esi
        {
            get => Rsi?.Lo32();
            set
            {
                if (!value.HasValue) return;
                Rsi = Rsi?.Lo32(value.Value);
            }
        }

        public uint? Esp
        {
            get => Rsp?.Lo32();
            set
            {
                if (!value.HasValue) return;
                Rsp = Rsp?.Lo32(value.Value);
            }
        }

        public ulong? Exfrom { get; set; }
        public ulong? Exto { get; set; }

        public ushort? Fl
        {
            get => Efl?.Lo16();
            set
            {
                if (!value.HasValue) return;
                Efl = Efl?.Lo16(value.Value);
            }
        }

        public ushort? Fpcw { get; set; }
        public ushort? Fpsw { get; set; }
        public ushort? Fptw { get; set; }
        public ushort? Fs { get; set; }
        public ushort? Gs { get; set; }

        public bool? If
        {
            get => Efl.HasValue ? (bool?) ((Efl & 0x0200) > 0) : null;
            set
            {
                if (!value.HasValue) return;
                uint mask = 0x0200;
                if (value.Value)
                    Efl = Efl |= mask;
                else
                    Efl = Efl &= ~mask;
            }
        }

        public byte? Iopl
        {
            get => Efl.HasValue ? (byte?) (Efl & (0x3000 >> 11)) : null;
            set
            {
                if (!value.HasValue) return;
                if (value > 3)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has a value of {value} but must be in [0,4)");
                uint mask = 0x3000;
                Efl = Efl &= ~mask | ((uint) value << 11);
            }
        }

        public ushort? Ip
        {
            get => Eip?.Lo16();
            set
            {
                if (!value.HasValue) return;
                Eip = Eip?.Lo16(value.Value);
            }
        }

        public ulong? Mm0 { get; set; }
        public ulong? Mm1 { get; set; }
        public ulong? Mm2 { get; set; }
        public ulong? Mm3 { get; set; }
        public ulong? Mm4 { get; set; }
        public ulong? Mm5 { get; set; }
        public ulong? Mm6 { get; set; }
        public ulong? Mm7 { get; set; }
        public uint? Mxcsr { get; set; }

        public bool? Of
        {
            get => Efl.HasValue ? (bool?) ((Efl & 0x0800) > 0) : null;
            set
            {
                if (!value.HasValue) return;
                uint mask = 0x0800;
                if (value.Value)
                    Efl = Efl |= mask;
                else
                    Efl = Efl &= ~mask;
            }
        }

        public bool? Pf
        {
            get => Efl.HasValue ? (bool?) ((Efl & 0x0004) > 0) : null;
            set
            {
                if (!value.HasValue) return;
                uint mask = 0x0004;
                if (value.Value)
                    Efl = Efl |= mask;
                else
                    Efl = Efl &= ~mask;
            }
        }

        public ulong? R10 { get; set; }

        public byte? R10b
        {
            get => R10w?.Lo8();
            set
            {
                if (!value.HasValue) return;
                R10w = R10w?.Lo8(value.Value);
            }
        }

        public uint? R10d
        {
            get => R10?.Lo32();
            set
            {
                if (!value.HasValue) return;
                R10 = R10?.Lo32(value.Value);
            }
        }

        public ushort? R10w
        {
            get => R10d?.Lo16();
            set
            {
                if (!value.HasValue) return;
                R10d = R10d?.Lo16(value.Value);
            }
        }

        public ulong? R11 { get; set; }

        public byte? R11b
        {
            get => R11w?.Lo8();
            set
            {
                if (!value.HasValue) return;
                R11w = R11w?.Lo8(value.Value);
            }
        }

        public uint? R11d
        {
            get => R11?.Lo32();
            set
            {
                if (!value.HasValue) return;
                R11 = R11?.Lo32(value.Value);
            }
        }

        public ushort? R11w
        {
            get => R11d?.Lo16();
            set
            {
                if (!value.HasValue) return;
                R11d = R11d?.Lo16(value.Value);
            }
        }

        public ulong? R12 { get; set; }

        public byte? R12b
        {
            get => R12w?.Lo8();
            set
            {
                if (!value.HasValue) return;
                R12w = R12w?.Lo8(value.Value);
            }
        }

        public uint? R12d
        {
            get => R12?.Lo32();
            set
            {
                if (!value.HasValue) return;
                R12 = R12?.Lo32(value.Value);
            }
        }

        public ushort? R12w
        {
            get => R12d?.Lo16();
            set
            {
                if (!value.HasValue) return;
                R12d = R12d?.Lo16(value.Value);
            }
        }

        public ulong? R13 { get; set; }

        public byte? R13b
        {
            get => R13w?.Lo8();
            set
            {
                if (!value.HasValue) return;
                R13w = R13w?.Lo8(value.Value);
            }
        }

        public uint? R13d
        {
            get => R13?.Lo32();
            set
            {
                if (!value.HasValue) return;
                R13 = R13?.Lo32(value.Value);
            }
        }

        public ushort? R13w
        {
            get => R13d?.Lo16();
            set
            {
                if (!value.HasValue) return;
                R13d = R13d?.Lo16(value.Value);
            }
        }

        public ulong? R14 { get; set; }

        public byte? R14b
        {
            get => R14w?.Lo8();
            set
            {
                if (!value.HasValue) return;
                R14w = R14w?.Lo8(value.Value);
            }
        }

        public uint? R14d
        {
            get => R14?.Lo32();
            set
            {
                if (!value.HasValue) return;
                R14 = R14?.Lo32(value.Value);
            }
        }

        public ushort? R14w
        {
            get => R14d?.Lo16();
            set
            {
                if (!value.HasValue) return;
                R14d = R14d?.Lo16(value.Value);
            }
        }

        public ulong? R15 { get; set; }

        public byte? R15b
        {
            get => R15w?.Lo8();
            set
            {
                if (!value.HasValue) return;
                R15w = R15w?.Lo8(value.Value);
            }
        }

        public uint? R15d
        {
            get => R15?.Lo32();
            set
            {
                if (!value.HasValue) return;
                R15 = R15?.Lo32(value.Value);
            }
        }

        public ushort? R15w
        {
            get => R15d?.Lo16();
            set
            {
                if (!value.HasValue) return;
                R15d = R15d?.Lo16(value.Value);
            }
        }

        public ulong? R8 { get; set; }

        public byte? R8b
        {
            get => R8w?.Lo8();
            set
            {
                if (!value.HasValue) return;
                R8w = R8w?.Lo8(value.Value);
            }
        }

        public uint? R8d
        {
            get => R8?.Lo32();
            set
            {
                if (!value.HasValue) return;
                R8 = R8?.Lo32(value.Value);
            }
        }

        public ushort? R8w
        {
            get => R8d?.Lo16();
            set
            {
                if (!value.HasValue) return;
                R8d = R8d?.Lo16(value.Value);
            }
        }

        public ulong? R9 { get; set; }

        public byte? R9b
        {
            get => R9w?.Lo8();
            set
            {
                if (!value.HasValue) return;
                R9w = R9w?.Lo8(value.Value);
            }
        }

        public uint? R9d
        {
            get => R9?.Lo32();
            set
            {
                if (!value.HasValue) return;
                R9 = R9?.Lo32(value.Value);
            }
        }

        public ushort? R9w
        {
            get => R9d?.Lo16();
            set
            {
                if (!value.HasValue) return;
                R9d = R9d?.Lo16(value.Value);
            }
        }

        public ulong? Rax { get; set; }
        public ulong? Rbp { get; set; }
        public ulong? Rbx { get; set; }
        public ulong? Rcx { get; set; }
        public ulong? Rdi { get; set; }
        public ulong? Rdx { get; set; }
        public ulong? Rip { get; set; }
        public ulong? Rsi { get; set; }
        public ulong? Rsp { get; set; }

        public bool? Sf
        {
            get => Efl.HasValue ? (bool?) ((Efl & 0x0080) > 0) : null;
            set
            {
                if (!value.HasValue) return;
                uint mask = 0x0080;
                if (value.Value)
                    Efl = Efl |= mask;
                else
                    Efl = Efl &= ~mask;
            }
        }

        public ushort? Si
        {
            get => Esi?.Lo16();
            set
            {
                if (!value.HasValue) return;
                Esi = Esi?.Lo16(value.Value);
            }
        }

        public byte? Sil
        {
            get => Si?.Lo8();
            set
            {
                if (!value.HasValue) return;
                Si = Si?.Lo8(value.Value);
            }
        }

        public ushort? Sp
        {
            get => Esp?.Lo16();
            set
            {
                if (!value.HasValue) return;
                Esp = Esp?.Lo16(value.Value);
            }
        }

        public byte? Spl
        {
            get => Sp?.Lo8();
            set
            {
                if (!value.HasValue) return;
                Sp = Sp?.Lo8(value.Value);
            }
        }

        public ushort? Ss { get; set; }

        public byte[] St0
        {
            get => _st0;
            set
            {
                if (value != null && value.Length != 10)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 10");
                _st0 = value;
            }
        }

        public byte[] St1
        {
            get => _st1;
            set
            {
                if (value != null && value.Length != 10)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 10");
                _st1 = value;
            }
        }

        public byte[] St2
        {
            get => _st2;
            set
            {
                if (value != null && value.Length != 10)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 10");
                _st2 = value;
            }
        }

        public byte[] St3
        {
            get => _st3;
            set
            {
                if (value != null && value.Length != 10)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 10");
                _st3 = value;
            }
        }

        public byte[] St4
        {
            get => _st4;
            set
            {
                if (value != null && value.Length != 10)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 10");
                _st4 = value;
            }
        }

        public byte[] St5
        {
            get => _st5;
            set
            {
                if (value != null && value.Length != 10)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 10");
                _st5 = value;
            }
        }

        public byte[] St6
        {
            get => _st6;
            set
            {
                if (value != null && value.Length != 10)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 10");
                _st6 = value;
            }
        }

        public byte[] St7
        {
            get => _st7;
            set
            {
                if (value != null && value.Length != 10)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 10");
                _st7 = value;
            }
        }

        public bool? Tf
        {
            get => Efl.HasValue ? (bool?) ((Efl & 0x0100) > 0) : null;
            set
            {
                if (!value.HasValue) return;
                uint mask = 0x0100;
                if (value.Value)
                    Efl = Efl |= mask;
                else
                    Efl = Efl &= ~mask;
            }
        }

        public bool? Vif
        {
            get => Efl.HasValue ? (bool?) ((Efl & 0x00080000) > 0) : null;
            set
            {
                if (!value.HasValue) return;
                uint mask = 0x00080000;
                if (value.Value)
                    Efl = Efl |= mask;
                else
                    Efl = Efl &= ~mask;
            }
        }

        public bool? Vip
        {
            get => Efl.HasValue ? (bool?) ((Efl & 0x00100000) > 0) : null;
            set
            {
                if (!value.HasValue) return;
                uint mask = 0x00100000;
                if (value.Value)
                    Efl = Efl |= mask;
                else
                    Efl = Efl &= ~mask;
            }
        }

        public byte[] Xmm0
        {
            get => _xmm0;
            set
            {
                if (value != null && value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                _xmm0 = value;
            }
        }

        public ulong? Xmm0l { get; set; }

        public byte[] Xmm1
        {
            get => _xmm1;
            set
            {
                if (value != null && value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                _xmm1 = value;
            }
        }

        public byte[] Xmm10
        {
            get => _xmm10;
            set
            {
                if (value != null && value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                _xmm10 = value;
            }
        }

        public ulong? Xmm10l { get; set; }

        public byte[] Xmm11
        {
            get => _xmm11;
            set
            {
                if (value != null && value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                _xmm11 = value;
            }
        }

        public ulong? Xmm11l { get; set; }

        public byte[] Xmm12
        {
            get => _xmm12;
            set
            {
                if (value != null && value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                _xmm12 = value;
            }
        }

        public ulong? Xmm12l { get; set; }

        public byte[] Xmm13
        {
            get => _xmm13;
            set
            {
                if (value != null && value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                _xmm13 = value;
            }
        }

        public ulong? Xmm13l { get; set; }

        public byte[] Xmm14
        {
            get => _xmm14;
            set
            {
                if (value != null && value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                _xmm14 = value;
            }
        }

        public ulong? Xmm14l { get; set; }

        public byte[] Xmm15
        {
            get => _xmm15;
            set
            {
                if (value != null && value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                _xmm15 = value;
            }
        }

        public ulong? Xmm15l { get; set; }
        public ulong? Xmm1l { get; set; }

        public byte[] Xmm2
        {
            get => _xmm2;
            set
            {
                if (value != null && value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                _xmm2 = value;
            }
        }

        public ulong? Xmm2l { get; set; }

        public byte[] Xmm3
        {
            get => _xmm3;
            set
            {
                if (value != null && value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                _xmm3 = value;
            }
        }

        public ulong? Xmm3l { get; set; }

        public byte[] Xmm4
        {
            get => _xmm4;
            set
            {
                if (value != null && value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                _xmm4 = value;
            }
        }

        public ulong? Xmm4l { get; set; }

        public byte[] Xmm5
        {
            get => _xmm5;
            set
            {
                if (value != null && value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                _xmm5 = value;
            }
        }

        public ulong? Xmm5l { get; set; }

        public byte[] Xmm6
        {
            get => _xmm6;
            set
            {
                if (value != null && value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                _xmm6 = value;
            }
        }

        public ulong? Xmm6l { get; set; }

        public byte[] Xmm7
        {
            get => _xmm7;
            set
            {
                if (value != null && value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                _xmm7 = value;
            }
        }

        public ulong? Xmm7l { get; set; }

        public byte[] Xmm8
        {
            get => _xmm8;
            set
            {
                if (value != null && value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                _xmm8 = value;
            }
        }

        public ulong? Xmm8l { get; set; }

        public byte[] Xmm9
        {
            get => _xmm9;
            set
            {
                if (value != null && value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                _xmm9 = value;
            }
        }

        public ulong? Xmm9l { get; set; }

        public byte[] Ymm0
        {
            get => _ymm0;
            set
            {
                if (value != null && value.Length != 32)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 32");
                _ymm0 = value;
            }
        }

        public ulong? Ymm0l { get; set; }

        public byte[] Ymm1
        {
            get => _ymm1;
            set
            {
                if (value != null && value.Length != 32)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 32");
                _ymm1 = value;
            }
        }

        public byte[] Ymm10
        {
            get => _ymm10;
            set
            {
                if (value != null && value.Length != 32)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 32");
                _ymm10 = value;
            }
        }

        public ulong? Ymm10l { get; set; }

        public byte[] Ymm11
        {
            get => _ymm11;
            set
            {
                if (value != null && value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                _ymm11 = value;
            }
        }

        public ulong? Ymm11l { get; set; }

        public byte[] Ymm12
        {
            get => _ymm12;
            set
            {
                if (value != null && value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                _ymm12 = value;
            }
        }

        public ulong? Ymm12l { get; set; }

        public byte[] Ymm13
        {
            get => _ymm13;
            set
            {
                if (value != null && value.Length != 32)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 32");
                _ymm13 = value;
            }
        }

        public ulong? Ymm13l { get; set; }

        public byte[] Ymm14
        {
            get => _ymm14;
            set
            {
                if (value != null && value.Length != 32)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 32");
                _ymm14 = value;
            }
        }

        public ulong? Ymm14l { get; set; }

        public byte[] Ymm15
        {
            get => _ymm15;
            set
            {
                if (value != null && value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                _ymm15 = value;
            }
        }

        public ulong? Ymm15l { get; set; }
        public ulong? Ymm1l { get; set; }

        public byte[] Ymm2
        {
            get => _ymm2;
            set
            {
                if (value != null && value.Length != 32)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 32");
                _ymm2 = value;
            }
        }

        public ulong? Ymm2l { get; set; }

        public byte[] Ymm3
        {
            get => _ymm3;
            set
            {
                if (value != null && value.Length != 32)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 32");
                _ymm3 = value;
            }
        }

        public ulong? Ymm3l { get; set; }

        public byte[] Ymm4
        {
            get => _ymm4;
            set
            {
                if (value != null && value.Length != 32)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 32");
                _ymm4 = value;
            }
        }

        public ulong? Ymm4l { get; set; }

        public byte[] Ymm5
        {
            get => _ymm5;
            set
            {
                if (value != null && value.Length != 32)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 32");
                _ymm5 = value;
            }
        }

        public ulong? Ymm5l { get; set; }

        public byte[] Ymm6
        {
            get => _ymm6;
            set
            {
                if (value != null && value.Length != 32)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 32");
                _ymm6 = value;
            }
        }

        public ulong? Ymm6l { get; set; }

        public byte[] Ymm7
        {
            get => _ymm7;
            set
            {
                if (value != null && value.Length != 32)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 32");
                _ymm7 = value;
            }
        }

        public ulong? Ymm7l { get; set; }

        public byte[] Ymm8
        {
            get => _ymm8;
            set
            {
                if (value != null && value.Length != 32)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 32");
                _ymm8 = value;
            }
        }

        public ulong? Ymm8l { get; set; }

        public byte[] Ymm9
        {
            get => _ymm9;
            set
            {
                if (value != null && value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                _ymm9 = value;
            }
        }

        public ulong? Ymm9l { get; set; }

        public bool? Zf
        {
            get => Efl.HasValue ? (bool?) ((Efl & 0x0040) > 0) : null;
            set
            {
                if (!value.HasValue) return;
                uint mask = 0x0040;
                if (value.Value)
                    Efl = Efl |= mask;
                else
                    Efl = Efl &= ~mask;
            }
        }
    }
}

/*
64 bit
0:rax
1:rcx
2:rdx
3:rbx
4:rsp
5:rbp
6:rsi
7:rdi
8:r8
9:r9
10:r10
11:r11
12:r12
13:r13
14:r14
15:r15
16:rip
17:efl
18:cs
19:ds
20:es
21:fs
22:gs
23:ss
24:dr0
25:dr1
26:dr2
27:dr3
28:dr6
29:dr7
30:fpcw
31:fpsw
32:fptw
33:st0
34:st1
35:st2
36:st3
37:st4
38:st5
39:st6
40:st7
41:mm0
42:mm1
43:mm2
44:mm3
45:mm4
46:mm5
47:mm6
48:mm7
49:mxcsr
50:xmm0
51:xmm1
52:xmm2
53:xmm3
54:xmm4
55:xmm5
56:xmm6
57:xmm7
58:xmm8
59:xmm9
60:xmm10
61:xmm11
62:xmm12
63:xmm13
64:xmm14
65:xmm15
130:xmm0l
131:xmm1l
132:xmm2l
133:xmm3l
134:xmm4l
135:xmm5l
136:xmm6l
137:xmm7l
138:xmm8l
139:xmm9l
140:xmm10l
141:xmm11l
142:xmm12l
143:xmm13l
144:xmm14l
145:xmm15l
146:xmm0h
147:xmm1h
148:xmm2h
149:xmm3h
150:xmm4h
151:xmm5h
152:xmm6h
153:xmm7h
154:xmm8h
155:xmm9h
156:xmm10h
157:xmm11h
158:xmm12h
159:xmm13h
160:xmm14h
161:xmm15h
162:ymm0
163:ymm1
164:ymm2
165:ymm3
166:ymm4
167:ymm5
168:ymm6
169:ymm7
170:ymm8
171:ymm9
172:ymm10
173:ymm11
174:ymm12
175:ymm13
176:ymm14
177:ymm15
242:ymm0l
243:ymm1l
244:ymm2l
245:ymm3l
246:ymm4l
247:ymm5l
248:ymm6l
249:ymm7l
250:ymm8l
251:ymm9l
252:ymm10l
253:ymm11l
254:ymm12l
255:ymm13l
256:ymm14l
257:ymm15l
258:ymm0h
259:ymm1h
260:ymm2h
261:ymm3h
262:ymm4h
263:ymm5h
264:ymm6h
265:ymm7h
266:ymm8h
267:ymm9h
268:ymm10h
269:ymm11h
270:ymm12h
271:ymm13h
272:ymm14h
273:ymm15h
274:exfrom
275:exto
276:brfrom
277:brto
278:eax
279:ecx
280:edx
281:ebx
282:esp
283:ebp
284:esi
285:edi
286:r8d
287:r9d
288:r10d
289:r11d
290:r12d
291:r13d
292:r14d
293:r15d
294:eip
295:ax
296:cx
297:dx
298:bx
299:sp
300:bp
301:si
302:di
303:r8w
304:r9w
305:r10w
306:r11w
307:r12w
308:r13w
309:r14w
310:r15w
311:ip
312:fl
313:al
314:cl
315:dl
316:bl
317:spl
318:bpl
319:sil
320:dil
321:r8b
322:r9b
323:r10b
324:r11b
325:r12b
326:r13b
327:r14b
328:r15b
329:ah
330:ch
331:dh
332:bh
333:iopl
334:of
335:df
336:if
337:tf
338:sf
339:zf
340:af
341:pf
342:cf
343:vip
344:vif
*/