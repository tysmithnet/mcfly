// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tysmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-26-2018
// ***********************************************************************
// <copyright file="ProjectsController.cs" company="McFly.Server">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Web.Http;
using System.Web.Http.Results;
using Common.Logging;
using McFly.Core;
using McFly.Server.Core;
using McFly.Server.Data;

namespace McFly.Server.Controllers
{
    /// <summary>
    ///     Represents the business logic for the project api
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    /// <seealso cref="Controller" />
    [Export]
    [Route("api/project")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public sealed class ProjectController : ApiController
    {
        /// <summary>
        ///     The log
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger<ProjectController>();

        /// <summary>
        ///     Gets this instance.
        /// </summary>
        /// <returns>JsonResult.</returns>
        [HttpGet]
        public JsonResult<IEnumerable<string>> Get()
        {
            var j = Json(ProjectsAccess.GetProjects());
            return j;
        }

        /// <summary>
        ///     Creates a new project
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public IHttpActionResult Post([FromBody] NewProjectRequest request)
        {
            ProjectsAccess.CreateProject(request.ProjectName, Position.Parse(request.StartingPosition),
                Position.Parse(request.EndingPosition));
            return Ok();
        }

        /// <summary>
        ///     Gets or sets the projects access.
        /// </summary>
        /// <value>The projects access.</value>
        [Import]
        internal IProjectsAccess ProjectsAccess { get; set; }
    }
}