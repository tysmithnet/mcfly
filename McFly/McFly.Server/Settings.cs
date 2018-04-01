using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McFly.Server
{
    [Export]
    public sealed class Settings
    {
        public string ConnectionString { get; internal set; }

        internal Settings()
        {
            
        }
    }
}
