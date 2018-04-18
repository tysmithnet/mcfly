// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-15-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="IServerClient.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using McFly.Core;
using McFly.Server.Contract;

namespace McFly
{
    /// <summary>
    ///     Interface IServerClient
    /// </summary>
    /// <seealso cref="McFly.IInjectable" />
    public interface IServerClient : IInjectable // todo: break up into cohesive types
    {
        /// <summary>
        ///     Adds the note.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="threadIds">The thread ids.</param>
        /// <param name="text">The text.</param>
        void AddNote(Position position, IEnumerable<int> threadIds, string text);

        /// <summary>
        ///     Initializes the project.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        void InitializeProject(string projectName, Position start, Position end);

        /// <summary>
        ///     Upserts the frames.
        /// </summary>
        /// <param name="frames">The frames.</param>
        void UpsertFrames(IEnumerable<Frame> frames);

        /// <summary>
        ///     Searches the frames.
        /// </summary>
        /// <param name="converted">The converted.</param>
        /// <returns>IEnumerable&lt;Frame&gt;.</returns>
        IEnumerable<Frame> SearchFrames(SearchCriterionDto converted);
    }
}