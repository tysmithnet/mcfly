using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using McFly.Core;

namespace McFly.Server.Data
{
    public class FrameAccess : DataAccess, IFrameAccess
    {
        public void UpsertFrame(Frame frame)
        {
            var parameters = new Dictionary<string, object>()
            {
                ["@key_major"] = frame.Position.High,
                ["@key_minor"] = frame.Position.Low,
                ["@thread_id"] = frame.ThreadId,           
                ["@rax"] = frame.RegisterSet.Rax,
                ["@rbx"] = frame.RegisterSet.Rbx,
                ["@rcx"] = frame.RegisterSet.Rcx,
                ["@rdx"] = frame.RegisterSet.Rdx,
                ["@opcode_nmemonic"] = frame.OpcodeNmemonic
                // todo: stack frames
            };

            try
            {
                using (var reader = ExecuteStoredProcedureReader("pr_upsert_frame", parameters))
                {
                    ;
                }
            }
            catch (SqlException e)
            {
                throw;
            }
        }
    }
}