// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="RegisterCriterion.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using McFly.Core;

namespace McFly.Server.Data.Search
{
    /// <summary>
    ///     Class RegisterCriterion.
    /// </summary>
    /// <seealso cref="McFly.Server.Data.Search.ICriterion" />
    public abstract class RegisterCriterion : ICriterion
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RegisterCriterion" /> class.
        /// </summary>
        /// <param name="register">The register.</param>
        protected RegisterCriterion(Register register)
        {
            Register = register;
        }

        /// <summary>
        ///     Gets or sets the register.
        /// </summary>
        /// <value>The register.</value>
        public Register Register { get; set; }

        /// <summary>
        ///     Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns>System.Object.</returns>
        public abstract object Accept(ICriterionVisitor visitor);
    }
}