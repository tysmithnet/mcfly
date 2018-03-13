using System.Web.Http;
using McFly.Core;

namespace McFly.Server.Controllers
{
    [Route("api/note")]
    public class NoteController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(string projectName, Position position, int threadId, string text)
        {
            return Ok();
        }
    }
}