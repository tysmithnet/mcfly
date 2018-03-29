// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 03-04-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-24-2018
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
        ///     Interprets the value as a long
        /// </summary>
        /// <param name="ulongValue">The ulong value.</param>
        /// <returns>System.Int64.</returns>
        public static long ToLong(this ulong ulongValue)
        {
            return unchecked((long) ulongValue);
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
        ///     To the u int.
        /// </summary>
        /// <param name="intValue">The int value.</param>
        /// <returns>System.UInt32.</returns>
        public static uint ToUInt(this int intValue)
        {
            return unchecked ((uint) intValue);
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
    }
}