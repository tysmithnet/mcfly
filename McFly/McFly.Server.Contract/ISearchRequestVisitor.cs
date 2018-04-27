namespace McFly.Server.Contract
{
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