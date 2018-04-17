// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-18-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-12-2018
// ***********************************************************************
// <copyright file="ByteArrayBuilder.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace McFly.Core
{
    /// <summary>
    ///     Builder object for byte arrays
    /// </summary>
    public class ByteArrayBuilder
    {
        /// <summary>
        ///     The bytes
        /// </summary>
        private readonly List<byte> _bytes = new List<byte>();

        /// <summary>
        ///     Appdends the hexadecimal string.
        /// </summary>
        /// <param name="hexString">The hexadecimal string.</param>
        /// <returns>ByteArrayBuilder.</returns>
        public ByteArrayBuilder AppdendHexString(string hexString)
        {
            _bytes.AddRange(StringToByteArray(hexString));
            return this;
        }

        /// <summary>
        ///     Builds a new array based on this builders internal representation.
        /// </summary>
        /// <returns>System.Byte[].</returns>
        public byte[] Build()
        {
            return _bytes.ToArray();
        }

        /// <summary>
        ///     Reverses this instance.
        /// </summary>
        /// <returns>ByteArrayBuilder.</returns>
        public ByteArrayBuilder Reverse()
        {
            _bytes.Reverse();
            return this;
        }

        /// <summary>
        ///     Strings to byte array.
        /// </summary>
        /// <param name="hex">The hexadecimal.</param>
        /// <param name="isLittleEndian">if set to <c>true</c> [is little endian].</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="FormatException">
        ///     hex
        ///     or
        ///     hex
        /// </exception>
        public static byte[] StringToByteArray(string hex, bool isLittleEndian = false)
        {
            if (hex == null)
                return null;
            if (string.IsNullOrWhiteSpace(hex))
                return new byte[0];
            var match = Regex.Match(hex, @"^\s*(0x)?(?<bytes>[a-f0-9]+)\s*$", RegexOptions.IgnoreCase);
            if (!match.Success)
                throw new FormatException($"{nameof(hex)} was not in a valid format. Must be a valid hex string");
            var byteString = match.Groups["bytes"].Value;
            if (byteString.Length % 2 == 1)
                throw new FormatException($"{nameof(hex)} must have an even number of hexademical characters");

            var numberChars = byteString.Length;
            var bytes = new byte[numberChars / 2];
            for (var i = 0; i < numberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(byteString.Substring(i, 2), 16);
            return isLittleEndian ? bytes.Reverse().ToArray() : bytes;
        }
    }
}