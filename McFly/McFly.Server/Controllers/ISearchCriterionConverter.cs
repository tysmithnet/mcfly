using McFly.Server.Data.Search;

namespace McFly.Server.Controllers
{
    internal interface ISearchCriterionConverter
    {
        bool CanConvert(string conversionType);
        ICriterion Convert(string conversionType, string input);
    }
}