// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-26-2018
// ***********************************************************************
// <copyright file="TagTextContainsCriterion.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace McFly.Server.Data.Search
{
    /// <summary>
    ///     Search criterion for tags that contain some substring
    /// </summary>
    /// <seealso cref="TagCriterion" />
    public sealed class TagTextContainsCriterion : TagCriterion
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TagTextContainsCriterion" /> class.
        /// </summary>
        /// <param name="substring">The substring to look for.</param>
        /// <exception cref="ArgumentNullException">substring</exception>
        public TagTextContainsCriterion(string substring)
        {
            Substring = substring ?? throw new ArgumentNullException(nameof(substring));
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
        ///     The text to look for
        /// </summary>
        /// <value>The substring.</value>
        public string Substring { get; }
    }
}