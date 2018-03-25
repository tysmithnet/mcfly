// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tysmithnet
// Created          : 03-12-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-16-2018
// ***********************************************************************
// <copyright file="NoteController.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Web.Http;
using McFly.Core;
using McFly.Server.Headers;

namespace McFly.Server.Controllers
{
    /// <summary>
    ///     Represents the business logic for the note api
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [Route("api/note")]
    public class NoteController : ApiController
    {
        /// <summary>
        ///     Adds a note to a project at a specified position for a thread
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="position">The position.</param>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="text">The text.</param>
        /// <returns>IHttpActionResult.</returns>
        [HttpPost]
        public IHttpActionResult Post([FromProjectNameHeader] string projectName, Position position, int threadId,
            string text)
        {
            return Ok();
        }
    }
}