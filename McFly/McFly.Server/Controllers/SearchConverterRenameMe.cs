using System;
using McFly.Server.Contract;
using McFly.Server.Data.Search;

namespace McFly.Server.Controllers
{
    internal static class SearchConverterRenameMe
    {
        public static ICriterion ToSearchCriteria(this SearchCriterionDto crit)
        {
            return new NoteCreatedAfterCriterion(DateTime.MaxValue);
        }
    }
}