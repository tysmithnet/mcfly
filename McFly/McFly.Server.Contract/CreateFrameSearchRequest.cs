using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McFly.Server.Contract
{
    public class CreateFrameSearchRequest // todo: make consistent with other types
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Equation { get; set; }
        public SearchTerm[] SearchTerms { get; set; }
    }

    public class SearchTerm
    {
        public string Subject { get; set; }
        public string Predicate { get; set; }
        public string Object { get; set; }
    }

}
