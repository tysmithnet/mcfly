using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace McFly.Server.Data
{
    public class FrameAccess : DataAccess, IFrameAccess
    {
        public void UpsertFrame(FrameDto frame)
        {
            var parameters = new Dictionary<string, object>()
            {
                ["@key_major"] = frame.Position.High,
                ["@key_minor"] = frame.Position.Low,
                ["@thread_id"] = frame.ThreadId,
                ["@thread_index"] = frame.ThreadIndex,
                ["@rax"] = frame.Rax,
                ["@rbx"] = frame.Rbx,
                ["@rcx"] = frame.Rcx,
                ["@rdx"] = frame.Rdx,
                ["@rsi"] = frame.Rsi,
                ["@rdi"] = frame.Rdi,
                ["@rsp"] = frame.Rsp,
                ["@rbp"] = frame.Rbp,
                ["@rip"] = frame.Rip,
                ["@efl"] = frame.Efl,
                ["@cs"] = frame.Cs,
                ["@ds"] = frame.Ds,
                ["@es"] = frame.Es,
                ["@fs"] = frame.Fs,
                ["@gs"] = frame.Gs,
                ["@ss"] = frame.Ss,
                ["@r8"] = frame.R8,
                ["@r9"] = frame.R9,
                ["@r10"] = frame.R10,
                ["@r11"] = frame.R11,
                ["@r12"] = frame.R12,
                ["@r13"] = frame.R13,
                ["@r14"] = frame.R14,
                ["@r15"] = frame.R15,
                ["@dr0"] = frame.Dr0,
                ["@dr1"] = frame.Dr1,
                ["@dr2"] = frame.Dr2,
                ["@dr3"] = frame.Dr3,
                ["@dr6"] = frame.Dr6,
                ["@dr7"] = frame.Dr7,
                ["@exfrom"] = frame.Exfrom,
                ["@exto"] = frame.Exto,
                ["@brfrom"] = frame.Brfrom,
                ["@brto"] = frame.Brto,
                ["@opcode_nmemonic"] = frame.OpcodeNmemonic,
                ["@code_address"] = frame.CodeAddress,
                ["@module"] = frame.Module,
                ["@function"] = frame.Function,
                ["@function_offset"] = frame.FunctionOffset
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