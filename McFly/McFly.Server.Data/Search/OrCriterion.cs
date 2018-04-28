// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-26-2018
// ***********************************************************************
// <copyright file="OrCriterion.cs" company="">
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
    ///     Composite search criterion that represents the logical OR of 2 or more more basic search criteria
    /// </summary>
    /// <seealso cref="McFly.Server.Data.Search.ICriterion" />
    public sealed class OrCriterion : ICriterion
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="OrCriterion" /> class.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <exception cref="ArgumentNullException">criteria</exception>
        public OrCriterion(IEnumerable<ICriterion> criteria)
        {
            Criteria = criteria?.ToList() ?? throw new ArgumentNullException(nameof(criteria));
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
        ///     Gets the criteria.
        /// </summary>
        /// <value>The criteria.</value>
        public IEnumerable<ICriterion> Criteria { get; }
    }
}