using System.ComponentModel.Composition;
using System.Web.Http;
using McFly.Server.Contract;
using McFly.Server.Data;
using McFly.Server.Headers;

namespace McFly.Server.Controllers
{
    [RoutePrefix("api/search")]
    public class SearchController : ApiController
    {
        [Import]
        protected internal IFrameAccess FrameAccess { get; set; }

        [Route("{index}")]
        public IHttpActionResult Post([FromProjectNameHeader] string projectName, [FromUri] string index,
            [FromBody] SearchCriterionDto searchCriterionDto)
        {
            var searchCriteria = searchCriterionDto.ToSearchCriteria();
            var results = FrameAccess.Search(projectName, searchCriteria);
            return Ok(results);
        }
    }
}