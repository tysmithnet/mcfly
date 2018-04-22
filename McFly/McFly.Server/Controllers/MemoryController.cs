using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Common.Logging;
using McFly.Server.Contract;
using McFly.Server.Headers;

namespace McFly.Server.Controllers
{
    [Route("api/memory/")]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MemoryController : ApiController
    {
        private readonly ILog Log = LogManager.GetLogger<MemoryController>();

        

        public IHttpActionResult Post([FromProjectNameHeader] string projectName, [FromBody] AddMemoryRequeset request)
        {

        }
    }
}
