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
        public void UpsertFrames(string projectName, IEnumerable<Frame> frames)
        {
            
            try
            {
                var parameter = new SqlParameter("@frames", SqlDbType.Structured) {Value = ConvertToTableType(frames)};
                using (var reader = ExecuteStoredProcedureReader(projectName, "pr_upsert_frames", new []{parameter}))
                {
                    ;
                }
            }
            catch (SqlException e)
            {
                throw;
            }
        }

        private DataTable ConvertToTableType(IEnumerable<Frame> frames)
        {
            var dataTable = new DataTable("tt_frame");
            dataTable.Columns.Add("@pos_hi", typeof(int));
            dataTable.Columns.Add("@pos_lo", typeof(int));
            dataTable.Columns.Add("@thread_id", typeof(int));
            dataTable.Columns.Add("@rax", typeof(long));
            dataTable.Columns.Add("@rbx", typeof(long));
            dataTable.Columns.Add("@rcx", typeof(long));
            dataTable.Columns.Add("@rdx", typeof(long));
            dataTable.Columns.Add("@opcode_mnemonic", typeof(string));
            dataTable.Columns.Add("@disassembly_note", typeof(string));
            
            foreach (var frame in frames)
            {
                dataTable.Rows.Add(
                    frame.Position.High,
                    frame.Position.Low,
                    frame.ThreadId,
                    frame.RegisterSet.Rax,
                    frame.RegisterSet.Rbx,
                    frame.RegisterSet.Rcx,
                    frame.RegisterSet.Rdx,
                    frame.OpcodeMnemonic,
                    frame.DisassemblyNote);
            }

            return dataTable;
        }
    }
}