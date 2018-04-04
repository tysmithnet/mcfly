// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="SearchFilter.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;

namespace McFly.Search
{
    /// <summary>
    /// Class SearchFilter. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="System.IEquatable{McFly.Search.SearchFilter}" />
    public sealed class SearchFilter : IEquatable<SearchFilter>
    {
        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        /// <value>The command.</value>
        public string Command { get; set; }
        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        /// <value>The arguments.</value>
        public IList<string> Args { get; set; } = new List<string>();

        /// <summary>
        /// Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Equals(SearchFilter other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (Args == null && other.Args == null) return true;
            return string.Equals(Command, other.Command) && Args == null
                ? false
                : Args.SequenceEqual(other.Args ?? new string[0]);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is SearchFilter && Equals((SearchFilter) obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((Command != null ? Command.GetHashCode() : 0) * 397) ^ (Args != null ? Args.GetHashCode() : 0);
            }
        }

        /// <summary>
        /// Implements the == operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(SearchFilter left, SearchFilter right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(SearchFilter left, SearchFilter right)
        {
            return !Equals(left, right);
        }
    }
}