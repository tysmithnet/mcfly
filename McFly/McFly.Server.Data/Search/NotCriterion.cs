// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-26-2018
// ***********************************************************************
// <copyright file="NotCriterion.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace McFly.Server.Data.Search
{
    /// <summary>
    ///     Represents the logical negation of a search criterion
    /// </summary>
    /// <seealso cref="McFly.Server.Data.Search.ICriterion" />
    public sealed class NotCriterion : ICriterion
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NotCriterion" /> class.
        /// </summary>
        /// <param name="criterion">The criterion.</param>
        /// <exception cref="ArgumentNullException">criterion</exception>
        public NotCriterion(ICriterion criterion)
        {
            Criterion = criterion ?? throw new ArgumentNullException(nameof(criterion));
        }

        /// <summary>
        ///     Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns>System.Object.</returns>
        public object Accept(ICriterionVisitor visitor)
        {
            return visitor.Visit(this);
        }

        /// <summary>
        ///     Gets the criterion.
        /// </summary>
        /// <value>The criterion.</value>
        public ICriterion Criterion { get; }
    }
}