// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 04-28-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-28-2018
// ***********************************************************************
// <copyright file="ByteArrayExtensions.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace McFly.Core
{
    /// <summary>
    ///     Extension methods to convert byte arrays to types
    /// </summary>
    public static class ByteArrayExtensions
    {
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
        ///     To the byte array.
        /// </summary>
        /// <param name="shortValue">The short value.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] ToByteArray(this short shortValue)
        {
            return BitConverter.GetBytes(shortValue);
        }

        /// <summary>
        ///     To the byte array.
        /// </summary>
        /// <param name="ushortValue">The ushort value.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] ToByteArray(this ushort ushortValue)
        {
            return BitConverter.GetBytes(ushortValue);
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
        ///     Converts bytes to an Int64
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
        ///     Converts a byte array to an Int16
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.Int16.</returns>
        /// <exception cref="ArgumentNullException">bytes</exception>
        /// <exception cref="ArgumentOutOfRangeException">bytes</exception>
        /// <example>"cdab" =&gt; 0xabcd</example>
        public static short ToShort(this byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));
            if (bytes.Length != 2)
                throw new ArgumentOutOfRangeException(nameof(bytes),
                    $"Must have exactly 2 bytes but found ${bytes.Length} bytes");
            return BitConverter.ToInt16(bytes, 0);
        }

        /// <summary>
        ///     Converts bytes to a UInt32
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
        ///     Converts bytes to a UInt64
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
        ///     Converts a byte array to UInt16
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.UInt16.</returns>
        /// <exception cref="ArgumentNullException">bytes</exception>
        /// <exception cref="ArgumentOutOfRangeException">bytes</exception>
        public static ushort ToUShort(this byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));
            if (bytes.Length != 2)
                throw new ArgumentOutOfRangeException(nameof(bytes),
                    $"Must have exactly 2 bytes, but had {bytes.Length} bytes");
            return BitConverter.ToUInt16(bytes, 0);
        }
    }
}