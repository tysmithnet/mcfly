using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using McFly.Server.Data;
using Microsoft.AspNetCore.Mvc;

namespace McFly.Server.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : Controller
    {
        protected IProjectsAccess ProjectsAccess { get; set; }

        public ProjectsController(IProjectsAccess projectsAccess)
        {
            ProjectsAccess = projectsAccess ?? throw new ArgumentNullException(nameof(projectsAccess));
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(ProjectsAccess.GetDatabases());
        }

        //[HttpPost]
        //public ActionResult Post(string projectName)
        //{
        //    ProjectsAccess.CreateProject(projectName);
        //    return Ok();
        //}
    }
}
