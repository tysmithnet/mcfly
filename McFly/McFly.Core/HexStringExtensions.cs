// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 04-28-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-28-2018
// ***********************************************************************
// <copyright file="HexStringExtensions.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Linq;

namespace McFly.Core
{
    /// <summary>
    ///     Extension methods for converting hex strings to types
    /// </summary>
    public static class HexStringExtensions
    {
        /// <summary>
        ///     To the hexadecimal string.
        /// </summary>
        /// <param name="ulongValue">The ulong value.</param>
        /// <returns>System.String.</returns>
        public static string ToHexString(this ulong ulongValue)
        {
            return BitConverter.GetBytes(ulongValue).ToHexString();
        }

        /// <summary>
        ///     To the hexadecimal string.
        /// </summary>
        /// <param name="longValue">The long value.</param>
        /// <returns>System.String.</returns>
        public static string ToHexString(this long longValue)
        {
            return BitConverter.GetBytes(longValue).ToHexString();
        }

        /// <summary>
        ///     To the hexadecimal string.
        /// </summary>
        /// <param name="ulongValue">The ulong value.</param>
        /// <returns>System.String.</returns>
        public static string ToHexString(this ulong? ulongValue)
        {
            return ulongValue.HasValue ? BitConverter.GetBytes(ulongValue.Value).ToHexString() : null;
        }

        /// <summary>
        ///     To the hexadecimal string.
        /// </summary>
        /// <param name="longValue">The long value.</param>
        /// <returns>System.String.</returns>
        public static string ToHexString(this long? longValue)
        {
            return longValue.HasValue ? BitConverter.GetBytes(longValue.Value).ToHexString() : null;
        }

        /// <summary>
        ///     To the hexadecimal string.
        /// </summary>
        /// <param name="ushortValue">The ushort value.</param>
        /// <returns>System.String.</returns>
        public static string ToHexString(this ushort? ushortValue)
        {
            return ushortValue.HasValue ? BitConverter.GetBytes(ushortValue.Value).ToHexString() : null;
        }

        /// <summary>
        ///     To the hexadecimal string.
        /// </summary>
        /// <param name="ushortValue">The ushort value.</param>
        /// <returns>System.String.</returns>
        public static string ToHexString(this ushort ushortValue)
        {
            return BitConverter.GetBytes(ushortValue).ToHexString();
        }

        /// <summary>
        ///     To the hexadecimal string.
        /// </summary>
        /// <param name="uintValue">The uint value.</param>
        /// <returns>System.String.</returns>
        public static string ToHexString(this uint uintValue)
        {
            return BitConverter.GetBytes(uintValue).ToHexString();
        }

        /// <summary>
        ///     To the hexadecimal string.
        /// </summary>
        /// <param name="uintValue">The uint value.</param>
        /// <returns>System.String.</returns>
        public static string ToHexString(this uint? uintValue)
        {
            return uintValue.HasValue ? BitConverter.GetBytes(uintValue.Value).ToHexString() : null;
        }

        /// <summary>
        ///     To the hexadecimal string.
        /// </summary>
        /// <param name="byteArray">The byte array.</param>
        /// <param name="isLittleEndian">if set to <c>true</c> [is little endian].</param>
        /// <returns>System.String.</returns>
        public static string ToHexString(this byte[] byteArray, bool isLittleEndian = false)
        {
            if (byteArray == null)
                return null;
            return string.Join("",
                isLittleEndian ? byteArray.Select(x => $"{x:X2}").Reverse() : byteArray.Select(x => $"{x:X2}"));
        }

        /// <summary>
        ///     To the hexadecimal string.
        /// </summary>
        /// <param name="intValue">The int value.</param>
        /// <returns>System.String.</returns>
        public static string ToHexString(this int intValue)
        {
            return BitConverter.GetBytes(intValue).ToHexString();
        }

        /// <summary>
        ///     To the hexadecimal string.
        /// </summary>
        /// <param name="shortValue">The short value.</param>
        /// <returns>System.String.</returns>
        public static string ToHexString(this short shortValue)
        {
            return BitConverter.GetBytes(shortValue).ToHexString();
        }

        /// <summary>
        ///     Toints the specified hexadecimal string.
        /// </summary>
        /// <param name="hexString">The hexadecimal string.</param>
        /// <returns>System.Int32.</returns>
        public static int ToInt(this string hexString)
        {
            return ByteArrayBuilder.StringToByteArray(hexString).ToInt();
        }

        /// <summary>
        ///     To the long.
        /// </summary>
        /// <param name="hexString">The hexadecimal string.</param>
        /// <returns>System.Int64.</returns>
        public static long ToLong(this string hexString)
        {
            return ByteArrayBuilder.StringToByteArray(hexString).ToLong();
        }

        /// <summary>
        ///     Converts a hex string to a Int16
        /// </summary>
        /// <param name="hexString">The hexadecimal string.</param>
        /// <returns>System.Int16.</returns>
        public static short ToShort(this string hexString)
        {
            return ByteArrayBuilder.StringToByteArray(hexString).ToShort();
        }

        /// <summary>
        ///     Converts a hex string to a UInt64
        /// </summary>
        /// <param name="hexString">The hexadecimal string.</param>
        /// <returns>System.UInt32.</returns>
        public static uint ToUInt(this string hexString)
        {
            return ByteArrayBuilder.StringToByteArray(hexString).ToUInt();
        }

        /// <summary>
        ///     Converts a hex string to a UInt64
        /// </summary>
        /// <param name="hexString">The hexadecimal string.</param>
        /// <returns>System.UInt64.</returns>
        public static ulong ToULong(this string hexString)
        {
            return ByteArrayBuilder.StringToByteArray(hexString).ToULong();
        }

        /// <summary>
        ///     Converts a hex string to a UInt16
        /// </summary>
        /// <param name="hexString">The hexadecimal string.</param>
        /// <returns>System.UInt16.</returns>
        /// <example>"cdab" =&gt; 0xabcd</example>
        public static ushort ToUShort(this string hexString)
        {
            return ByteArrayBuilder.StringToByteArray(hexString).ToUShort();
        }
    }
}