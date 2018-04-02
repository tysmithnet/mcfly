using System.ComponentModel.Composition;
using System.Web.Http;
using McFly.Server.Contract;
using McFly.Server.Data;
using McFly.Server.Headers;
using McFly.Server.Search;

namespace McFly.Server.Controllers
{
    [RoutePrefix("api/search")]
    public class SearchController : ApiController
    {
        [Import]
        protected internal IFrameAccess FrameAccess { get; set; }

        [Import]
        internal ISearchCriterionConversionFacade ConversionFacade { get; set; }

        [Route("{index}")]
        public IHttpActionResult Post([FromProjectNameHeader] string projectName, [FromUri] string index,
            [FromBody] SearchCriterionDto searchCriterionDto)    // todo: add paging headers
        {
            var searchCriteria = ConversionFacade.Convert(searchCriterionDto);
            var results = FrameAccess.Search(projectName, searchCriteria);
            return Ok(results);
        }
    }
}