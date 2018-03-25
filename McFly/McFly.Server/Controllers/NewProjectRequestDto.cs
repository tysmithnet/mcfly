// ***********************************************************************
// Assembly         : McFly.Server
// Author           : @tysmithnet
// Created          : 03-15-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-15-2018
// ***********************************************************************
// <copyright file="NewProjectRequestDto.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.Server.Controllers
{
    /// <summary>
    ///     Request dto for new projects
    /// </summary>
    public class NewProjectRequestDto
    {
        /// <summary>
        ///     Gets or sets the name of the project.
        /// </summary>
        /// <value>The name of the project.</value>
        public string ProjectName { get; set; }

        /// <summary>
        ///     Gets or sets the starting position.
        /// </summary>
        /// <value>The starting position.</value>
        public string StartingPosition { get; set; }

        /// <summary>
        ///     Gets or sets the ending position.
        /// </summary>
        /// <value>The ending position.</value>
        public string EndingPosition { get; set; }
    }
}