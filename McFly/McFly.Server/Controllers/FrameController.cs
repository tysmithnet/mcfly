// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tsmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="FrameController.cs" company="McFly.Server">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using McFly.Core;
using McFly.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace McFly.Server.Controllers
{
    /// <summary>
    ///     Class FrameController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/frame/{projectName}")]
    public class FrameController : Controller
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FrameController" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="frameAccess">The frame access.</param>
        public FrameController(ILogger<FrameController> logger, IFrameAccess frameAccess)
        {
            FrameAccess = frameAccess;
        }

        /// <summary>
        ///     Gets or sets the frame access.
        /// </summary>
        /// <value>The frame access.</value>
        protected IFrameAccess FrameAccess { get; set; }

        /// <summary>
        ///     Gets or sets the logger.
        /// </summary>
        /// <value>The logger.</value>
        private ILogger<FrameController> Logger { get; set; }

        /// <summary>
        ///     Posts the specified project name.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="frames">The frames.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Post(string projectName, [FromBody] IEnumerable<Frame> frames)
        {                                   
            FrameAccess.UpsertFrames(projectName, frames);
            return Ok();
        }
    }
}