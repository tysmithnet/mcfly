// ***********************************************************************
// Assembly         : McFly.Server.Test
// Author           : @tysmithnet
// Created          : 03-16-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-16-2018
// ***********************************************************************
// <copyright file="FrameAccessBuilder.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using McFly.Server.Data;
using Moq;

namespace McFly.Server.Test
{
    /// <summary>
    /// Builder for mock frame access
    /// </summary>
    public class FrameAccessBuilder
    {
        /// <summary>
        /// The mock
        /// </summary>
        public Mock<IFrameAccess> Mock = new Mock<IFrameAccess>();

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns>IFrameAccess.</returns>
        public IFrameAccess Build()
        {
            return Mock.Object;
        }
    }
}