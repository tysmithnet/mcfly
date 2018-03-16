using System.Web.Http;
using McFly.Core;
using McFly.Server.Headers;

namespace McFly.Server.Controllers
{
    [Route("api/note")]
    public class NoteController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post([FromProjectNameHeader]string projectName, Position position, int threadId, string text)
        {
            return Ok();
        }
    }
}