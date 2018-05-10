// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="SearchController.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Web.Http;
using McFly.Core;
using McFly.Server.Core;
using McFly.Server.Data;
using McFly.Server.Headers;
using McFly.Server.Search;

namespace McFly.Server.Controllers
{
    /// <summary>
    ///     Class SearchController.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [RoutePrefix("api/search")]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public sealed class SearchController : ApiController
    {
        /// <summary>
        ///     Gets or sets the frame access.
        /// </summary>
        /// <value>The frame access.</value>
        [Import]
        internal IFrameAccess FrameAccess { get; set; }

        /// <summary>
        ///     Gets or sets the conversion facade.
        /// </summary>
        /// <value>The conversion facade.</value>
        [Import]
        internal ISearchCriterionConversionFacade ConversionFacade { get; set; }

        /// <summary>
        ///     Searches the requested indices for results that match the query
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="index">The index.</param>
        /// <param name="searchCriterionDto">The search criterion dto.</param>
        /// <returns>IHttpActionResult.</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        [Route("{index}")]
        public IHttpActionResult Post([FromProjectNameHeader] string projectName, [FromUri] string index,
            [FromBody] SearchCriterionDto searchCriterionDto) // todo: add paging headers
        {
            object results = null;
            switch (index.ToLower())
            {
                case "frame":
                    results = SearchFrames(projectName, searchCriterionDto); // todo: add the others
                    break;
                default:
                    throw new IndexOutOfRangeException($"Uncrecognized index: {index}");
            }

            return Ok(results);
        }

        /// <summary>
        ///     Searches frames for the request criteria
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="searchCriterionDto">The search criterion dto.</param>
        /// <returns>IEnumerable&lt;Frame&gt;.</returns>
        internal IEnumerable<Frame> SearchFrames(string projectName, SearchCriterionDto searchCriterionDto)
        {
            var searchCriteria = ConversionFacade.Convert(searchCriterionDto);
            var results = FrameAccess.Search(projectName, searchCriteria);
            return results;
        }
    }
}