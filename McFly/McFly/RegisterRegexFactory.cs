using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using McFly.Core.Registers;

namespace McFly
{
    [Export]
    public class RegisterRegexFactory
    {
        public Regex Get(Register register)
        {
            if (register == Register.Af)
            {
                return new Regex(@"(^|[ ,])af=[a-f0-9]{1}", RegexOptions.IgnoreCase);
            }
            if (register == Register.Ah)
            {
                return new Regex(@"(^|[ ,])ah=[a-f0-9]{2}");
            }
            
            
            throw new ArgumentOutOfRangeException($"{nameof(register)} was not found in the factory, this is a programming error.");
        }
    }
}
