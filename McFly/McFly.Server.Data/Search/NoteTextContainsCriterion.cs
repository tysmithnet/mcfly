// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="NoteTextContainsCriterion.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace McFly.Server.Data.Search
{
    /// <summary>
    ///     Class NoteTextContainsCriterion.
    /// </summary>
    /// <seealso cref="McFly.Server.Data.Search.NoteCriterion" />
    public class NoteTextContainsCriterion : NoteCriterion
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NoteTextContainsCriterion" /> class.
        /// </summary>
        /// <param name="substring">The substring.</param>
        /// <exception cref="ArgumentNullException">substring</exception>
        public NoteTextContainsCriterion(string substring)
        {
            Substring = substring ?? throw new ArgumentNullException(nameof(substring));
        }

        /// <summary>
        ///     Gets the substring.
        /// </summary>
        /// <value>The substring.</value>
        public string Substring { get; }

        /// <summary>
        ///     Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns>System.Object.</returns>
        public override object Accept(ICriterionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}