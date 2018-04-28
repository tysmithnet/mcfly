// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-27-2018
// ***********************************************************************
// <copyright file="RegisterEqualsCriterion.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using McFly.Core.Registers;

namespace McFly.Server.Data.Search
{
    /// <summary>
    ///     Criterion that resolves whether a register is equal to a certain value
    /// </summary>
    /// <seealso cref="McFly.Server.Data.Search.RegisterCriterion" />
    public class RegisterEqualsCriterion : RegisterCriterion
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RegisterEqualsCriterion" /> class.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <param name="hexString">The hexadecimal string.</param>
        public RegisterEqualsCriterion(Register register, string hexString) : base(register)
        {
            HexString = hexString;
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
        ///     Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public string HexString { get; }
    }
}