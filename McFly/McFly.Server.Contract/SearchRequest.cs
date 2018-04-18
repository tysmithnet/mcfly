// ***********************************************************************
// Assembly         : McFly.Server.Contract
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="SearchRequest.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.Server.Contract
{
    /// <summary>
    ///     Class SearchCriterionDto.
    /// </summary>
    public class SearchCriterionDto
    {
        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the sub criteria.
        /// </summary>
        /// <value>The sub criteria.</value>
        public SearchCriterionDto[] SubCriteria { get; set; }

        /// <summary>
        ///     Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns>System.Object.</returns>
        public virtual object Accept(ISearchRequestVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    /// <summary>
    ///     Class TerminalSearchCriterionDto.
    /// </summary>
    /// <seealso cref="McFly.Server.Contract.SearchCriterionDto" />
    public class TerminalSearchCriterionDto : SearchCriterionDto
    {
        /// <summary>
        ///     Gets or sets the arguments.
        /// </summary>
        /// <value>The arguments.</value>
        public string[] Args { get; set; }

        /// <summary>
        ///     Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns>System.Object.</returns>
        public override object Accept(ISearchRequestVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    /// <summary>
    ///     Interface ISearchRequestVisitor
    /// </summary>
    public interface ISearchRequestVisitor
    {
        /// <summary>
        ///     Visits the specified search criterion dto.
        /// </summary>
        /// <param name="searchCriterionDto">The search criterion dto.</param>
        /// <returns>System.Object.</returns>
        object Visit(SearchCriterionDto searchCriterionDto);
    }
}