﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McFly.Core;

namespace McFly.Server.Data
{
    public interface IMemoryAccess
    {
        void AddMemory(string projectName, Position position, MemoryChunk memoryChunk);
    }
}
