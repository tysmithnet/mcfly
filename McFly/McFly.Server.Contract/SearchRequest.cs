using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McFly.Server.Contract
{
    public class SearchRequest
    {
        public string Index  { get; set; }
        public Criterion Criterion { get; set; }
    }

    public class Criterion
    {
        public string Type { get; set; }
        public Criterion[] SubCriteria { get; set; }

        public virtual object Accept(ISearchRequestVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class TerminalCriterion : Criterion
    {
        public string Expression { get; set; }

        public override object Accept(ISearchRequestVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public interface ISearchRequestVisitor
    {
        object Visit(Criterion criterion);
    }
}
