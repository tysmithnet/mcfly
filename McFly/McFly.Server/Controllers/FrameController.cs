using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using McFly.Core;
using McFly.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace McFly.Server.Controllers
{
    [Route("api/frame/{projectName}")]
    public class FrameController : Controller
    {
        protected IFrameAccess FrameAccess { get; set; }
        private ILogger<FrameController> Logger { get; set; }

        public FrameController(ILogger<FrameController> logger, IFrameAccess frameAccess)
        {                           
            FrameAccess = frameAccess;
        }
                                               
        [HttpPost]
        public ActionResult Post(string projectName, [FromBody]IEnumerable<Frame> frames)
        {
            foreach (var frame in frames)
            {
                FrameAccess.UpsertFrame(projectName, frame); // todo: make bulk upsert
            }
            return Ok();
        }
    }
}
