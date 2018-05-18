// ***********************************************************************
// Assembly         : McFly.Server.Core
// Author           : @tysmithnet
// Created          : 04-26-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-26-2018
// ***********************************************************************
// <copyright file="TerminalSearchCriterionDto.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.Server.Core
{
    /// <summary>
    ///     Represents the most basic of criteria you can issue for a search
    /// </summary>
    /// <seealso cref="McFly.Server.Core.SearchCriterionDto" />
    public sealed class TerminalSearchCriterionDto : SearchCriterionDto
    {
        /// <summary>
        ///     Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns>System.Object.</returns>
        public override object Accept(ISearchRequestVisitor visitor)
        {
            return visitor.Visit(this);
        }

        /// <summary>
        ///     Gets or sets the arguments.
        /// </summary>
        /// <value>The arguments.</value>
        public string[] Args { get; set; }
    }
}