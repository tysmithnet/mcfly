// ***********************************************************************
// Assembly         : McFly.Server.Test
// Author           : @tysmithnet
// Created          : 03-15-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-24-2018
// ***********************************************************************
// <copyright file="ProjectAccessBuilder.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using McFly.Server.Data;
using Moq;

namespace McFly.Server.Test.Builders
{
    /// <summary>
    ///     Builder for mock project access
    /// </summary>
    public class ProjectAccessBuilder
    {
        /// <summary>
        ///     Gets or sets the mock.
        /// </summary>
        /// <value>The mock.</value>
        internal Mock<IProjectsAccess> Mock { get; set; } = new Mock<IProjectsAccess>();

        /// <summary>
        ///     Whens the get databases.
        /// </summary>
        /// <param name="databases">The databases.</param>
        /// <returns>ProjectAccessBuilder.</returns>
        public ProjectAccessBuilder WhenGetDatabases(IEnumerable<string> databases)
        {
            Mock.Setup(access => access.GetDatabases()).Returns(databases);
            return this;
        }

        /// <summary>
        ///     Builds this instance.
        /// </summary>
        /// <returns>IProjectsAccess.</returns>
        public IProjectsAccess Build()
        {
            return Mock.Object;
        }
    }
}