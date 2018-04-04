// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 03-26-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="AccessBreakpoint.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace McFly
{
    /// <summary>
    ///     Class AccessBreakpoint.
    /// </summary>
    /// <seealso cref="AccessBreakpoint" />
    /// <seealso cref="McFly.IBreakpoint" />
    /// <seealso cref="System.IEquatable{AccessBreakpoint}" />
    public class AccessBreakpoint : IEquatable<AccessBreakpoint>, IBreakpoint
    {
        /// <summary>
        ///     The valid length
        /// </summary>
        private static readonly uint[] _validLength = {1, 2, 4, 8};

        /// <summary>
        ///     Initializes a new instance of the <see cref="AccessBreakpoint" /> class.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="length">The length.</param>
        /// <param name="isRead">if set to <c>true</c> [is read].</param>
        /// <param name="isWrite">if set to <c>true</c> [is write].</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     address
        ///     or
        ///     length
        /// </exception>
        /// <exception cref="ArgumentException">You cannot set an access breakpoint where neither read nor write is set</exception>
        public AccessBreakpoint(ulong address, ushort length, bool isRead = true, bool isWrite = true)
        {
            Address = address;
            Length = length;
            IsRead = isRead;
            IsWrite = isWrite;
            if (address % 8 != 0)
                throw new ArgumentOutOfRangeException(nameof(address), $"Address must be aligned... x % 8 == 0");
            if (!_validLength.Contains(length))
                throw new ArgumentOutOfRangeException(nameof(length), $"Length must be 1,2,4, or 8");
            if (!isRead && !isWrite)
                throw new ArgumentException("You cannot set an access breakpoint where neither read nor write is set");
        }

        /// <summary>
        ///     Gets the address.
        /// </summary>
        /// <value>The address.</value>
        public ulong Address { get; }

        /// <summary>
        ///     Gets the length.
        /// </summary>
        /// <value>The length.</value>
        public ushort Length { get; }

        /// <summary>
        ///     Gets a value indicating whether this instance is read.
        /// </summary>
        /// <value><c>true</c> if this instance is read; otherwise, <c>false</c>.</value>
        public bool IsRead { get; }

        /// <summary>
        ///     Gets a value indicating whether this instance is write.
        /// </summary>
        /// <value><c>true</c> if this instance is write; otherwise, <c>false</c>.</value>
        public bool IsWrite { get; }

        /// <summary>
        ///     Sets the breakpoint.
        /// </summary>
        /// <param name="breakpointFacade">The breakpoint facade.</param>
        public void SetBreakpoint(IBreakpointFacade breakpointFacade)
        {
            if (IsRead)
                breakpointFacade.SetReadAccessBreakpoint(Length, Address);
            if (IsWrite)
                breakpointFacade.SetWriteAccessBreakpoint(Length, Address);
        }

        /// <summary>
        ///     Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Equals(AccessBreakpoint other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Address == other.Address && Length == other.Length && IsRead == other.IsRead &&
                   IsWrite == other.IsWrite;
        }

        /// <summary>
        ///     To the command.
        /// </summary>
        /// <returns>System.String.</returns>
        public string ToCommand()
        {
            return $"";
        }

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((AccessBreakpoint) obj);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Address.GetHashCode();
                hashCode = (hashCode * 397) ^ Length.GetHashCode();
                hashCode = (hashCode * 397) ^ IsRead.GetHashCode();
                hashCode = (hashCode * 397) ^ IsWrite.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        ///     Implements the == operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(AccessBreakpoint left, AccessBreakpoint right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null)) return false;
            return Equals(left, right);
        }

        /// <summary>
        ///     Implements the != operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(AccessBreakpoint left, AccessBreakpoint right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        ///     Parses the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>AccessBreakpoint.</returns>
        /// <exception cref="ArgumentNullException">input</exception>
        /// <exception cref="FormatException"></exception>
        public static AccessBreakpoint Parse(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            var match = Regex.Match(input, @"(?<acc>[rw]+)(?<l>\d):(?<add>[a-f0-9]+)");
            if (!match.Success)
                throw new FormatException(
                    $"Input was not in the appropriate format.. should be like r8:100, w4:abc, rw8:abc but found: {input}");
            var address = Convert.ToUInt64(match.Groups["add"].Value, 16);
            var length = Convert.ToUInt16(match.Groups["l"].Value, 16);
            var access = match.Groups["acc"].Value;
            var isRead = access.Contains("r");
            var isWrite = access.Contains("w");
            return new AccessBreakpoint(address, length, isRead, isWrite);
        }
    }
}