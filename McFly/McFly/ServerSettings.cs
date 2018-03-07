using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McFly
{
    [Export(typeof(ISettings))]
    public class ServerSettings : ISettings
    {
        public string Url { get; set; }
    }
}
