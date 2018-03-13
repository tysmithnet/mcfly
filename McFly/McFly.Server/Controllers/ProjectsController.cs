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
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using McFly.Core;
using McFly.Server.Data;
using Microsoft.Extensions.Logging;

namespace McFly.Server.Controllers
{
    /// <summary>
    ///     Class ProjectsController.
    /// </summary>
    /// <seealso cref="Controller" />
    [System.Web.Mvc.Route("api/project")]
    public class ProjectsController : ApiController
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
        [System.Web.Mvc.HttpPost]
        public IHttpActionResult Post(string projectName, string startingPosition, string endingPosition)
        {
            ProjectsAccess.CreateProject(projectName, Position.Parse(startingPosition), Position.Parse(endingPosition));
            return Ok();
        }
    }
}