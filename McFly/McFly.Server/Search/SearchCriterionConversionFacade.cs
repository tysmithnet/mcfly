using System;
using System.ComponentModel.Composition;
using System.Linq;
using McFly.Server.Contract;
using McFly.Server.Data.Search;

namespace McFly.Server.Search
{
    [Export(typeof(ISearchCriterionConversionFacade))]
    public class SearchCriterionConversionFacade : ISearchCriterionConversionFacade
    {
        [ImportMany]
        internal ISearchCriterionConverter[] Converters { get; set; }

        public ICriterion Convert(SearchCriterionDto searchDto)
        {
            var first = Converters.FirstOrDefault(c => c.CanConvert(searchDto));
            if(first == null)
                throw new Exception("aslkasldknasdklnas change me!");

            return first.Convert(searchDto);
        }
    }
}
