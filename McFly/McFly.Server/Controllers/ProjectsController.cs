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

using System;
using McFly.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace McFly.Server.Controllers
{
    /// <summary>
    ///     Class ProjectsController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/project")]
    public class ProjectsController : Controller
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ProjectsController" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="projectsAccess">The projects access.</param>
        /// <exception cref="ArgumentNullException">
        ///     logger
        ///     or
        ///     projectsAccess
        /// </exception>
        public ProjectsController(ILogger<ProjectsController> logger, IProjectsAccess projectsAccess)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            ProjectsAccess = projectsAccess ?? throw new ArgumentNullException(nameof(projectsAccess));
            Logger.LogInformation("ProjectsController created");
        }

        /// <summary>
        ///     Gets or sets the projects access.
        /// </summary>
        /// <value>The projects access.</value>
        protected IProjectsAccess ProjectsAccess { get; set; }

        /// <summary>
        ///     Gets the logger.
        /// </summary>
        /// <value>The logger.</value>
        private ILogger<ProjectsController> Logger { get; }

        /// <summary>
        ///     Gets this instance.
        /// </summary>
        /// <returns>JsonResult.</returns>
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(ProjectsAccess.GetDatabases());
        }

        /// <summary>
        ///     Posts the specified project name.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="startFrame">The start frame.</param>
        /// <param name="endFrame">The end frame.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Post(string projectName, string startFrame, string endFrame)
        {
            ProjectsAccess.CreateProject(projectName, Position.Parse(startFrame), Position.Parse(endFrame));
            return Ok();
        }
    }
}