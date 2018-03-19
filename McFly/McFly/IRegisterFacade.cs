using System.Collections.Generic;
using McFly.Core;

namespace McFly
{
    public interface IRegisterFacade
    {
        /// <summary>
        ///     Gets the registers.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="registers">The registers.</param>
        /// <returns>RegisterSet.</returns>
        RegisterSet GetCurrentRegisterSet(int threadId, IEnumerable<Register> registers);
        RegisterSet GetCurrentRegisterSet(IEnumerable<Register> registers);
    }
}