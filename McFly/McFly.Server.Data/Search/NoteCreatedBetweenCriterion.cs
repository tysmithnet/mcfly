// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-26-2018
// ***********************************************************************
// <copyright file="NoteCreatedBetweenCriterion.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace McFly.Server.Data.Search
{
    /// <summary>
    ///     Search criterion for notes created between two points in time
    /// </summary>
    /// <seealso cref="McFly.Server.Data.Search.NoteCriterion" />
    public class NoteCreatedBetweenCriterion : NoteCriterion // todo: should be the AND of 2 simpler criteria
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NoteCreatedBetweenCriterion" /> class.
        /// </summary>
        /// <param name="low">The low.</param>
        /// <param name="high">The high.</param>
        /// <exception cref="ArgumentOutOfRangeException">Low cannot be after High</exception>
        public NoteCreatedBetweenCriterion(DateTime low, DateTime high)
        {
            if (low > high)
                throw new ArgumentOutOfRangeException("Low cannot be after High");
            Low = low;
            High = high;
        }

        /// <summary>
        ///     Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns>System.Object.</returns>
        public override object Accept(ICriterionVisitor visitor)
        {
            return visitor.Visit(this);
        }

        /// <summary>
        ///     Gets the high.
        /// </summary>
        /// <value>The high.</value>
        public DateTime High { get; }

        /// <summary>
        ///     Gets the low.
        /// </summary>
        /// <value>The low.</value>
        public DateTime Low { get; }
    }
}