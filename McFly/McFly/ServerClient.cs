// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 03-02-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-08-2018
// ***********************************************************************
// <copyright file="ServerClient.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using McFly.Core;

namespace McFly
{
    /// <summary>
    ///     Class ServerClient.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    [Export(typeof(IServerClient))]
    public class ServerClient : IServerClient
    {
        [Import]
        protected internal IHttpFacade HttpFacade { get; set; }

        [Import]
        protected internal Settings Settings { get; set; }

        /// <summary>
        ///     Upserts the frames.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="frames">The frames.</param>
        /// <returns>Task.</returns>
        public void UpsertFrames(IEnumerable<Frame> frames)
        {
            var ub = new UriBuilder(Settings.ServerUrl) {Path = $"api/frame/{Settings.ProjectName}"};
            HttpFacade.PostJsonAsync(ub.Uri, frames).GetAwaiter().GetResult();
        }

        public void AddNote(Position position, int threadId, string text)
        {
            var ub = new UriBuilder(Settings.ServerUrl) {Path = $"api/note/{Settings.ProjectName}"};

            var d = new Dictionary<string, string>
            {
                ["projectName"] = Settings.ProjectName,
                ["position"] = position.ToString(),
                ["threadId"] = threadId.ToString(),
                ["text"] = text
            };

            HttpFacade.PostAsync(ub.Uri, d).GetAwaiter().GetResult();
        }

        public void InitializeProject(string projectName, Position start, Position end)
        {
            var ub = new UriBuilder(Settings.ServerUrl) {Path = $"api/project"};
            var d = new Dictionary<string, string>
            {
                ["projectName"] = projectName,
                ["startingPosition"] = start.ToString(),
                ["endingPosition"] = end.ToString()
            };

            HttpFacade.PostAsync(ub.Uri, d).GetAwaiter().GetResult();
        }
    }
}