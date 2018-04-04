using McFly.Server.Contract;
using McFly.Server.Data.Search;

namespace McFly.Server.Search
{
    public interface ISearchCriterionConversionFacade
    {
        ICriterion Convert(SearchCriterionDto searchDto);
    }
}