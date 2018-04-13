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
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace McFly.Core.Registers
{
    /// <summary>
    ///     Represents the collection of all register values at a particular instance in time for a specific thread
    /// </summary>
    public class RegisterSet : IEquatable<RegisterSet>
    {
        private byte[] _st0;
        private byte[] _st1;
        private byte[] _st2;
        private byte[] _st3;
        private byte[] _st4;
        private byte[] _st5;
        private byte[] _st6;
        private byte[] _st7;
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

        /// <inheritdoc />
        public bool Equals(RegisterSet other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Brfrom == other.Brfrom &&
                   Brto == other.Brto &&
                   Cs == other.Cs &&
                   Dr0 == other.Dr0 &&
                   Dr1 == other.Dr1 &&
                   Dr2 == other.Dr2 &&
                   Dr3 == other.Dr3 &&
                   Dr6 == other.Dr6 &&
                   Dr7 == other.Dr7 &&
                   Ds == other.Ds &&
                   Efl == other.Efl &&
                   Es == other.Es &&
                   Exfrom == other.Exfrom &&
                   Exto == other.Exto &&
                   Fpcw == other.Fpcw &&
                   Fpsw == other.Fpsw &&
                   Fptw == other.Fptw &&
                   Fopcode == other.Fopcode &&
                   Fpip == other.Fpip &&
                   Fpipsel == other.Fpipsel &&
                   Fpdp == other.Fpdp &&
                   Fpdpsel == other.Fpdpsel &&
                   Fs == other.Fs &&
                   Gs == other.Gs &&
                   Mm0 == other.Mm0 &&
                   Mm1 == other.Mm1 &&
                   Mm2 == other.Mm2 &&
                   Mm3 == other.Mm3 &&
                   Mm4 == other.Mm4 &&
                   Mm5 == other.Mm5 &&
                   Mm6 == other.Mm6 &&
                   Mm7 == other.Mm7 &&
                   Mxcsr == other.Mxcsr &&
                   (St0 == other.St0 || St0 != null && other.St0 != null && St0.SequenceEqual(other.St0)) &&
                   (St1 == other.St1 || St1 != null && other.St1 != null && St1.SequenceEqual(other.St1)) &&
                   (St2 == other.St2 || St2 != null && other.St2 != null && St2.SequenceEqual(other.St2)) &&
                   (St3 == other.St3 || St3 != null && other.St3 != null && St3.SequenceEqual(other.St3)) &&
                   (St4 == other.St4 || St4 != null && other.St4 != null && St4.SequenceEqual(other.St4)) &&
                   (St5 == other.St5 || St5 != null && other.St5 != null && St5.SequenceEqual(other.St5)) &&
                   (St6 == other.St6 || St6 != null && other.St6 != null && St6.SequenceEqual(other.St6)) &&
                   (St7 == other.St7 || St7 != null && other.St7 != null && St7.SequenceEqual(other.St7)) &&
                   R10 == other.R10 &&
                   R11 == other.R11 &&
                   R12 == other.R12 &&
                   R13 == other.R13 &&
                   R14 == other.R14 &&
                   R15 == other.R15 &&
                   R8 == other.R8 &&
                   R9 == other.R9 &&
                   Rax == other.Rax &&
                   Rbp == other.Rbp &&
                   Rbx == other.Rbx &&
                   Rcx == other.Rcx &&
                   Rdi == other.Rdi &&
                   Rdx == other.Rdx &&
                   Rip == other.Rip &&
                   Rsi == other.Rsi &&
                   Rsp == other.Rsp &&
                   Ss == other.Ss &&
                   (Ymm0 == other.Ymm0 || Ymm0 != null && other.Ymm0 != null && Ymm0.SequenceEqual(other.Ymm0)) &&
                   (Ymm1 == other.Ymm1 || Ymm1 != null && other.Ymm1 != null && Ymm1.SequenceEqual(other.Ymm1)) &&
                   (Ymm2 == other.Ymm2 || Ymm2 != null && other.Ymm2 != null && Ymm2.SequenceEqual(other.Ymm2)) &&
                   (Ymm3 == other.Ymm3 || Ymm3 != null && other.Ymm3 != null && Ymm3.SequenceEqual(other.Ymm3)) &&
                   (Ymm4 == other.Ymm4 || Ymm4 != null && other.Ymm4 != null && Ymm4.SequenceEqual(other.Ymm4)) &&
                   (Ymm5 == other.Ymm5 || Ymm5 != null && other.Ymm5 != null && Ymm5.SequenceEqual(other.Ymm5)) &&
                   (Ymm6 == other.Ymm6 || Ymm6 != null && other.Ymm6 != null && Ymm6.SequenceEqual(other.Ymm6)) &&
                   (Ymm7 == other.Ymm7 || Ymm7 != null && other.Ymm7 != null && Ymm7.SequenceEqual(other.Ymm7)) &&
                   (Ymm8 == other.Ymm8 || Ymm8 != null && other.Ymm8 != null && Ymm8.SequenceEqual(other.Ymm8)) &&
                   (Ymm9 == other.Ymm9 || Ymm9 != null && other.Ymm9 != null && Ymm9.SequenceEqual(other.Ymm9)) &&
                   (Ymm10 == other.Ymm10 || Ymm10 != null && other.Ymm10 != null && Ymm10.SequenceEqual(other.Ymm10)) &&
                   (Ymm11 == other.Ymm11 || Ymm11 != null && other.Ymm11 != null && Ymm11.SequenceEqual(other.Ymm11)) &&
                   (Ymm12 == other.Ymm12 || Ymm12 != null && other.Ymm12 != null && Ymm12.SequenceEqual(other.Ymm12)) &&
                   (Ymm13 == other.Ymm13 || Ymm13 != null && other.Ymm13 != null && Ymm13.SequenceEqual(other.Ymm13)) &&
                   (Ymm14 == other.Ymm14 || Ymm14 != null && other.Ymm14 != null && Ymm14.SequenceEqual(other.Ymm14)) &&
                   (Ymm15 == other.Ymm15 || Ymm15 != null && other.Ymm15 != null && Ymm15.SequenceEqual(other.Ymm15));
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((RegisterSet) obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 46573 ^
                               Brfrom?.GetHashCode() ?? 0 ^
                               Brto?.GetHashCode() ?? 0 ^
                               Cs?.GetHashCode() ?? 0 ^
                               Dr0?.GetHashCode() ?? 0 ^
                               Dr1?.GetHashCode() ?? 0 ^
                               Dr2?.GetHashCode() ?? 0 ^
                               Dr3?.GetHashCode() ?? 0 ^
                               Dr6?.GetHashCode() ?? 0 ^
                               Dr7?.GetHashCode() ?? 0 ^
                               Ds?.GetHashCode() ?? 0 ^
                               Efl?.GetHashCode() ?? 0 ^
                               Es?.GetHashCode() ?? 0 ^
                               Exfrom?.GetHashCode() ?? 0 ^
                               Exto?.GetHashCode() ?? 0 ^
                               Fpcw?.GetHashCode() ?? 0 ^
                               Fpsw?.GetHashCode() ?? 0 ^
                               Fptw?.GetHashCode() ?? 0 ^
                               Fopcode?.GetHashCode() ?? 0 ^
                               Fpip?.GetHashCode() ?? 0 ^
                               Fpipsel?.GetHashCode() ?? 0 ^
                               Fpdp?.GetHashCode() ?? 0 ^
                               Fpdpsel?.GetHashCode() ?? 0 ^
                               Fs?.GetHashCode() ?? 0 ^
                               Gs?.GetHashCode() ?? 0 ^
                               Mm0?.GetHashCode() ?? 0 ^
                               Mm1?.GetHashCode() ?? 0 ^
                               Mm2?.GetHashCode() ?? 0 ^
                               Mm3?.GetHashCode() ?? 0 ^
                               Mm4?.GetHashCode() ?? 0 ^
                               Mm5?.GetHashCode() ?? 0 ^
                               Mm6?.GetHashCode() ?? 0 ^
                               Mm7?.GetHashCode() ?? 0 ^
                               Mxcsr?.GetHashCode() ?? 0 ^
                               R10?.GetHashCode() ?? 0 ^
                               R11?.GetHashCode() ?? 0 ^
                               R12?.GetHashCode() ?? 0 ^
                               R13?.GetHashCode() ?? 0 ^
                               R14?.GetHashCode() ?? 0 ^
                               R15?.GetHashCode() ?? 0 ^
                               R8?.GetHashCode() ?? 0 ^
                               R9?.GetHashCode() ?? 0 ^
                               Rax?.GetHashCode() ?? 0 ^
                               Rbp?.GetHashCode() ?? 0 ^
                               Rbx?.GetHashCode() ?? 0 ^
                               Rcx?.GetHashCode() ?? 0 ^
                               Rdi?.GetHashCode() ?? 0 ^
                               Rdx?.GetHashCode() ?? 0 ^
                               Rip?.GetHashCode() ?? 0 ^
                               Rsi?.GetHashCode() ?? 0 ^
                               Rsp?.GetHashCode() ?? 0 ^
                               Ss?.GetHashCode() ?? 0;
                St0?.ToList().ForEach(b => hashCode ^= b);
                St1?.ToList().ForEach(b => hashCode ^= b);
                St2?.ToList().ForEach(b => hashCode ^= b);
                St3?.ToList().ForEach(b => hashCode ^= b);
                St4?.ToList().ForEach(b => hashCode ^= b);
                St5?.ToList().ForEach(b => hashCode ^= b);
                St6?.ToList().ForEach(b => hashCode ^= b);
                St7?.ToList().ForEach(b => hashCode ^= b);
                Ymm0?.ToList().ForEach(b => hashCode ^= b);
                Ymm1?.ToList().ForEach(b => hashCode ^= b);
                Ymm2?.ToList().ForEach(b => hashCode ^= b);
                Ymm3?.ToList().ForEach(b => hashCode ^= b);
                Ymm4?.ToList().ForEach(b => hashCode ^= b);
                Ymm5?.ToList().ForEach(b => hashCode ^= b);
                Ymm6?.ToList().ForEach(b => hashCode ^= b);
                Ymm7?.ToList().ForEach(b => hashCode ^= b);
                Ymm8?.ToList().ForEach(b => hashCode ^= b);
                Ymm9?.ToList().ForEach(b => hashCode ^= b);
                Ymm10?.ToList().ForEach(b => hashCode ^= b);
                Ymm11?.ToList().ForEach(b => hashCode ^= b);
                Ymm12?.ToList().ForEach(b => hashCode ^= b);
                Ymm13?.ToList().ForEach(b => hashCode ^= b);
                Ymm14?.ToList().ForEach(b => hashCode ^= b);
                Ymm15?.ToList().ForEach(b => hashCode ^= b);


                return hashCode;
            }
        }

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

            var first = Register.All.FirstOrDefault(x =>
                x.Name.Equals(register, StringComparison.OrdinalIgnoreCase));
            if (first == null) return;
            var ymmRegex = new Regex(
                @"\s*(?<a>[a-z0-9]+)\s*(?<b>[a-z0-9]+)\s*(?<c>[a-z0-9]+)\s*(?<d>[a-z0-9]+)\s*(?<e>[a-z0-9]+)\s*(?<f>[a-z0-9]+)\s*(?<g>[a-z0-9]+)\s*(?<h>[a-z0-9]+)",
                RegexOptions.IgnoreCase);
            var stRegex = new Regex(@"[a-f0-9]+:(?<hi>[a-f0-9]+):(?<lo>[a-f0-9]+)", RegexOptions.IgnoreCase);
            var xmmRegex = new Regex(
                @"\s*(?<a>[a-z0-9]+)\s*(?<b>[a-z0-9]+)\s*(?<c>[a-z0-9]+)\s*(?<d>[a-z0-9]+)\s*",
                RegexOptions.IgnoreCase);
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
                case "fopcode":
                    Fopcode = Convert.ToUInt32(input, radix);
                    break;
                case "fpip":
                    Fpip = Convert.ToUInt32(input, radix);
                    break;
                case "fpipsel":
                    Fpipsel = Convert.ToUInt32(input, radix);
                    break;
                case "fpdp":
                    Fpdp = Convert.ToUInt32(input, radix);
                    break;
                case "fpdpsel":
                    Fpdpsel = Convert.ToUInt32(input, radix);
                    break;
                case "st0":
                {
                    var regex = stRegex;
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
                    var regex = stRegex;
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
                    var regex = stRegex;
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
                    var regex = stRegex;
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
                    var regex = stRegex;
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
                    var regex = stRegex;
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
                    var regex = stRegex;
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
                    var regex = stRegex;
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
                case "ymm0":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Ymm0 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm1":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Ymm1 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm2":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Ymm2 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm3":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Ymm3 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm4":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Ymm4 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm5":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Ymm5 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm6":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Ymm6 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm7":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Ymm7 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm8":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Ymm8 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm9":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Ymm9 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm10":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Ymm10 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm11":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Ymm11 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm12":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Ymm12 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm13":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Ymm13 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm14":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Ymm14 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm15":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Ymm15 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "xmm0":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    if (Ymm0 == null)
                        Ymm0 = new byte[32];
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Xmm0 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm1":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    if (Ymm1 == null)
                        Ymm1 = new byte[32];
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Xmm1 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm2":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    if (Ymm2 == null)
                        Ymm2 = new byte[32];
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Xmm2 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm3":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    if (Ymm3 == null)
                        Ymm3 = new byte[32];
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Xmm3 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm4":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    if (Ymm4 == null)
                        Ymm4 = new byte[32];
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Xmm4 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm5":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    if (Ymm5 == null)
                        Ymm5 = new byte[32];
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Xmm5 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm6":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    if (Ymm6 == null)
                        Ymm6 = new byte[32];
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Xmm6 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm7":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    if (Ymm7 == null)
                        Ymm7 = new byte[32];
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Xmm7 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm8":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    if (Ymm8 == null)
                        Ymm8 = new byte[32];
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Xmm8 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm9":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    if (Ymm9 == null)
                        Ymm9 = new byte[32];
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Xmm9 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm10":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    if (Ymm10 == null)
                        Ymm10 = new byte[32];
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Xmm10 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm11":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    if (Ymm11 == null)
                        Ymm11 = new byte[32];
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Xmm11 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm12":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    if (Ymm12 == null)
                        Ymm12 = new byte[32];
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Xmm12 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm13":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    if (Ymm13 == null)
                        Ymm13 = new byte[32];
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Xmm13 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm14":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    if (Ymm14 == null)
                        Ymm14 = new byte[32];
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Xmm14 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm15":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    if (Ymm15 == null)
                        Ymm15 = new byte[32];
                    var stripped = Regex.Replace(input, @"\s*", "");
                    Xmm15 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm0l":
                    Xmm0l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm1l":
                    Xmm1l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm2l":
                    Xmm2l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm3l":
                    Xmm3l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm4l":
                    Xmm4l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm5l":
                    Xmm5l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm6l":
                    Xmm6l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm7l":
                    Xmm7l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm8l":
                    Xmm8l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm9l":
                    Xmm9l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm10l":
                    Xmm10l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm11l":
                    Xmm11l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm12l":
                    Xmm12l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm13l":
                    Xmm13l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm14l":
                    Xmm14l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm15l":
                    Xmm15l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm0h":
                    Xmm0h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm1h":
                    Xmm1h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm2h":
                    Xmm2h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm3h":
                    Xmm3h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm4h":
                    Xmm4h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm5h":
                    Xmm5h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm6h":
                    Xmm6h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm7h":
                    Xmm7h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm8h":
                    Xmm8h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm9h":
                    Xmm9h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm10h":
                    Xmm10h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm11h":
                    Xmm11h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm12h":
                    Xmm12h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm13h":
                    Xmm13h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm14h":
                    Xmm14h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm15h":
                    Xmm15h = Convert.ToUInt64(input, 16);
                    break;
                case "ymm0h":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm0h = bytes;
                    break;
                }

                case "ymm1h":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm1h = bytes;
                    break;
                }

                case "ymm2h":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm2h = bytes;
                    break;
                }

                case "ymm3h":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm3h = bytes;
                    break;
                }

                case "ymm4h":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm4h = bytes;
                    break;
                }

                case "ymm5h":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm5h = bytes;
                    break;
                }

                case "ymm6h":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm6h = bytes;
                    break;
                }

                case "ymm7h":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm7h = bytes;
                    break;
                }

                case "ymm8h":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm8h = bytes;
                    break;
                }

                case "ymm9h":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm9h = bytes;
                    break;
                }

                case "ymm10h":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm10h = bytes;
                    break;
                }

                case "ymm11h":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm11h = bytes;
                    break;
                }

                case "ymm12h":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm12h = bytes;
                    break;
                }

                case "ymm13h":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm13h = bytes;
                    break;
                }

                case "ymm14h":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm14h = bytes;
                    break;
                }

                case "ymm15h":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm15h = bytes;
                    break;
                }
                case "ymm0l":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm0l = bytes;
                    break;
                }

                case "ymm1l":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm1l = bytes;
                    break;
                }

                case "ymm2l":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm2l = bytes;
                    break;
                }

                case "ymm3l":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm3l = bytes;
                    break;
                }

                case "ymm4l":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm4l = bytes;
                    break;
                }

                case "ymm5l":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm5l = bytes;
                    break;
                }

                case "ymm6l":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm6l = bytes;
                    break;
                }

                case "ymm7l":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm7l = bytes;
                    break;
                }

                case "ymm8l":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm8l = bytes;
                    break;
                }

                case "ymm9l":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm9l = bytes;
                    break;
                }

                case "ymm10l":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm10l = bytes;
                    break;
                }

                case "ymm11l":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm11l = bytes;
                    break;
                }

                case "ymm12l":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm12l = bytes;
                    break;
                }

                case "ymm13l":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm13l = bytes;
                    break;
                }

                case "ymm14l":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm14l = bytes;
                    break;
                }

                case "ymm15l":
                {
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    Ymm15l = bytes;
                    break;
                }
                case "exfrom":

                    Exfrom = Convert.ToUInt64(input, 16);
                    break;

                case "exto":

                    Exto = Convert.ToUInt64(input, 16);
                    break;

                case "brfrom":

                    Brfrom = Convert.ToUInt64(input, 16);
                    break;

                case "brto":

                    Brto = Convert.ToUInt64(input, 16);
                    break;

                case "eax":

                    Eax = Convert.ToUInt32(input, 16);
                    break;

                case "ecx":

                    Ecx = Convert.ToUInt32(input, 16);
                    break;

                case "edx":

                    Edx = Convert.ToUInt32(input, 16);
                    break;

                case "ebx":

                    Ebx = Convert.ToUInt32(input, 16);
                    break;

                case "esp":

                    Esp = Convert.ToUInt32(input, 16);
                    break;

                case "ebp":

                    Ebp = Convert.ToUInt32(input, 16);
                    break;

                case "esi":

                    Esi = Convert.ToUInt32(input, 16);
                    break;

                case "edi":

                    Edi = Convert.ToUInt32(input, 16);
                    break;

                case "r8d":
                    R8d = Convert.ToUInt32(input, 16);
                    break;
                case "r9d":
                    R9d = Convert.ToUInt32(input, 16);
                    break;
                case "r10d":
                    R10d = Convert.ToUInt32(input, 16);
                    break;
                case "r11d":
                    R11d = Convert.ToUInt32(input, 16);
                    break;
                case "r12d":
                    R12d = Convert.ToUInt32(input, 16);
                    break;
                case "r13d":
                    R13d = Convert.ToUInt32(input, 16);
                    break;
                case "r14d":
                    R14d = Convert.ToUInt32(input, 16);
                    break;
                case "r15d":
                    R15d = Convert.ToUInt32(input, 16);
                    break;
                case "eip":
                {
                    Eip = Convert.ToUInt32(input, 16);
                    break;
                }
                case "ax":
                {
                    Ax = Convert.ToUInt16(input, 16);
                    break;
                }
                case "cx":
                {
                    Cx = Convert.ToUInt16(input, 16);
                    break;
                }
                case "dx":
                {
                    Dx = Convert.ToUInt16(input, 16);
                    break;
                }
                case "bx":
                {
                    Bx =
                        Convert.ToUInt16(input, 16);
                    break;
                }
                case "sp":
                {
                    Sp = Convert.ToUInt16(input, 16);
                    break;
                }
                case "bp":
                {
                    Bp = Convert.ToUInt16(input, 16);
                    break;
                }
                case "si":
                    Si = Convert.ToUInt16(input, 16);
                    break;
                case "di":
                    Di = Convert.ToUInt16(input, 16);
                    break;
                case "r8w":
                    R8w = Convert.ToUInt16(input, 16);
                    break;
                case "r9w":
                    R9w = Convert.ToUInt16(input, 16);
                    break;
                case "r10w":
                    R10w = Convert.ToUInt16(input, 16);
                    break;
                case "r11w":
                    R11w = Convert.ToUInt16(input, 16);
                    break;
                case "r12w":
                    R12w = Convert.ToUInt16(input, 16);
                    break;
                case "r13w":
                    R13w = Convert.ToUInt16(input, 16);
                    break;
                case "r14w":
                    R14w = Convert.ToUInt16(input, 16);
                    break;
                case "r15w":
                    R15w = Convert.ToUInt16(input, 16);
                    break;
                case "ip":
                    Ip = Convert.ToUInt16(input, 16);
                    break;
                case "fl":
                    Fl = Convert.ToUInt16(input, 16);
                    break;
                case "al":
                    Al = Convert.ToByte(input, 16);
                    break;
                case "bl":
                    Bl = Convert.ToByte(input, 16);
                    break;
                case "cl":
                    Cl = Convert.ToByte(input, 16);
                    break;
                case "spl":
                    Spl = Convert.ToByte(input, 16);
                    break;
                case "dl":
                    Dl = Convert.ToByte(input, 16);
                    break;
                case "bpl":
                    Bpl = Convert.ToByte(input, 16);
                    break;
                case "sil":
                    Sil = Convert.ToByte(input, 16);
                    break;
                case "dil":
                    Dil = Convert.ToByte(input, 16);
                    break;
                case "r8b":
                    R8b = Convert.ToByte(input, 16);
                    break;
                case "r9b":
                    R9b = Convert.ToByte(input, 16);
                    break;
                case "r10b":
                    R10b = Convert.ToByte(input, 16);
                    break;
                case "r11b":
                    R11b = Convert.ToByte(input, 16);
                    break;
                case "r12b":
                    R12b = Convert.ToByte(input, 16);
                    break;
                case "r13b":
                    R13b = Convert.ToByte(input, 16);
                    break;
                case "r14b":
                    R14b = Convert.ToByte(input, 16);
                    break;
                case "r15b":
                    R15b = Convert.ToByte(input, 16);
                    break;
                case "ah":
                    Ah = Convert.ToByte(input, 16);
                    break;
                case "bh":
                    Bh = Convert.ToByte(input, 16);
                    break;
                case "ch":
                    Ch = Convert.ToByte(input, 16);
                    break;
                case "dh":
                    Dh = Convert.ToByte(input, 16);
                    break;
                case "iopl":
                    Iopl = Convert.ToByte(input, 16);
                    break;
                case "of":
                    Of = Convert.ToUInt64(input, 16) > 0;
                    break;
                case "df":
                    Df = Convert.ToUInt64(input, 16) > 0;
                    break;
                case "if":
                    If = Convert.ToUInt64(input, 16) > 0;
                    break;
                case "tf":
                    Tf = Convert.ToUInt64(input, 16) > 0;
                    break;
                case "sf":
                    Sf = Convert.ToUInt64(input, 16) > 0;
                    break;
                case "zf":
                    Zf = Convert.ToUInt64(input, 16) > 0;
                    break;
                case "af":
                    Af = Convert.ToUInt64(input, 16) > 0;
                    break;
                case "pf":
                    Pf = Convert.ToUInt64(input, 16) > 0;
                    break;
                case "cf":
                    Cf = Convert.ToUInt64(input, 16) > 0;
                    break;
                case "vip":
                    Vip = Convert.ToUInt64(input, 16) > 0;
                    break;
                case "vif":
                    Vif = Convert.ToUInt64(input, 16) > 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(register)} has a value of {register} which is not a valid register");
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public bool? Af
        {
            get => Efl.HasValue ? (bool?) ((Efl & 0x0010) > 0) : null;
            set
            {
                if (!value.HasValue) return;
                if (!Efl.HasValue)
                    Efl = 0;
                uint mask = 0x0010;
                if (value.Value)
                    Efl = Efl |= mask;
                else
                    Efl = Efl &= ~mask;
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte? Ah
        {
            get => Ax?.Hi8();
            set
            {
                if (!value.HasValue) return;
                if (Rax == null)
                    Rax = 0;
                Ax = Ax?.Hi8(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte? Al
        {
            get => Ax?.Lo8();
            set
            {
                if (!value.HasValue) return;
                if (Rax == null)
                    Rax = 0;
                Ax = Ax?.Lo8(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ushort? Ax
        {
            get => Eax?.Lo16();
            set
            {
                if (!value.HasValue) return;
                if (Rax == null)
                    Rax = 0;
                Eax = Eax?.Lo16(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte? Bh
        {
            get => Bx?.Hi8();
            set
            {
                if (!value.HasValue) return;
                if (Rbx == null)
                    Rbx = 0;
                Bx = Bx?.Hi8(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte? Bl
        {
            get => Bx?.Lo8();
            set
            {
                if (!value.HasValue) return;
                if (Rbx == null)
                    Rbx = 0;
                Bx = Bx?.Lo8(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ushort? Bp
        {
            get => Ebp?.Lo16();
            set
            {
                if (!value.HasValue) return;
                if (Rbp == null)
                    Rbp = 0;
                Ebp = Ebp?.Lo16(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte? Bpl
        {
            get => Bp?.Lo8();
            set
            {
                if (!value.HasValue) return;
                if (Rbp == null)
                    Rbp = 0;
                Bp = Bp?.Lo8(value.Value);
            }
        }

        public ulong? Brfrom { get; set; }
        public ulong? Brto { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ushort? Bx
        {
            get => Ebx?.Lo16();
            set
            {
                if (!value.HasValue) return;
                if (Ebx == null)
                    Ebx = 0;
                Ebx = Ebx?.Lo16(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public bool? Cf
        {
            get => Efl.HasValue ? (bool?) ((Efl & 0x0001) > 0) : null;
            set
            {
                if (!value.HasValue) return;
                if (Efl == null)
                    Efl = 0;
                uint mask = 0x0001;
                if (value.Value)
                    Efl = Efl |= mask;
                else
                    Efl = Efl &= ~mask;
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte? Ch
        {
            get => Cx?.Hi8();
            set
            {
                if (!value.HasValue) return;
                if (Rcx == null)
                    Rcx = 0;
                Cx = Cx?.Hi8(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte? Cl
        {
            get => Cx?.Lo8();
            set
            {
                if (!value.HasValue) return;
                if (Rcx == null)
                    Rcx = 0;
                Cx = Cx?.Lo8(value.Value);
            }
        }

        public ushort? Cs { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ushort? Cx
        {
            get => Ecx?.Lo16();
            set
            {
                if (!value.HasValue) return;
                if (Rcx == null)
                    Rcx = 0;
                Ecx = Ecx?.Lo16(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public bool? Df
        {
            get => Efl.HasValue ? (bool?) ((Efl & 0x0400) > 0) : null;
            set
            {
                if (!value.HasValue) return;
                if (Efl == null)
                    Efl = 0;
                uint mask = 0x0400;
                if (value.Value)
                    Efl = Efl |= mask;
                else
                    Efl = Efl &= ~mask;
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte? Dh
        {
            get => Dx?.Hi8();
            set
            {
                if (!value.HasValue) return;
                if (Rdx == null)
                    Rdx = 0;
                Dx = Dx?.Hi8(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ushort? Di
        {
            get => Edi?.Lo16();
            set
            {
                if (!value.HasValue) return;
                if (Rdi == null)
                    Rdi = 0;
                Edi = Edi?.Lo16(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte? Dil
        {
            get => Di?.Lo8();
            set
            {
                if (!value.HasValue) return;
                if (Rdi == null)
                    Rdi = 0;
                Di = Di?.Lo8(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte? Dl
        {
            get => Dx?.Lo8();
            set
            {
                if (!value.HasValue) return;
                if (Rdx == null)
                    Rdx = 0;
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

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ushort? Dx
        {
            get => Edx?.Lo16();
            set
            {
                if (!value.HasValue) return;
                if (Rdx == null)
                    Rdx = 0;
                Edx = Edx?.Lo16(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public uint? Eax
        {
            get => Rax?.Lo32();
            set
            {
                if (!value.HasValue) return;
                if (Rax == null)
                    Rax = 0;
                Rax = Rax?.Lo32(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public uint? Ebp
        {
            get => Rbp?.Lo32();
            set
            {
                if (!value.HasValue) return;
                if (Rbp == null)
                    Rbp = 0;
                Rbp = Rbp?.Lo32(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public uint? Ebx
        {
            get => Rbx?.Lo32();
            set
            {
                if (!value.HasValue) return;
                if (Rbx == null)
                    Rbx = 0;
                Rbx = Rbx?.Lo32(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public uint? Ecx
        {
            get => Rcx?.Lo32();
            set
            {
                if (!value.HasValue) return;
                if (Rcx == null)
                    Rcx = 0;
                Rcx = Rcx?.Lo32(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public uint? Edi
        {
            get => Rdi?.Lo32();
            set
            {
                if (!value.HasValue) return;
                if (Rdi == null)
                    Rdi = 0;
                Rdi = Rdi?.Lo32(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public uint? Edx
        {
            get => Rdx?.Lo32();
            set
            {
                if (!value.HasValue) return;
                if (Rdx == null)
                    Rdx = 0;
                Rdx = Rdx?.Lo32(value.Value);
            }
        }

        public uint? Efl { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public uint? Eip
        {
            get => Rip?.Lo32();
            set
            {
                if (!value.HasValue) return;
                if (Rip == null)
                    Rip = 0;
                Rip = Rip?.Lo32(value.Value);
            }
        }

        public ushort? Es { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public uint? Esi
        {
            get => Rsi?.Lo32();
            set
            {
                if (!value.HasValue) return;
                if (Rsi == null)
                    Rsi = 0;
                Rsi = Rsi?.Lo32(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public uint? Esp
        {
            get => Rsp?.Lo32();
            set
            {
                if (!value.HasValue) return;
                if (Rsp == null)
                    Rsp = 0;
                Rsp = Rsp?.Lo32(value.Value);
            }
        }

        public ulong? Exfrom { get; set; }
        public ulong? Exto { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ushort? Fl
        {
            get => Efl?.Lo16();
            set
            {
                if (!value.HasValue) return;
                if (Efl == null)
                    Efl = 0;
                Efl = Efl?.Lo16(value.Value);
            }
        }

        public ushort? Fpcw { get; set; }
        public ushort? Fpsw { get; set; }
        public ushort? Fptw { get; set; }
        public ushort? Fs { get; set; }
        public ushort? Gs { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public bool? If
        {
            get => Efl.HasValue ? (bool?) ((Efl & 0x0200) > 0) : null;
            set
            {
                if (!value.HasValue) return;
                if (Efl == null)
                    Efl = 0;
                uint mask = 0x0200;
                if (value.Value)
                    Efl = Efl |= mask;
                else
                    Efl = Efl &= ~mask;
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte? Iopl
        {
            get => Efl.HasValue ? (byte?) ((Efl & 0x3000) >> 12) : null;
            set
            {
                if (!value.HasValue)
                    return;
                if (Efl == null)
                    Efl = 0;
                Efl &= unchecked((uint) ~12288);
                Efl |= (uint) (value.Value << 12);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ushort? Ip
        {
            get => Eip?.Lo16();
            set
            {
                if (!value.HasValue) return;
                if (Rip == null)
                    Rip = 0;
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

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public bool? Of
        {
            get => Efl.HasValue ? (bool?) ((Efl & 0x0800) > 0) : null;
            set
            {
                if (!value.HasValue) return;
                if (Efl == null)
                    Efl = 0;
                uint mask = 0x0800;
                if (value.Value)
                    Efl = Efl |= mask;
                else
                    Efl = Efl &= ~mask;
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public bool? Pf
        {
            get => Efl.HasValue ? (bool?) ((Efl & 0x0004) > 0) : null;
            set
            {
                if (!value.HasValue) return;
                if (Efl == null)
                    Efl = 0;
                uint mask = 0x0004;
                if (value.Value)
                    Efl = Efl |= mask;
                else
                    Efl = Efl &= ~mask;
            }
        }

        public ulong? R10 { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte? R10b
        {
            get => R10w?.Lo8();
            set
            {
                if (!value.HasValue) return;
                if (R10 == null)
                    R10 = 0;
                R10w = R10w?.Lo8(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public uint? R10d
        {
            get => R10?.Lo32();
            set
            {
                if (!value.HasValue) return;
                if (R10 == null)
                    R10 = 0;
                R10 = R10?.Lo32(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ushort? R10w
        {
            get => R10d?.Lo16();
            set
            {
                if (!value.HasValue) return;
                if (R10 == null)
                    R10 = 0;
                R10d = R10d?.Lo16(value.Value);
            }
        }

        public ulong? R11 { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte? R11b
        {
            get => R11w?.Lo8();
            set
            {
                if (!value.HasValue) return;
                if (R11 == null)
                    R11 = 0;
                R11w = R11w?.Lo8(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public uint? R11d
        {
            get => R11?.Lo32();
            set
            {
                if (!value.HasValue) return;
                if (R11 == null)
                    R11 = 0;
                R11 = R11?.Lo32(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ushort? R11w
        {
            get => R11d?.Lo16();
            set
            {
                if (!value.HasValue) return;
                if (R11 == null)
                    R11 = 0;
                R11d = R11d?.Lo16(value.Value);
            }
        }

        public ulong? R12 { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte? R12b
        {
            get => R12w?.Lo8();
            set
            {
                if (!value.HasValue) return;
                if (R12 == null)
                    R12 = 0;
                R12w = R12w?.Lo8(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public uint? R12d
        {
            get => R12?.Lo32();
            set
            {
                if (!value.HasValue) return;
                if (R12 == null)
                    R12 = 0;
                R12 = R12?.Lo32(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ushort? R12w
        {
            get => R12d?.Lo16();
            set
            {
                if (!value.HasValue) return;
                if (R12 == null)
                    R12 = 0;
                R12d = R12d?.Lo16(value.Value);
            }
        }

        public ulong? R13 { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte? R13b
        {
            get => R13w?.Lo8();
            set
            {
                if (!value.HasValue) return;
                if (R13 == null)
                    R13 = 0;
                R13w = R13w?.Lo8(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public uint? R13d
        {
            get => R13?.Lo32();
            set
            {
                if (!value.HasValue) return;
                if (R13 == null)
                    R13 = 0;
                R13 = R13?.Lo32(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ushort? R13w
        {
            get => R13d?.Lo16();
            set
            {
                if (!value.HasValue) return;
                if (R13 == null)
                    R13 = 0;
                R13d = R13d?.Lo16(value.Value);
            }
        }

        public ulong? R14 { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte? R14b
        {
            get => R14w?.Lo8();
            set
            {
                if (!value.HasValue) return;
                if (R14 == null)
                    R14 = 0;
                R14w = R14w?.Lo8(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public uint? R14d
        {
            get => R14?.Lo32();
            set
            {
                if (!value.HasValue) return;
                if (R14 == null)
                    R14 = 0;
                R14 = R14?.Lo32(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ushort? R14w
        {
            get => R14d?.Lo16();
            set
            {
                if (!value.HasValue) return;
                if (R14 == null)
                    R14 = 0;
                R14d = R14d?.Lo16(value.Value);
            }
        }

        public ulong? R15 { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte? R15b
        {
            get => R15w?.Lo8();
            set
            {
                if (!value.HasValue) return;
                if (R15 == null)
                    R15 = 0;
                R15w = R15w?.Lo8(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public uint? R15d
        {
            get => R15?.Lo32();
            set
            {
                if (!value.HasValue) return;
                if (R15 == null)
                    R15 = 0;
                R15 = R15?.Lo32(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]

        public ushort? R15w
        {
            get => R15d?.Lo16();
            set
            {
                if (!value.HasValue) return;
                if (R15 == null)
                    R15 = 0;
                R15d = R15d?.Lo16(value.Value);
            }
        }

        public ulong? R8 { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte? R8b
        {
            get => R8w?.Lo8();
            set
            {
                if (!value.HasValue) return;
                if (R8 == null)
                    R8 = 0;
                R8w = R8w?.Lo8(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public uint? R8d
        {
            get => R8?.Lo32();
            set
            {
                if (!value.HasValue) return;
                if (R8 == null)
                    R8 = 0;
                R8 = R8?.Lo32(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ushort? R8w
        {
            get => R8d?.Lo16();
            set
            {
                if (!value.HasValue) return;
                if (R8 == null)
                    R8 = 0;
                R8d = R8d?.Lo16(value.Value);
            }
        }

        public ulong? R9 { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte? R9b
        {
            get => R9w?.Lo8();
            set
            {
                if (!value.HasValue) return;
                if (R9 == null)
                    R9 = 0;
                R9w = R9w?.Lo8(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public uint? R9d
        {
            get => R9?.Lo32();
            set
            {
                if (!value.HasValue) return;
                if (R9 == null)
                    R9 = 0;
                R9 = R9?.Lo32(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ushort? R9w
        {
            get => R9d?.Lo16();
            set
            {
                if (!value.HasValue) return;
                if (R9 == null)
                    R9 = 0;
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

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public bool? Sf
        {
            get => Efl.HasValue ? (bool?) ((Efl & 0x0080) > 0) : null;
            set
            {
                if (!value.HasValue) return;
                if (Efl == null)
                    Efl = 0;
                uint mask = 0x0080;
                if (value.Value)
                    Efl = Efl |= mask;
                else
                    Efl = Efl &= ~mask;
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ushort? Si
        {
            get => Esi?.Lo16();
            set
            {
                if (!value.HasValue) return;
                if (Rsi == null)
                    Rsi = 0;
                Esi = Esi?.Lo16(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte? Sil
        {
            get => Si?.Lo8();
            set
            {
                if (!value.HasValue) return;
                if (Rsi == null)
                    Rsi = 0;
                Si = Si?.Lo8(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ushort? Sp
        {
            get => Esp?.Lo16();
            set
            {
                if (!value.HasValue) return;
                if (Rsp == null)
                    Rsp = 0;
                Esp = Esp?.Lo16(value.Value);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte? Spl
        {
            get => Sp?.Lo8();
            set
            {
                if (!value.HasValue) return;
                if (Rsp == null)
                    Rsp = 0;
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

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public bool? Tf
        {
            get => Efl.HasValue ? (bool?) ((Efl & 0x0100) > 0) : null;
            set
            {
                if (!value.HasValue) return;
                if (!Efl.HasValue)
                    Efl = 0;
                uint mask = 0x0100;
                if (value.Value)
                    Efl = Efl |= mask;
                else
                    Efl = Efl &= ~mask;
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public bool? Vif
        {
            get => Efl.HasValue ? (bool?) ((Efl & 0x00080000) > 0) : null;
            set
            {
                if (!value.HasValue) return;
                if (!Efl.HasValue)
                    Efl = 0;
                uint mask = 0x00080000;
                if (value.Value)
                    Efl = Efl |= mask;
                else
                    Efl = Efl &= ~mask;
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public bool? Vip
        {
            get => Efl.HasValue ? (bool?) ((Efl & 0x00100000) > 0) : null;
            set
            {
                if (!value.HasValue) return;
                if (!Efl.HasValue)
                    Efl = 0;
                uint mask = 0x00100000;
                if (value.Value)
                    Efl = Efl |= mask;
                else
                    Efl = Efl &= ~mask;
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Xmm0
        {
            get => Ymm0?.Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm0 == null)
                    Ymm0 = new byte[32];
                if (value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                for (var i = 0; i < 16; i++)
                    Ymm0[i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm0h
        {
            get => Ymm0 == null ? null : (ulong?) BitConverter.ToUInt64(Ymm0, 8);
            set
            {
                if (value == null)
                    return;
                if (Ymm0 == null)
                    Ymm0 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++) Ymm0[8 + i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm0l
        {
            get => Ymm0 != null ? (ulong?) BitConverter.ToUInt64(Ymm0, 0) : null;
            set
            {
                if (value == null)
                    return;
                if (Ymm0 == null)
                    Ymm0 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++)
                    Ymm0[i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Xmm1
        {
            get => Ymm1?.Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm1 == null)
                    Ymm1 = new byte[32];
                if (value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                for (var i = 0; i < 16; i++)
                    Ymm1[i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Xmm10
        {
            get => Ymm10?.Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm10 == null)
                    Ymm10 = new byte[32];
                if (value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                for (var i = 0; i < 16; i++)
                    Ymm10[i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm10h
        {
            get => Ymm10 == null ? null : (ulong?) BitConverter.ToUInt64(Ymm10, 8);
            set
            {
                if (value == null)
                    return;
                if (Ymm10 == null)
                    Ymm10 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++) Ymm10[8 + i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm10l
        {
            get => Ymm10 != null ? (ulong?) BitConverter.ToUInt64(Ymm10, 0) : null;
            set
            {
                if (value == null)
                    return;
                if (Ymm10 == null)
                    Ymm10 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++)
                    Ymm10[i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Xmm11
        {
            get => Ymm11?.Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm11 == null)
                    Ymm11 = new byte[32];
                if (value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                for (var i = 0; i < 16; i++)
                    Ymm11[i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm11h
        {
            get => Ymm11 == null ? null : (ulong?) BitConverter.ToUInt64(Ymm11, 8);
            set
            {
                if (value == null)
                    return;
                if (Ymm11 == null)
                    Ymm11 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++) Ymm11[8 + i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm11l
        {
            get => Ymm11 != null ? (ulong?) BitConverter.ToUInt64(Ymm11, 0) : null;
            set
            {
                if (value == null)
                    return;
                if (Ymm11 == null)
                    Ymm11 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++)
                    Ymm11[i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Xmm12
        {
            get => Ymm12?.Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm12 == null)
                    Ymm12 = new byte[32];
                if (value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                for (var i = 0; i < 16; i++)
                    Ymm12[i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm12h
        {
            get => Ymm12 == null ? null : (ulong?) BitConverter.ToUInt64(Ymm12, 8);
            set
            {
                if (value == null)
                    return;
                if (Ymm12 == null)
                    Ymm12 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++) Ymm12[8 + i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm12l
        {
            get => Ymm12 != null ? (ulong?) BitConverter.ToUInt64(Ymm12, 0) : null;
            set
            {
                if (value == null)
                    return;
                if (Ymm12 == null)
                    Ymm12 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++)
                    Ymm12[i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Xmm13
        {
            get => Ymm13?.Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm13 == null)
                    Ymm13 = new byte[32];
                if (value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                for (var i = 0; i < 16; i++)
                    Ymm13[i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm13h
        {
            get => Ymm13 == null ? null : (ulong?) BitConverter.ToUInt64(Ymm13, 8);
            set
            {
                if (value == null)
                    return;
                if (Ymm13 == null)
                    Ymm13 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++) Ymm13[8 + i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm13l
        {
            get => Ymm13 != null ? (ulong?) BitConverter.ToUInt64(Ymm13, 0) : null;
            set
            {
                if (value == null)
                    return;
                if (Ymm13 == null)
                    Ymm13 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++)
                    Ymm13[i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Xmm14
        {
            get => Ymm14?.Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm14 == null)
                    Ymm14 = new byte[32];
                if (value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                for (var i = 0; i < 16; i++)
                    Ymm14[i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm14h
        {
            get => Ymm14 == null ? null : (ulong?) BitConverter.ToUInt64(Ymm14, 8);
            set
            {
                if (value == null)
                    return;
                if (Ymm14 == null)
                    Ymm14 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++) Ymm14[8 + i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm14l
        {
            get => Ymm14 != null ? (ulong?) BitConverter.ToUInt64(Ymm14, 0) : null;
            set
            {
                if (value == null)
                    return;
                if (Ymm14 == null)
                    Ymm14 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++)
                    Ymm14[i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Xmm15
        {
            get => Ymm15?.Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm15 == null)
                    Ymm15 = new byte[32];
                if (value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                for (var i = 0; i < 16; i++)
                    Ymm15[i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm15h
        {
            get => Ymm15 == null ? null : (ulong?) BitConverter.ToUInt64(Ymm15, 8);
            set
            {
                if (value == null)
                    return;
                if (Ymm15 == null)
                    Ymm15 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++) Ymm15[8 + i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm15l
        {
            get => Ymm15 != null ? (ulong?) BitConverter.ToUInt64(Ymm15, 0) : null;
            set
            {
                if (value == null)
                    return;
                if (Ymm15 == null)
                    Ymm15 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++)
                    Ymm15[i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm1h
        {
            get => Ymm1 == null ? null : (ulong?) BitConverter.ToUInt64(Ymm1, 8);
            set
            {
                if (value == null)
                    return;
                if (Ymm1 == null)
                    Ymm1 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++) Ymm1[8 + i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm1l
        {
            get => Ymm1 != null ? (ulong?) BitConverter.ToUInt64(Ymm1, 0) : null;
            set
            {
                if (value == null)
                    return;
                if (Ymm1 == null)
                    Ymm1 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++)
                    Ymm1[i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Xmm2
        {
            get => Ymm2?.Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm2 == null)
                    Ymm2 = new byte[32];
                if (value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                for (var i = 0; i < 16; i++)
                    Ymm2[i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm2h
        {
            get => Ymm2 == null ? null : (ulong?) BitConverter.ToUInt64(Ymm2, 8);
            set
            {
                if (value == null)
                    return;
                if (Ymm2 == null)
                    Ymm2 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++) Ymm2[8 + i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm2l
        {
            get => Ymm2 != null ? (ulong?) BitConverter.ToUInt64(Ymm2, 0) : null;
            set
            {
                if (value == null)
                    return;
                if (Ymm2 == null)
                    Ymm2 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++)
                    Ymm2[i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Xmm3
        {
            get => Ymm3?.Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm3 == null)
                    Ymm3 = new byte[32];
                if (value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                for (var i = 0; i < 16; i++)
                    Ymm3[i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm3h
        {
            get => Ymm3 == null ? null : (ulong?) BitConverter.ToUInt64(Ymm3, 8);
            set
            {
                if (value == null)
                    return;
                if (Ymm3 == null)
                    Ymm3 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++) Ymm3[8 + i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm3l
        {
            get => Ymm3 != null ? (ulong?) BitConverter.ToUInt64(Ymm3, 0) : null;
            set
            {
                if (value == null)
                    return;
                if (Ymm3 == null)
                    Ymm3 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++)
                    Ymm3[i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Xmm4
        {
            get => Ymm4?.Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm4 == null)
                    Ymm4 = new byte[32];
                if (value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                for (var i = 0; i < 16; i++)
                    Ymm4[i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm4h
        {
            get => Ymm4 == null ? null : (ulong?) BitConverter.ToUInt64(Ymm4, 8);
            set
            {
                if (value == null)
                    return;
                if (Ymm4 == null)
                    Ymm4 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++) Ymm4[8 + i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm4l
        {
            get => Ymm4 != null ? (ulong?) BitConverter.ToUInt64(Ymm4, 0) : null;
            set
            {
                if (value == null)
                    return;
                if (Ymm4 == null)
                    Ymm4 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++)
                    Ymm4[i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Xmm5
        {
            get => Ymm5?.Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm5 == null)
                    Ymm5 = new byte[32];
                if (value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                for (var i = 0; i < 16; i++)
                    Ymm5[i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm5h
        {
            get => Ymm5 == null ? null : (ulong?) BitConverter.ToUInt64(Ymm5, 8);
            set
            {
                if (value == null)
                    return;
                if (Ymm5 == null)
                    Ymm5 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++) Ymm5[8 + i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm5l
        {
            get => Ymm5 != null ? (ulong?) BitConverter.ToUInt64(Ymm5, 0) : null;
            set
            {
                if (value == null)
                    return;
                if (Ymm5 == null)
                    Ymm5 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++)
                    Ymm5[i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Xmm6
        {
            get => Ymm6?.Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm6 == null)
                    Ymm6 = new byte[32];
                if (value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                for (var i = 0; i < 16; i++)
                    Ymm6[i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm6h
        {
            get => Ymm6 == null ? null : (ulong?) BitConverter.ToUInt64(Ymm6, 8);
            set
            {
                if (value == null)
                    return;
                if (Ymm6 == null)
                    Ymm6 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++) Ymm6[8 + i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm6l
        {
            get => Ymm6 != null ? (ulong?) BitConverter.ToUInt64(Ymm6, 0) : null;
            set
            {
                if (value == null)
                    return;
                if (Ymm6 == null)
                    Ymm6 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++)
                    Ymm6[i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Xmm7
        {
            get => Ymm7?.Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm7 == null)
                    Ymm7 = new byte[32];
                if (value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                for (var i = 0; i < 16; i++)
                    Ymm7[i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm7h
        {
            get => Ymm7 == null ? null : (ulong?) BitConverter.ToUInt64(Ymm7, 8);
            set
            {
                if (value == null)
                    return;
                if (Ymm7 == null)
                    Ymm7 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++) Ymm7[8 + i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm7l
        {
            get => Ymm7 != null ? (ulong?) BitConverter.ToUInt64(Ymm7, 0) : null;
            set
            {
                if (value == null)
                    return;
                if (Ymm7 == null)
                    Ymm7 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++)
                    Ymm7[i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Xmm8
        {
            get => Ymm8?.Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm8 == null)
                    Ymm8 = new byte[32];
                if (value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                for (var i = 0; i < 16; i++)
                    Ymm8[i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm8h
        {
            get => Ymm8 == null ? null : (ulong?) BitConverter.ToUInt64(Ymm8, 8);
            set
            {
                if (value == null)
                    return;
                if (Ymm8 == null)
                    Ymm8 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++) Ymm8[8 + i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm8l
        {
            get => Ymm8 != null ? (ulong?) BitConverter.ToUInt64(Ymm8, 0) : null;
            set
            {
                if (value == null)
                    return;
                if (Ymm8 == null)
                    Ymm8 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++)
                    Ymm8[i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Xmm9
        {
            get => Ymm9?.Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm9 == null)
                    Ymm9 = new byte[32];
                if (value.Length != 16)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 16");
                for (var i = 0; i < 16; i++)
                    Ymm9[i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm9h
        {
            get => Ymm9 == null ? null : (ulong?) BitConverter.ToUInt64(Ymm9, 8);
            set
            {
                if (value == null)
                    return;
                if (Ymm9 == null)
                    Ymm9 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++) Ymm9[8 + i] = bytes[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong? Xmm9l
        {
            get => Ymm9 != null ? (ulong?) BitConverter.ToUInt64(Ymm9, 0) : null;
            set
            {
                if (value == null)
                    return;
                if (Ymm9 == null)
                    Ymm9 = new byte[32];

                var bytes = BitConverter.GetBytes(value.Value);
                for (var i = 0; i < 8; i++)
                    Ymm9[i] = bytes[i];
            }
        }

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

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm0h
        {
            get => Ymm0?.Skip(16).Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm0 == null)
                    Ymm0 = new byte[32];

                for (var i = 0; i < 16; i++)
                    Ymm0[16 + i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm0l
        {
            get => Xmm0;
            set => Xmm0 = value;
        }

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

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm10h
        {
            get => Ymm10?.Skip(16).Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm10 == null)
                    Ymm10 = new byte[32];

                for (var i = 0; i < 16; i++)
                    Ymm10[16 + i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm10l
        {
            get => Xmm10;
            set => Xmm10 = value;
        }

        public byte[] Ymm11
        {
            get => _ymm11;
            set
            {
                if (value != null && value.Length != 32)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 32");
                _ymm11 = value;
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm11h
        {
            get => Ymm11?.Skip(16).Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm11 == null)
                    Ymm11 = new byte[32];

                for (var i = 0; i < 16; i++)
                    Ymm11[16 + i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm11l
        {
            get => Xmm11;
            set => Xmm11 = value;
        }

        public byte[] Ymm12
        {
            get => _ymm12;
            set
            {
                if (value != null && value.Length != 32)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 32");
                _ymm12 = value;
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm12h
        {
            get => Ymm12?.Skip(16).Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm12 == null)
                    Ymm12 = new byte[32];

                for (var i = 0; i < 16; i++)
                    Ymm12[16 + i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm12l
        {
            get => Xmm12;
            set => Xmm12 = value;
        }

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

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm13h
        {
            get => Ymm13?.Skip(16).Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm13 == null)
                    Ymm13 = new byte[32];

                for (var i = 0; i < 16; i++)
                    Ymm13[16 + i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm13l
        {
            get => Xmm13;
            set => Xmm13 = value;
        }

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

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm14h
        {
            get => Ymm14?.Skip(16).Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm14 == null)
                    Ymm14 = new byte[32];

                for (var i = 0; i < 16; i++)
                    Ymm14[16 + i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm14l
        {
            get => Xmm14;
            set => Xmm14 = value;
        }

        public byte[] Ymm15
        {
            get => _ymm15;
            set
            {
                if (value != null && value.Length != 32)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 32");
                _ymm15 = value;
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm15h
        {
            get => Ymm15?.Skip(16).Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm15 == null)
                    Ymm15 = new byte[32];

                for (var i = 0; i < 16; i++)
                    Ymm15[16 + i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm15l
        {
            get => Xmm15;
            set => Xmm15 = value;
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm1h
        {
            get => Ymm1?.Skip(16).Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm1 == null)
                    Ymm1 = new byte[32];

                for (var i = 0; i < 16; i++)
                    Ymm1[16 + i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm1l
        {
            get => Xmm1;
            set => Xmm1 = value;
        }

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

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm2h
        {
            get => Ymm2?.Skip(16).Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm2 == null)
                    Ymm2 = new byte[32];

                for (var i = 0; i < 16; i++)
                    Ymm2[16 + i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm2l
        {
            get => Xmm2;
            set => Xmm2 = value;
        }

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

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm3h
        {
            get => Ymm3?.Skip(16).Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm3 == null)
                    Ymm3 = new byte[32];

                for (var i = 0; i < 16; i++)
                    Ymm3[16 + i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm3l
        {
            get => Xmm3;
            set => Xmm3 = value;
        }

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

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm4h
        {
            get => Ymm4?.Skip(16).Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm4 == null)
                    Ymm4 = new byte[32];

                for (var i = 0; i < 16; i++)
                    Ymm4[16 + i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm4l
        {
            get => Xmm4;
            set => Xmm4 = value;
        }

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

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm5h
        {
            get => Ymm5?.Skip(16).Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm5 == null)
                    Ymm5 = new byte[32];

                for (var i = 0; i < 16; i++)
                    Ymm5[16 + i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm5l
        {
            get => Xmm5;
            set => Xmm5 = value;
        }

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

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm6h
        {
            get => Ymm6?.Skip(16).Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm6 == null)
                    Ymm6 = new byte[32];

                for (var i = 0; i < 16; i++)
                    Ymm6[16 + i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm6l
        {
            get => Xmm6;
            set => Xmm6 = value;
        }

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

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm7h
        {
            get => Ymm7?.Skip(16).Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm7 == null)
                    Ymm7 = new byte[32];

                for (var i = 0; i < 16; i++)
                    Ymm7[16 + i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm7l
        {
            get => Xmm7;
            set => Xmm7 = value;
        }

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

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm8h
        {
            get => Ymm8?.Skip(16).Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm8 == null)
                    Ymm8 = new byte[32];

                for (var i = 0; i < 16; i++)
                    Ymm8[16 + i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm8l
        {
            get => Xmm8;
            set => Xmm8 = value;
        }

        public byte[] Ymm9
        {
            get => _ymm9;
            set
            {
                if (value != null && value.Length != 32)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} has {value.Length} bytes but must have exactly 32");
                _ymm9 = value;
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm9h
        {
            get => Ymm9?.Skip(16).Take(16).ToArray();
            set
            {
                if (value == null)
                    return;
                if (Ymm9 == null)
                    Ymm9 = new byte[32];

                for (var i = 0; i < 16; i++)
                    Ymm9[16 + i] = value[i];
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public byte[] Ymm9l
        {
            get => Xmm9;
            set => Xmm9 = value;
        }

        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public bool? Zf
        {
            get => Efl.HasValue ? (bool?) ((Efl & 0x0040) > 0) : null;
            set
            {
                if (!value.HasValue) return;
                if (!Efl.HasValue)
                    Efl = 0;
                uint mask = 0x0040;
                if (value.Value)
                    Efl = Efl |= mask;
                else
                    Efl = Efl &= ~mask;
            }
        }

        public uint? Fopcode { get; set; }
        public uint? Fpip { get; set; }
        public uint? Fpipsel { get; set; }
        public uint? Fpdp { get; set; }
        public uint? Fpdpsel { get; set; }
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