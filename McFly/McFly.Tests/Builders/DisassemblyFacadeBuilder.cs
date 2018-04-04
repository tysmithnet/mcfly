// ***********************************************************************
// Assembly         : McFly.Tests
// Author           : @tysmithnet
// Created          : 03-19-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="DisassemblyFacadeBuilder.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using McFly.Core;
using Moq;

namespace McFly.Tests.Builders
{
    /// <summary>
    /// Class DisassemblyFacadeBuilder.
    /// </summary>
    internal class DisassemblyFacadeBuilder
    {
        /// <summary>
        /// The mock
        /// </summary>
        public Mock<IDisassemblyFacade> Mock = new Mock<IDisassemblyFacade>();

        /// <summary>
        /// Withes the get disassembly lines.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <param name="result">The result.</param>
        /// <returns>DisassemblyFacadeBuilder.</returns>
        public DisassemblyFacadeBuilder WithGetDisassemblyLines(int num, IEnumerable<DisassemblyLine> result)
        {
            Mock.Setup(facade => facade.GetDisassemblyLines(num)).Returns(result);
            return this;
        }

        /// <summary>
        /// Withes the get disassembly lines.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="num">The number.</param>
        /// <param name="result">The result.</param>
        /// <returns>DisassemblyFacadeBuilder.</returns>
        public DisassemblyFacadeBuilder WithGetDisassemblyLines(int threadId, int num,
            IEnumerable<DisassemblyLine> result)
        {
            Mock.Setup(facade => facade.GetDisassemblyLines(threadId, num)).Returns(result);
            return this;
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns>IDisassemblyFacade.</returns>
        public IDisassemblyFacade Build()
        {
            return Mock.Object;
        }
    }
}