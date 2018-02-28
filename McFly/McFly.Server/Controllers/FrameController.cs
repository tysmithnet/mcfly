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
    [Route("api/frame")]
    public class FrameController : Controller
    {
        protected IFrameAccess FrameAccess { get; set; }
        private ILogger<FrameController> Logger { get; set; }

        public FrameController(ILogger<FrameController> logger, IFrameAccess frameAccess)
        {                           
            FrameAccess = frameAccess;
        }
                                               
        [HttpPost]
        public ActionResult Post(Frame frame)
        {
            FrameAccess.UpsertFrame(frame);
            return Ok();
        }
    }
}
