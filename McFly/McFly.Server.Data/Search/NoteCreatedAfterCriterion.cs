// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-26-2018
// ***********************************************************************
// <copyright file="NoteCreatedAfterCriterion.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace McFly.Server.Data.Search
{
    /// <summary>
    ///     Search criterion for notes that were created after a certain point in time
    /// </summary>
    /// <seealso cref="McFly.Server.Data.Search.NoteCriterion" />
    public sealed class NoteCreatedAfterCriterion : NoteCriterion
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NoteCreatedAfterCriterion" /> class.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        public NoteCreatedAfterCriterion(DateTime dateTime)
        {
            DateTime = dateTime;
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
        ///     Gets the date time.
        /// </summary>
        /// <value>The date time.</value>
        public DateTime DateTime { get; }
    }
}