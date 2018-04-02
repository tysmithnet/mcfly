using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McFly.Server.Contract
{
    public class SearchCriterionDto
    {
        public string Type { get; set; }
        public SearchCriterionDto[] SubSearchCriteriaDto { get; set; }

        public virtual object Accept(ISearchRequestVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class TerminalSearchCriterionDto : SearchCriterionDto
    {
        public string Expression { get; set; }

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
