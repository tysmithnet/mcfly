// ***********************************************************************
// Assembly         : McFly.Tests
// Author           : @tysmithnet
// Created          : 03-18-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-24-2018
// ***********************************************************************
// <copyright file="BreakpointFacadeBuilder.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using Moq;

namespace McFly.Tests
{
    /// <summary>
    ///     Class BreakpointFacadeBuilder.
    /// </summary>
    internal class BreakpointFacadeBuilder
    {
        /// <summary>
        ///     The mock
        /// </summary>
        public Mock<IBreakpointFacade> Mock = new Mock<IBreakpointFacade>();

        /// <summary>
        ///     Builds this instance.
        /// </summary>
        /// <returns>IBreakpointFacade.</returns>
        public IBreakpointFacade Build()
        {
            return Mock.Object;
        }
    }
}