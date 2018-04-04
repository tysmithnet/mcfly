// ***********************************************************************
// Assembly         : McFly.Tests
// Author           : @tysmithnet
// Created          : 03-18-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="BreakpointFacadeBuilder.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using Moq;

namespace McFly.Tests.Builders
{
    /// <summary>
    /// Class BreakpointFacadeBuilder.
    /// </summary>
    internal class BreakpointFacadeBuilder
    {
        /// <summary>
        /// The mock
        /// </summary>
        public Mock<IBreakpointFacade> Mock = new Mock<IBreakpointFacade>();

        /// <summary>
        /// Withes the set breakpoint by mask.
        /// </summary>
        /// <param name="mask">The mask.</param>
        /// <param name="function">The function.</param>
        /// <returns>BreakpointFacadeBuilder.</returns>
        public BreakpointFacadeBuilder WithSetBreakpointByMask(string mask, string function)
        {
            Mock.Setup(facade => facade.SetBreakpointByMask(mask, function));
            return this;
        }

        /// <summary>
        /// Withes the set breakpoint by mask.
        /// </summary>
        /// <returns>BreakpointFacadeBuilder.</returns>
        public BreakpointFacadeBuilder WithSetBreakpointByMask()
        {
            Mock.Setup(facade => facade.SetBreakpointByMask(It.IsAny<string>(), It.IsAny<string>()));
            return this;
        }

        /// <summary>
        /// Withes the set read access breakpoint.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <param name="address">The address.</param>
        /// <returns>BreakpointFacadeBuilder.</returns>
        public BreakpointFacadeBuilder WithSetReadAccessBreakpoint(int length, ulong address)
        {
            Mock.Setup(facade => facade.SetReadAccessBreakpoint(length, address));
            return this;
        }

        /// <summary>
        /// Withes the set read access breakpoint.
        /// </summary>
        /// <returns>BreakpointFacadeBuilder.</returns>
        public BreakpointFacadeBuilder WithSetReadAccessBreakpoint()
        {
            Mock.Setup(facade => facade.SetReadAccessBreakpoint(It.IsAny<int>(), It.IsAny<ulong>()));
            return this;
        }

        /// <summary>
        /// Withes the set write access breakpoint.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <param name="address">The address.</param>
        /// <returns>BreakpointFacadeBuilder.</returns>
        public BreakpointFacadeBuilder WithSetWriteAccessBreakpoint(int length, ulong address)
        {
            Mock.Setup(facade => facade.SetWriteAccessBreakpoint(length, address));
            return this;
        }

        /// <summary>
        /// Withes the set write access breakpoint.
        /// </summary>
        /// <returns>BreakpointFacadeBuilder.</returns>
        public BreakpointFacadeBuilder WithSetWriteAccessBreakpoint()
        {
            Mock.Setup(facade => facade.SetWriteAccessBreakpoint(It.IsAny<int>(), It.IsAny<ulong>()));
            return this;
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns>IBreakpointFacade.</returns>
        public IBreakpointFacade Build()
        {
            return Mock.Object;
        }
    }
}