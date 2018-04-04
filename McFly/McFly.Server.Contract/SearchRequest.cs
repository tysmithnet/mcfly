namespace McFly.Server.Contract
{
    public class SearchCriterionDto
    {
        public string Type { get; set; }
        public SearchCriterionDto[] SubCriteria { get; set; }

        public virtual object Accept(ISearchRequestVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class TerminalSearchCriterionDto : SearchCriterionDto
    {
        public string[] Args { get; set; }

        public override object Accept(ISearchRequestVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public interface ISearchRequestVisitor
    {
        object Visit(SearchCriterionDto searchCriterionDto);
    }
}