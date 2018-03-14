// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tsmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="ProjectsController.cs" company="McFly.Server">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.Composition;
using System.Web.Http;
using System.Web.Http.Results;
using McFly.Core;
using McFly.Server.Data;

namespace McFly.Server.Controllers
{
    /// <summary>
    ///     Class ProjectsController.
    /// </summary>
    /// <seealso cref="Controller" />
    [Route("api/project")]
    [Export(typeof(ProjectsController))]
    public class ProjectsController : ApiController
    {
        [Import]
        private IProjectsAccess ProjectsAccess { get; set; }

        /// <summary>
        ///     Gets this instance.
        /// </summary>
        /// <returns>JsonResult.</returns>
        [System.Web.Mvc.HttpGet]
        public JsonResult<string> Get()
        {
            return Json("t");
        }

        /// <summary>
        ///     Posts the specified project name.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="startingPosition">The start frame.</param>
        /// <param name="endingPosition">The end frame.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public IHttpActionResult Post(string projectName, string startingPosition, string endingPosition)
        {
            ProjectsAccess.CreateProject(projectName, Position.Parse(startingPosition), Position.Parse(endingPosition));
            return Ok();
        }
    }
}