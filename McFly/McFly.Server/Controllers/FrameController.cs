using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using McFly.Server.Data;
using Microsoft.AspNetCore.Mvc;

namespace McFly.Server.Controllers
{
    [Route("api/frame")]
    public class FrameController : Controller
    {
        private IFrameAccess FrameAccess { get; set; }

        public FrameController(IFrameAccess frameAccess)
        {                           
            FrameAccess = frameAccess;
        }
                                               
        [HttpPost]
        public ActionResult Post(FrameDto frame)
        {
            FrameAccess.UpsertFrame(frame);
            return Ok();
        }
    }
}
