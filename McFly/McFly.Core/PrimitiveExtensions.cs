// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 03-04-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-28-2018
// ***********************************************************************
// <copyright file="PrimitiveExtensions.cs" company="McFly.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.Core
{
    /// <summary>
    ///     Extension methods for common primitive conversions
    /// </summary>
    public static class PrimitiveExtensions
    {
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
        ///     Converts the string representation of a number to an integer.
        /// </summary>
        /// <param name="uintValue">The uint value.</param>
        /// <returns>System.Int32.</returns>
        public static int ToInt(this uint uintValue)
        {
            return unchecked((int) uintValue);
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
        ///     Converts an Int32 to a UInt32
        /// </summary>
        /// <param name="intValue">The int value.</param>
        /// <returns>System.UInt32.</returns>
        public static uint ToUInt(this int intValue)
        {
            return unchecked ((uint) intValue);
        }

        /// <summary>
        ///     Converts an Int32 to a UInt64
        /// </summary>
        /// <param name="intValue">The int value.</param>
        /// <returns>System.UInt64.</returns>
        public static ulong ToULong(this int intValue)
        {
            return (ulong) intValue;
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
    }
}