using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text.RegularExpressions;
using McFly.Core;

namespace McFly
{
    class RegisterFacade : IRegisterFacade
    {
        [Import]
        public IDbgEngProxy DbgEngProxy { get; set; }


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
            var registerText = DbgEngProxy.Execute($"~~[{threadId:X}] r {registerNames}");
            foreach (var register in list)
            {
                var numChars = DbgEngProxy.Is32Bit ? 8 : 16;
                var match = Regex.Match(registerText, $"{register.Name}=(?<val>[a-fA-F0-9]{{{numChars}}})");
                var val = match.Groups["val"].Value;
                registerSet.Process(register.Name, val, 16);
            }
            return registerSet;
        }

        public RegisterSet GetCurrentRegisterSet(IEnumerable<Register> registers)
        {
            return GetCurrentRegisterSet(DbgEngProxy.GetCurrentThreadId(), registers);
        }
    }
}