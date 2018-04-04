using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Web.Http;
using McFly.Core;
using McFly.Server.Contract;
using McFly.Server.Data;
using McFly.Server.Headers;
using McFly.Server.Search;

namespace McFly.Server.Controllers
{
    [RoutePrefix("api/search")]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SearchController : ApiController
    {
        [Import]
        protected internal IFrameAccess FrameAccess { get; set; }

        [Import]
        internal ISearchCriterionConversionFacade ConversionFacade { get; set; }

        [Route("{index}")]
        public IHttpActionResult Post([FromProjectNameHeader] string projectName, [FromUri] string index,
            [FromBody] SearchCriterionDto searchCriterionDto) // todo: add paging headers
        {
            object results = null;
            switch (index.ToLower())
            {
                case "frame":
                    results = SearchFrames(projectName, searchCriterionDto);
                    break;
                default:
                    throw new IndexOutOfRangeException($"Uncrecognized index: {index}");
            }

            return Ok(results);
        }

        internal IEnumerable<Frame> SearchFrames(string projectName, SearchCriterionDto searchCriterionDto)
        {
            var searchCriteria = ConversionFacade.Convert(searchCriterionDto);
            var results = FrameAccess.Search(projectName, searchCriteria);
            return results;
        }
    }
}