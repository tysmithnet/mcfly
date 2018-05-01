// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 04-29-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-29-2018
// ***********************************************************************
// <copyright file="DomainEntity.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace McFly.Core
{
    /// <summary>
    ///     Base type for all McFly domain entities
    /// </summary>
    /// <remarks>
    ///     Entities are named such after the concept of entity types and value types. Entities
    ///     typically have life times that exist between executions of the application. In this domain, we
    ///     mandate that every such entity has a GUID Id. By default 2 entities are said to be equal if they
    ///     have the same Id. As a convenience all domain entities will also expose the ability to do value-type
    ///     equality which will return true if both objects have the same values for each of their members.
    /// </remarks>
    /// <typeparam name="TSelf">The type inheriting from this class</typeparam>
    /// <seealso cref="System.IEquatable{McFly.Core.DomainEntity{TSelf}}" />
    public abstract class DomainEntity<TSelf> : IEquatable<DomainEntity<TSelf>>
    {
        /// <summary>
        ///     Determines whether this instance is equal to the other
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns><c>true</c> if this instance is equal to the other, <c>false</c> otherwise.</returns>
        /// <inheritdoc />
        public virtual bool Equals(DomainEntity<TSelf> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id.Equals(other.Id);
        }

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((DomainEntity<TSelf>) obj);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        ///     Determines if this instance is value-type equal with another instance.
        /// </summary>
        /// <param name="other">The other instance.</param>
        /// <returns><c>true</c> if this instance is value-type equal with the other instance, <c>false</c> otherwise.</returns>
        /// <remarks>Typically this is a field by field equality operation, but does NOT consider the ID</remarks>
        public abstract bool ValueEquals(TSelf other);

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets a value indicating whether this instance is identifier set.
        /// </summary>
        /// <value><c>true</c> if this instance is identifier set; otherwise, <c>false</c>.</value>
        public virtual bool IsIdSet => Id != Guid.Empty;
    }
}