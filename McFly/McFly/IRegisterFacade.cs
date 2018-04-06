// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-18-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
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
    ///     Interface IRegisterFacade
    /// </summary>
    /// <seealso cref="McFly.IInjectable" />
    public interface IRegisterFacade : IInjectable
    {
        /// <summary>
        ///     Gets the registers.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="registers">The registers.</param>
        /// <returns>RegisterSet.</returns>
        RegisterSet GetCurrentRegisterSet(int threadId, IEnumerable<Register> registers);

        /// <summary>
        ///     Gets the current register set.
        /// </summary>
        /// <param name="registers">The registers.</param>
        /// <returns>RegisterSet.</returns>
        RegisterSet GetCurrentRegisterSet(IEnumerable<Register> registers);
    }
}