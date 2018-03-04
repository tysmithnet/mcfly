// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tsmithnet
// Created          : 02-20-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="FrameAccess.cs" company="McFly.Server.Data">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using McFly.Core;

namespace McFly.Server.Data
{
    /// <summary>
    ///     Class FrameAccess.
    /// </summary>
    /// <seealso cref="McFly.Server.Data.DataAccess" />
    /// <seealso cref="McFly.Server.Data.IFrameAccess" />
    public class FrameAccess : DataAccess, IFrameAccess
    {
        /// <summary>
        ///     Upserts the frame.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="frame">The frame.</param>
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