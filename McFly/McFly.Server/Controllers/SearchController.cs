using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using McFly.Server.Contract;
using McFly.Server.Data.Search;
using McFly.Server.Headers;

namespace McFly.Server.Controllers
{
    [RoutePrefix("api/search")]
    public class SearchController : ApiController
    {
        [Route("{index}")]
        public IHttpActionResult Post([FromProjectNameHeader] string projectName, [FromUri] string index,
            [FromBody] Criterion criterion)
        {

            return Ok();
        }
    }

    internal interface ISearchCriterionConverter
    {
        bool CanConvert(string conversionType);
        ICriterion Convert(string conversionType, string input);
    }

    // todo: add register converter, etc
}
