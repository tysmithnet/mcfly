// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-18-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="RegisterFacade.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text.RegularExpressions;
using McFly.Core;
using McFly.Core.Registers;

namespace McFly
{
    /// <summary>
    ///     Class RegisterFacade.
    /// </summary>
    /// <seealso cref="McFly.IRegisterFacade" />
    [Export(typeof(IRegisterFacade))]
    public class RegisterFacade : IRegisterFacade
    {
        /// <summary>
        ///     Gets or sets the debug eng proxy.
        /// </summary>
        /// <value>The debug eng proxy.</value>
        [Import]
        public IDebugEngineProxy DebugEngineProxy { get; set; }

        /// <summary>
        ///     Gets the registers.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="registers">The registers.</param>
        /// <returns>RegisterSet.</returns>
        public RegisterSet GetCurrentRegisterSet(int threadId, IEnumerable<Register> registers)
        {
            var list = registers.ToList();
            if (list.Count == 0)
                return new RegisterSet();
            var registerSet = new RegisterSet();
            var registerNames = string.Join(",", list.Select(x => x.Name));
            var registerText = DebugEngineProxy.Execute(threadId, $"r {registerNames}");
            foreach (var register in list)
            {
                var match = Regex.Match(registerText, $"\\b{register.Name}=(?<val>[a-fA-F0-9]+)");
                if(!match.Success)
                    throw new ApplicationException($"Register '{register.Name}' was requested, but was not found in the results");
                var val = match.Groups["val"].Value;
                registerSet.Process(register.Name, val, 16);
            }

            return registerSet;
        }

        /// <summary>
        ///     Gets the current register set.
        /// </summary>
        /// <param name="registers">The registers.</param>
        /// <returns>RegisterSet.</returns>
        public RegisterSet GetCurrentRegisterSet(IEnumerable<Register> registers)
        {
            return GetCurrentRegisterSet(DebugEngineProxy.GetCurrentThreadId(), registers);
        }
    }
}