// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tysmithnet
// Created          : 03-12-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-28-2018
// ***********************************************************************
// <copyright file="NoteController.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.Composition;
using System.Web.Http;
using McFly.Core;
using McFly.Server.Contract;
using McFly.Server.Data;
using McFly.Server.Headers;

namespace McFly.Server.Controllers
{
    /// <summary>
    ///     Represents the business logic for the note api
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [Route("api/note")]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class NoteController : ApiController
    {
        /// <summary>
        ///     Gets or sets the note access.
        /// </summary>
        /// <value>The note access.</value>
        [Import]
        protected internal INoteAccess NoteAccess { get; set; }

        /// <summary>
        ///     Adds a note to a project at a specified position for a thread
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="position">The position.</param>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="text">The text.</param>
        /// <returns>IHttpActionResult.</returns>
        [HttpPost]
        public IHttpActionResult Post([FromProjectNameHeader] string projectName, [FromBody]AddNoteRequest request)
        {
            NoteAccess.AddNote(projectName, request.Position, request.ThreadIds, request.Text);
            return Ok();
        }
    }
}