// ***********************************************************************
// Assembly         : McFly.Tests
// Author           : @tysmithnet
// Created          : 03-18-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-18-2018
// ***********************************************************************
// <copyright file="StackFacadeBuilder.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using McFly.Core;
using McFly.WinDbg;
using Moq;

namespace McFly.Test.Builders
{
    /// <summary>
    ///     Class StackFacadeBuilder.
    /// </summary>
    internal class StackFacadeBuilder
    {
        /// <summary>
        ///     The mock
        /// </summary>
        public Mock<IStackFacade> Mock = new Mock<IStackFacade>();

        /// <summary>
        ///     Builds this instance.
        /// </summary>
        /// <returns>IStackFacade.</returns>
        public IStackFacade Build()
        {
            return Mock.Object;
        }

        /// <summary>
        ///     Withes the get current stack trace.
        /// </summary>
        /// <param name="stackTrace">The stack trace.</param>
        /// <returns>StackFacadeBuilder.</returns>
        public StackFacadeBuilder WithGetCurrentStackTrace(StackTrace stackTrace)
        {
            Mock.Setup(facade => facade.GetCurrentStackTrace()).Returns(stackTrace);
            return this;
        }

        /// <summary>
        ///     Withes the get current stack trace.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="stackTrace">The stack trace.</param>
        /// <returns>StackFacadeBuilder.</returns>
        public StackFacadeBuilder WithGetCurrentStackTrace(int threadId, StackTrace stackTrace)
        {
            Mock.Setup(facade => facade.GetCurrentStackTrace(threadId)).Returns(stackTrace);
            return this;
        }
    }
}