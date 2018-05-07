// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tysmithnet
// Created          : 03-12-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-26-2018
// ***********************************************************************
// <copyright file="TagController.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.Composition;
using System.Web.Http;
using Common.Logging;
using McFly.Server.Contract;
using McFly.Server.Data;
using McFly.Server.Headers;

namespace McFly.Server.Controllers
{
    /// <summary>
    ///     Represents the business logic for the tag api
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [Route("api/tag")]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TagController : ApiController
    {
        /// <summary>
        ///     The log
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger<TagController>();

        /// <summary>
        ///     Adds a tag to a project at a specified position for a thread
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="request">The request.</param>
        /// <returns>IHttpActionResult.</returns>
        [HttpPost]
        public IHttpActionResult Post([FromProjectNameHeader] string projectName, [FromBody] AddTagRequest request)
        {
            TagAccess.AddTag(projectName, request.Position, request.ThreadIds, request.Tag);
            return Ok();
        }

        /// <summary>
        ///     Gets or sets the tag access.
        /// </summary>
        /// <value>The tag access.</value>
        [Import]
        protected internal ITagAccess TagAccess { get; set; }
    }
}