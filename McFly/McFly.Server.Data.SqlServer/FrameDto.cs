// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tysmithnet
// Created          : 03-14-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-16-2018
// ***********************************************************************
// <copyright file="FrameDto.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Data;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     A dto for frame access
    /// </summary>
    public class FrameDto
    {
        /// <summary>
        ///     Gets or sets the frames.
        /// </summary>
        /// <value>The frames.</value>
        public DataTable Frames { get; set; }

        /// <summary>
        ///     Gets or sets the stack frames.
        /// </summary>
        /// <value>The stack frames.</value>
        public DataTable StackFrames { get; set; }
    }
}