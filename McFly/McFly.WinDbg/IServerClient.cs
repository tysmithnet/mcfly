// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-15-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 05-01-2018
// ***********************************************************************
// <copyright file="IServerClient.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using McFly.Core;
using McFly.Server.Contract;

namespace McFly.WinDbg
{
    /// <summary>
    ///     Interface for communicating with the remote server
    /// </summary>
    /// <seealso cref="McFly.WinDbg.IInjectable" />
    /// <seealso cref="IInjectable" />
    internal interface IServerClient : IInjectable // todo: break up into cohesive types
    {
        /// <summary>
        ///     Adds a memory chunk to a position
        /// </summary>
        /// <param name="memoryChunk">The memory chunk.</param>
        void AddMemoryRange(MemoryChunk memoryChunk);

        /// <summary>
        ///     Adds a tag to the threads provided at the specified position
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="threadIds">The thread ids.</param>
        /// <param name="text">The text.</param>
        void AddTag(Position position, IEnumerable<int> threadIds, string text);

        /// <summary>
        ///     Gets the most recent tags.
        /// </summary>
        /// <param name="numTags">The number tags.</param>
        /// <returns>IEnumerable&lt;Tag&gt;.</returns>
        IEnumerable<Tag> GetRecentTags(int numTags);

        /// <summary>
        ///     Initializes the project.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        void InitializeProject(string projectName, Position start, Position end);

        /// <summary>
        ///     Searches for frames.
        /// </summary>
        /// <param name="converted">The converted.</param>
        /// <returns>IEnumerable&lt;Frame&gt;.</returns>
        IEnumerable<Frame> SearchFrames(SearchCriterionDto converted);

        /// <summary>
        ///     Upserts frames.
        /// </summary>
        /// <param name="frames">The frames.</param>
        void UpsertFrames(IEnumerable<Frame> frames);
    }
}