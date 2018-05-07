// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 05-01-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 05-01-2018
// ***********************************************************************
// <copyright file="RecentTagsRequest.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace McFly.Server.Contract
{
    // todo: add more functionality here.. maybe date override or something
    /// <summary>
    ///     Request for recently created tags
    /// </summary>
    public class RecentTagsRequest : IEquatable<RecentTagsRequest>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RecentTagsRequest" /> class.
        /// </summary>
        /// <param name="numItems">The number items.</param>
        /// <exception cref="ArgumentOutOfRangeException">numItems</exception>
        public RecentTagsRequest(int numItems = 10)
        {
            if (numItems < 0)
                throw new ArgumentOutOfRangeException(nameof(numItems),
                    $"Value cannot be negative, but found {numItems}");
            NumItems = numItems;
        }

        /// <summary>
        ///     Gets or sets the number items.
        /// </summary>
        /// <value>The number items.</value>
        public int NumItems { get; set; }

        /// <inheritdoc />
        public bool Equals(RecentTagsRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return NumItems == other.NumItems;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RecentTagsRequest) obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return NumItems;
        }
    }
}