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
        [HttpPost]
        public ActionResult Post(Frame frame)
        {
            return Ok();
        }
    }
}
