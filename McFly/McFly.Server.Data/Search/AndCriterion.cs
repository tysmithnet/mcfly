// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="AndCriterion.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;

namespace McFly.Server.Data.Search
{
    /// <summary>
    ///     Class AndCriterion. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="McFly.Server.Data.Search.ICriterion" />
    public sealed class AndCriterion : ICriterion
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AndCriterion" /> class.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <exception cref="ArgumentNullException">criteria</exception>
        public AndCriterion(IEnumerable<ICriterion> criteria)
        {
            Criteria = criteria?.ToList() ?? throw new ArgumentNullException(nameof(criteria));
        }

        /// <summary>
        ///     Gets the criteria.
        /// </summary>
        /// <value>The criteria.</value>
        public IEnumerable<ICriterion> Criteria { get; }

        /// <summary>
        ///     Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns>System.Object.</returns>
        public object Accept(ICriterionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}