namespace McFly.Server.Contract
{
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
}