using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using McFly.Core;

namespace McFly.Server.Data
{
    public class FrameAccess : DataAccess, IFrameAccess
    {
        public void UpsertFrame(string projectName, Frame frame)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@pos_hi", SqlDbType.Int) {Value = frame.Position.High},
                new SqlParameter("@pos_lo", SqlDbType.Int) {Value = frame.Position.Low},
                new SqlParameter("@thread_id", SqlDbType.Int) {Value = frame.ThreadId},
                new SqlParameter("@rax", SqlDbType.BigInt) {Value = frame.RegisterSet.Rax},
                new SqlParameter("@rbx", SqlDbType.BigInt) {Value = frame.RegisterSet.Rbx},
                new SqlParameter("@rcx", SqlDbType.BigInt) {Value = frame.RegisterSet.Rcx},
                new SqlParameter("@rdx", SqlDbType.BigInt) {Value = frame.RegisterSet.Rdx},
                new SqlParameter("@opcode_nmemonic", SqlDbType.VarChar) {Value = frame.OpcodeNmemonic},
                new SqlParameter("@disassembly_note", SqlDbType.VarChar) {Value = frame.DisassemblyNote}
            };

            try
            {
                using (var reader = ExecuteStoredProcedureReader(projectName, "pr_upsert_frame", parameters))
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