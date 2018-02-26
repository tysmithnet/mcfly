using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using McFly.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace McFly.Server.Controllers
{
    [Route("api/project")]
    public class ProjectsController : Controller
    {
        protected IProjectsAccess ProjectsAccess { get; set; }
        private ILogger<ProjectsController> Logger { get; set; }      

        public ProjectsController(ILogger<ProjectsController> logger, IProjectsAccess projectsAccess)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger)); 
            ProjectsAccess = projectsAccess ?? throw new ArgumentNullException(nameof(projectsAccess));
            Logger.LogInformation("ProjectsController created");
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(ProjectsAccess.GetDatabases());
        }

        [HttpPost]
        public ActionResult Post(string projectName, string startFrame, string endFrame)
        {
            ProjectsAccess.CreateProject(projectName, Position.Parse(startFrame), Position.Parse(endFrame));
            return Ok();
        }
    }
}
