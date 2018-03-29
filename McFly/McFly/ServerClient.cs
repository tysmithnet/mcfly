// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 03-02-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-24-2018
// ***********************************************************************
// <copyright file="ServerClient.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Net.Http;
using McFly.Core;
using McFly.Server.Contract;

namespace McFly
{
    /// <summary>
    ///     Class ServerClient.
    /// </summary>
    /// <seealso cref="McFly.IServerClient" />
    /// <seealso cref="System.IDisposable" />
    [Export(typeof(IServerClient))]
    public class ServerClient : IServerClient  // todo: move to McFly.Server
    {
        /// <summary>
        ///     Gets or sets the HTTP facade.
        /// </summary>
        /// <value>The HTTP facade.</value>
        [Import]
        protected internal IHttpFacade HttpFacade { get; set; }

        /// <summary>
        ///     Gets or sets the settings.
        /// </summary>
        /// <value>The settings.</value>
        [Import]
        protected internal Settings Settings { get; set; }

        /// <summary>
        ///     Upserts the frames.
        /// </summary>
        /// <param name="frames">The frames.</param>
        /// <returns>Task.</returns>
        public void UpsertFrames(IEnumerable<Frame> frames)
        {
            var ub = new UriBuilder(Settings.ServerUrl) {Path = $"api/frame"};
            var headers = new HttpHeaders
            {
                ["X-Project-Name"] = Settings.ProjectName
            };
            HttpFacade.PostJsonAsync(ub.Uri, frames, headers).GetAwaiter().GetResult();
        }
            
        public void AddNote(Position position, int? threadId, string text)
        {
            var ub = new UriBuilder(Settings.ServerUrl) { Path = $"api/note" };
            var addNoteRequest = new AddNoteRequest(position, threadId, text);
            var headers = new HttpHeaders
            {
                ["X-Project-Name"] = Settings.ProjectName
            };
            HttpFacade.PostJsonAsync(ub.Uri, addNoteRequest, headers).GetAwaiter().GetResult();
        }

        public void InitializeProject(string projectName, Position start, Position end)
        {
            var ub = new UriBuilder(Settings.ServerUrl) {Path = $"api/project"};
            var request = new NewProjectRequest(projectName, start.ToString(), end.ToString());
            HttpFacade.PostJsonAsync(ub.Uri, request, null).GetAwaiter().GetResult();
        }
    }
}