using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McFly.Core;
using McFly.Server.Data.SqlServer.Entities;

namespace McFly.Server.Data.SqlServer
{
    public static class FrameToEntityMapper
    {
        public static FrameEntity ToEntity(this Frame frame)
        {
            var entity = new FrameEntity
            {
                PosHi = frame.Position.High,
                PosLo = frame.Position.Low,
                ThreadId = frame.ThreadId,
                Rax = frame.RegisterSet.Rax.ToLong(),
                Rbx = frame.RegisterSet.Rbx.ToLong(),
                Rcx = frame.RegisterSet.Rcx.ToLong(),
                Rdx = frame.RegisterSet.Rdx.ToLong(),
                
                OpCode = frame.DisassemblyLine?.OpCode,
                DisassemblyNote = frame.DisassemblyLine?.DisassemblyNote
            };


            return entity;
        }
    }
}
