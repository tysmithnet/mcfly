using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;

namespace McFly.Server.Controllers
{
    [Route("api/note")]
    public class NoteController : Controller
    {
        [HttpPost]
        public ActionResult Post(string projectName, Position position, int threadId, string text)
        {
            
            return Ok();
        }
    }
}
