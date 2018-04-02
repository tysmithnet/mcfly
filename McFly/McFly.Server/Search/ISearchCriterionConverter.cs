using McFly.Server.Contract;
using McFly.Server.Data.Search;

namespace McFly.Server.Search
{
    internal interface ISearchCriterionConverter
    {
        bool CanConvert(SearchCriterionDto conversionType);
        ICriterion Convert(SearchCriterionDto searchCriterionDto);
    }
}