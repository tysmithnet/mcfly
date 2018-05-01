// ***********************************************************************
// Assembly         : McFly.WinDbg.Test
// Author           : @tysmithnet
// Created          : 05-01-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 05-01-2018
// ***********************************************************************
// <copyright file="DebugDataSpacesBuilder.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using McFly.WinDbg.Debugger;
using Moq;

namespace McFly.WinDbg.Test.Builders
{
    /// <summary>
    ///     Builder class for IDebugDataSpaces
    /// </summary>
    public class DebugDataSpacesBuilder
    {
        /// <summary>
        ///     Builds this instance.
        /// </summary>
        /// <returns>IDebugDataSpaces.</returns>
        public IDebugDataSpaces Build()
        {
            return Mock.Object;
        }

        /// <summary>
        ///     Specifies an HRESULT for the call to ReadVirtual
        /// </summary>
        /// <param name="hr">The hr.</param>
        /// <returns>DebugDataSpacesBuilder.</returns>
        public DebugDataSpacesBuilder WithReadVirtual(int hr)
        {
            uint read;
            Mock.Setup(spaces =>
                spaces.ReadVirtual(It.IsAny<ulong>(), It.IsAny<byte[]>(), It.IsAny<uint>(), out read)).Returns(hr);
            return this;
        }

        /// <summary>
        ///     Gets or sets the mock.
        /// </summary>
        /// <value>The mock.</value>
        public Mock<IDebugDataSpaces> Mock { get; set; } = new Mock<IDebugDataSpaces>();
    }
}