// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 03-04-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-16-2018
// ***********************************************************************
// <copyright file="PrimitiveExtensions.cs" company="McFly.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Globalization;
using System.Linq;

namespace McFly.Core
{
    /// <summary>
    ///     Extension methods for common primitive conversions
    /// </summary>
    public static class PrimitiveExtensions
    {
        public static ulong ToULong(this int intValue)
        {
            return (ulong) intValue;
        }

        /// <summary>
        ///     Interpets the high 32 bits as a ulong
        /// </summary>
        /// <param name="ulongValue">The high 32 bits</param>
        /// <returns>System.UInt32.</returns>
        public static uint Hi32(this ulong ulongValue)
        {
            return (uint) (ulongValue >> 32);
        }

        /// <summary>
        ///     Returns the value resulting from using the provided value as the high 32 bits
        /// </summary>
        /// <param name="ulongValue">The ulong value.</param>
        /// <param name="hi32">The hi32.</param>
        /// <returns>System.UInt64.</returns>
        public static ulong Hi32(this ulong ulongValue, uint hi32)
        {
            return ((ulongValue << 32) >> 32) | hi32;
        }

        /// <summary>
        ///     Hi8s the specified ushort value.
        /// </summary>
        /// <param name="ushortValue">The ushort value.</param>
        /// <returns>System.Byte.</returns>
        public static byte Hi8(this ushort ushortValue)
        {
            return (byte) (ushortValue >> 8);
        }

        /// <summary>
        ///     Hi8s the specified byte value.
        /// </summary>
        /// <param name="ushortValue">The ushort value.</param>
        /// <param name="byteValue">The byte value.</param>
        /// <returns>System.UInt16.</returns>
        public static ushort Hi8(this ushort ushortValue, byte byteValue)
        {
            ushortValue &= 0x00FF;
            ushortValue |= (ushort) (byteValue << 8);
            return ushortValue;
        }

        /// <summary>
        ///     Lo16s the specified uint value.
        /// </summary>
        /// <param name="uintValue">The uint value.</param>
        /// <returns>System.UInt16.</returns>
        public static ushort Lo16(this uint uintValue)
        {
            return (ushort) uintValue;
        }

        /// <summary>
        ///     Lo16s the specified ushort value.
        /// </summary>
        /// <param name="uintValue">The uint value.</param>
        /// <param name="ushortValue">The ushort value.</param>
        /// <returns>System.UInt32.</returns>
        public static uint Lo16(this uint uintValue, ushort ushortValue)
        {
            return ((uintValue >> 16) << 16) | ushortValue;
        }

        /// <summary>
        ///     Interprest the low 32 bits as a uint32
        /// </summary>
        /// <param name="ulongValue">The ulong value.</param>
        /// <returns>System.UInt32.</returns>
        public static uint Lo32(this ulong ulongValue)
        {
            return (uint) ulongValue;
        }

        /// <summary>
        ///     Returns the value resulting from using the provided value as the low 32 bits
        /// </summary>
        /// <param name="ulongValue">The ulong value.</param>
        /// <param name="lo32">The low 32 bits to use</param>
        /// <returns>System.UInt64.</returns>
        public static ulong Lo32(this ulong ulongValue, uint lo32)
        {
            return ((ulongValue >> 32) << 32) | lo32;
        }

        /// <summary>
        ///     Lo8s the specified ushort value.
        /// </summary>
        /// <param name="ushortValue">The ushort value.</param>
        /// <returns>System.Byte.</returns>
        public static byte Lo8(this ushort ushortValue)
        {
            return (byte) ushortValue;
        }

        /// <summary>
        ///     Lo8s the specified byte value.
        /// </summary>
        /// <param name="ushortValue">The ushort value.</param>
        /// <param name="byteValue">The byte value.</param>
        /// <returns>System.UInt16.</returns>
        public static ushort Lo8(this ushort ushortValue, byte byteValue)
        {
            ushortValue &= 0xFF00;
            ushortValue |= byteValue;
            return ushortValue;
        }

        /// <summary>
        ///     To the byte array.
        /// </summary>
        /// <param name="ulongValue">The ulong value.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] ToByteArray(this ulong ulongValue)
        {
            return BitConverter.GetBytes(ulongValue);
        }

        /// <summary>
        ///     To the byte array.
        /// </summary>
        /// <param name="longValue">The long value.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] ToByteArray(this long longValue)
        {
            return BitConverter.GetBytes(longValue);
        }

        /// <summary>
        ///     To the byte array.
        /// </summary>
        /// <param name="uintValue">The uint value.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] ToByteArray(this uint uintValue)
        {
            return BitConverter.GetBytes(uintValue);
        }

        /// <summary>
        ///     To the byte array.
        /// </summary>
        /// <param name="intValue">The int value.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] ToByteArray(this int intValue)
        {
            return BitConverter.GetBytes(intValue);
        }

        /// <summary>
        ///     To the hexadecimal string.
        /// </summary>
        /// <param name="ulongValue">The ulong value.</param>
        /// <returns>System.String.</returns>
        public static string ToHexString(this ulong ulongValue)
        {
            return $"{ulongValue:X16}";
        }

        /// <summary>
        ///     To the hexadecimal string.
        /// </summary>
        /// <param name="longValue">The long value.</param>
        /// <returns>System.String.</returns>
        public static string ToHexString(this long longValue)
        {
            return $"{longValue:X16}";
        }

        /// <summary>
        ///     To the hexadecimal string.
        /// </summary>
        /// <param name="ulongValue">The ulong value.</param>
        /// <returns>System.String.</returns>
        public static string ToHexString(this ulong? ulongValue)
        {
            return ulongValue.HasValue ? $"{ulongValue:X16}" : null;
        }

        /// <summary>
        ///     To the hexadecimal string.
        /// </summary>
        /// <param name="longValue">The long value.</param>
        /// <returns>System.String.</returns>
        public static string ToHexString(this long? longValue)
        {
            return longValue.HasValue ? $"{longValue:X16}" : null;
        }

        /// <summary>
        ///     To the hexadecimal string.
        /// </summary>
        /// <param name="ushortValue">The ushort value.</param>
        /// <returns>System.String.</returns>
        public static string ToHexString(this ushort? ushortValue)
        {
            return ushortValue.HasValue ? $"{ushortValue:X4}" : null;
        }

        /// <summary>
        ///     To the hexadecimal string.
        /// </summary>
        /// <param name="ushortValue">The ushort value.</param>
        /// <returns>System.String.</returns>
        public static string ToHexString(this ushort ushortValue)
        {
            return $"{ushortValue:X4}";
        }

        /// <summary>
        ///     To the hexadecimal string.
        /// </summary>
        /// <param name="uintValue">The uint value.</param>
        /// <returns>System.String.</returns>
        public static string ToHexString(this uint uintValue)
        {
            return $"{uintValue:X8}";
        }

        /// <summary>
        ///     To the hexadecimal string.
        /// </summary>
        /// <param name="uintValue">The uint value.</param>
        /// <returns>System.String.</returns>
        public static string ToHexString(this uint? uintValue)
        {
            return uintValue.HasValue ? $"{uintValue:X8}" : null;
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
        ///     Toints the specified hexadecimal string.
        /// </summary>
        /// <param name="hexString">The hexadecimal string.</param>
        /// <returns>System.Int32.</returns>
        public static int Toint(this string hexString)
        {
            return int.Parse(hexString, NumberStyles.HexNumber);
        }

        /// <summary>
        ///     Converts the string representation of a number to an integer.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="ArgumentNullException">bytes</exception>
        /// <exception cref="ArgumentOutOfRangeException">bytes</exception>
        public static int ToInt(this byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));
            if (bytes.Length != 4)
                throw new ArgumentOutOfRangeException($"{nameof(bytes)} must have exactly 4 bytes");
            return BitConverter.ToInt32(bytes, 0);
        }

        /// <summary>
        ///     Converts the string representation of a number to an integer.
        /// </summary>
        /// <param name="uintValue">The uint value.</param>
        /// <returns>System.Int32.</returns>
        public static int ToInt(this uint uintValue)
        {
            return unchecked((int) uintValue);
        }

        /// <summary>
        ///     To the long.
        /// </summary>
        /// <param name="hexString">The hexadecimal string.</param>
        /// <returns>System.Int64.</returns>
        public static long ToLong(this string hexString)
        {
            return long.Parse(hexString, NumberStyles.HexNumber);
        }

        /// <summary>
        ///     Interprets the value as a long
        /// </summary>
        /// <param name="ulongValue">The ulong value.</param>
        /// <returns>System.Int64.</returns>
        public static long ToLong(this ulong ulongValue)
        {
            return unchecked((long) ulongValue);
        }

        /// <summary>
        ///     To the long.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.Int64.</returns>
        /// <exception cref="ArgumentNullException">bytes</exception>
        /// <exception cref="ArgumentOutOfRangeException">bytes</exception>
        public static long ToLong(this byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));
            if (bytes.Length != 8)
                throw new ArgumentOutOfRangeException($"{nameof(bytes)} must have exactly 8 bytes");
            return BitConverter.ToInt64(bytes, 0);
        }

        /// <summary>
        ///     To the short.
        /// </summary>
        /// <param name="hexString">The hexadecimal string.</param>
        /// <returns>System.Int16.</returns>
        public static short ToShort(this string hexString)
        {
            return short.Parse(hexString, NumberStyles.HexNumber);
        }

        /// <summary>
        ///     To the u int.
        /// </summary>
        /// <param name="hexString">The hexadecimal string.</param>
        /// <returns>System.UInt32.</returns>
        public static uint ToUInt(this string hexString)
        {
            return uint.Parse(hexString, NumberStyles.HexNumber);
        }

        /// <summary>
        ///     To the u int.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.UInt32.</returns>
        /// <exception cref="ArgumentNullException">bytes</exception>
        /// <exception cref="ArgumentOutOfRangeException">bytes</exception>
        public static uint ToUInt(this byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));
            if (bytes.Length != 4)
                throw new ArgumentOutOfRangeException($"{nameof(bytes)} must have exactly 4 bytes");
            return BitConverter.ToUInt32(bytes, 0);
        }

        /// <summary>
        ///     To the u int.
        /// </summary>
        /// <param name="intValue">The int value.</param>
        /// <returns>System.UInt32.</returns>
        public static uint ToUInt(this int intValue)
        {
            return unchecked ((uint) intValue);
        }

        /// <summary>
        ///     To the u long.
        /// </summary>
        /// <param name="hexString">The hexadecimal string.</param>
        /// <returns>System.UInt64.</returns>
        public static ulong ToULong(this string hexString)
        {
            return ulong.Parse(hexString, NumberStyles.HexNumber);
        }

        /// <summary>
        ///     Interprets the value as a ulong
        /// </summary>
        /// <param name="longValue">The long value.</param>
        /// <returns>System.UInt64.</returns>
        public static ulong ToULong(this long longValue)
        {
            return unchecked((ulong) longValue);
        }

        /// <summary>
        ///     To the u long.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.UInt64.</returns>
        /// <exception cref="ArgumentNullException">bytes</exception>
        /// <exception cref="ArgumentOutOfRangeException">bytes</exception>
        public static ulong ToULong(this byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));
            if (bytes.Length != 8)
                throw new ArgumentOutOfRangeException($"{nameof(bytes)} must have exactly 8 bytes");
            return BitConverter.ToUInt64(bytes, 0);
        }

        /// <summary>
        ///     To the u short.
        /// </summary>
        /// <param name="hexString">The hexadecimal string.</param>
        /// <returns>System.UInt16.</returns>
        public static ushort ToUShort(this string hexString)
        {
            return ushort.Parse(hexString, NumberStyles.HexNumber);
        }
    }
}