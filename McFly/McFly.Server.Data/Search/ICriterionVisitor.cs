// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-26-2018
// ***********************************************************************
// <copyright file="ICriterionVisitor.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.Server.Data.Search
{
    /// <summary>
    ///     Represents an object capable of visiting types of <see cref="ICriterion" /> and performing
    ///     some useful function
    /// </summary>
    public interface ICriterionVisitor
    {
        object Visit(AndCriterion andCriterion);
        object Visit(NotCriterion notCriterion);
        object Visit(TagCreatedAfterCriterion tagCreatedAfterCriterion);
        object Visit(TagCreatedBeforeCriterion tagCreatedBeforeCriterion);
        object Visit(TagCreatedBetweenCriterion tagCreatedBetweenCriterion);
        object Visit(TagTextContainsCriterion tagTextContainsCriterion);
        object Visit(OrCriterion orCriterion);
        object Visit(RegisterBetweenCriterion registerBetweenCriterion);
        object Visit(RegisterEqualsCriterion registerEqualsCriterion);
        object Visit(RegisterInCriterion registerInCriterion);
    }
}