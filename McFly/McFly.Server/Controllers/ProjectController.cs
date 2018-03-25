// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tsmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-16-2018
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
using McFly.Core;
using McFly.Server.Data;

namespace McFly.Server.Controllers
{
    /// <summary>
    ///     Represents the business logic for the project api
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    /// <seealso cref="Controller" />
    [Export(typeof(ProjectController))]
    [Route("api/project")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ProjectController : ApiController
    {
        /// <summary>
        ///     Gets or sets the projects access.
        /// </summary>
        /// <value>The projects access.</value>
        [Import]
        protected internal IProjectsAccess ProjectsAccess { get; set; }

        /// <summary>
        ///     Gets this instance.
        /// </summary>
        /// <returns>JsonResult.</returns>
        [HttpGet]
        public JsonResult<IEnumerable<string>> Get()
        {
            var j = Json(ProjectsAccess.GetDatabases());
            return j;
        }

        /// <summary>
        ///     Creates a new project
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public IHttpActionResult Post([FromBody] NewProjectRequestDto request)
        {
            ProjectsAccess.CreateProject(request.ProjectName, Position.Parse(request.StartingPosition),
                Position.Parse(request.EndingPosition));
            return Ok();
        }
    }
}