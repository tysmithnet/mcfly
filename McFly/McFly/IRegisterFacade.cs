// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-18-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-26-2018
// ***********************************************************************
// <copyright file="IRegisterFacade.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using McFly.Core;
using McFly.Core.Registers;

namespace McFly
{
    /// <summary>
    ///     Facade over getting registry values
    /// </summary>
    /// <seealso cref="McFly.IInjectable" />
    public interface IRegisterFacade : IInjectable
    {
        /// <summary>
        ///     Gets the registers values
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="registers">The registers.</param>
        /// <returns>RegisterSet.</returns>
        RegisterSet GetCurrentRegisterSet(int threadId, IEnumerable<Register> registers);

        /// <summary>
        ///     Get the register values for the current thread
        /// </summary>
        /// <param name="registers">The registers.</param>
        /// <returns>RegisterSet.</returns>
        RegisterSet GetCurrentRegisterSet(IEnumerable<Register> registers);
    }
}