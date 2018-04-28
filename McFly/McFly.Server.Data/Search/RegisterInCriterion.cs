// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-27-2018
// ***********************************************************************
// <copyright file="RegisterInCriterion.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using McFly.Core.Registers;

namespace McFly.Server.Data.Search
{
    /// <summary>
    ///     Register search criterion that resolves when a register is in the provide list
    /// </summary>
    /// <seealso cref="McFly.Server.Data.Search.RegisterCriterion" />
    public class RegisterInCriterion : RegisterCriterion
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RegisterInCriterion" /> class.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <param name="values">The values.</param>
        /// <exception cref="ArgumentNullException">values</exception>
        public RegisterInCriterion(Register register, IEnumerable<ulong> values) : base(register)
        {
            Values = values?.ToList() ?? throw new ArgumentNullException(nameof(values));
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
        ///     Gets the values.
        /// </summary>
        /// <value>The values.</value>
        public IEnumerable<ulong> Values { get; }
    }
}