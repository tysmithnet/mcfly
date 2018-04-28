// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="RegisterBetweenCriterion.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using McFly.Core;
using McFly.Core.Registers;

namespace McFly.Server.Data.Search
{
    /// <summary>
    ///     Criterion for a register value falling between 2 numbers
    /// </summary>
    /// <seealso cref="McFly.Server.Data.Search.RegisterCriterion" />
    public sealed class RegisterBetweenCriterion : RegisterCriterion
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RegisterBetweenCriterion" /> class.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <param name="low">The low.</param>
        /// <param name="high">The high.</param>
        /// <exception cref="IndexOutOfRangeException">Low cannot be bigger than High</exception>
        public RegisterBetweenCriterion(Register register, string low, string high) : base(register)
        {
            if (string.Compare(high, low, StringComparison.Ordinal) < 0)
                throw new IndexOutOfRangeException("Low cannot be bigger than High");
            Low = low;
            High = high;
        }

        /// <summary>
        ///     Gets the low end.
        /// </summary>
        /// <value>The low.</value>
        public string Low { get; }

        /// <summary>
        ///     Gets the high end (non inclusive).
        /// </summary>
        /// <value>The high.</value>
        public string High { get; } // todo: bound checking

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