// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tysmithnet
// Created          : 04-21-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-22-2018
// ***********************************************************************
// <copyright file="MemoryController.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.Composition;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Common.Logging;
using McFly.Server.Core;
using McFly.Server.Data;
using McFly.Server.Headers;

namespace McFly.Server.Controllers
{
    /// <summary>
    ///     Class MemoryController.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [Route("api/memory")]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public sealed class MemoryController : ApiController
    {
        /// <summary>
        ///     The log
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger<MemoryController>();

        /// <summary>
        ///     Adds raw memory to the analysis
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="request">The request.</param>
        /// <returns>IHttpActionResult.</returns>
        public IHttpActionResult Post([FromProjectNameHeader] string projectName, [FromBody] AddMemoryRequest request)
        {
            MemoryAccess.AddMemory(projectName, request.MemoryChunk); // todo: errors
            return Ok();
        }

        /// <summary>
        ///     Gets or sets the memory access.
        /// </summary>
        /// <value>The memory access.</value>
        [Import]
        internal IMemoryAccess MemoryAccess { get; set; }
    }
}