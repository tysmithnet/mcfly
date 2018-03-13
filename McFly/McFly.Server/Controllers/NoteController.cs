using System;
using System.Web.Http.Results;
using System.Web.Mvc;
using McFly.Core;

namespace McFly.Server.Controllers
{
    [Route("api/note")]
    public class NoteController : Controller
    {
        [HttpPost]
        public ActionResult Post(string projectName, Position position, int threadId, string text)
        {
            return Content("OK");
        }
    }
}
