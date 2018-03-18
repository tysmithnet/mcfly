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
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using McFly.Core;

namespace McFly.Server.Data
{
    /// <summary>
    ///     Class FrameAccess.
    /// </summary>
    /// <seealso cref="McFly.Server.Data.DataAccess" />
    /// <seealso cref="McFly.Server.Data.IFrameAccess" />
    [Export(typeof(IFrameAccess))]
    [Export(typeof(FrameAccess))]
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
                var tableTypes = ConvertToTableType(frames);
                var framesParam = new SqlParameter("@frames", SqlDbType.Structured) {Value = tableTypes.Frames};
                var stackFrameParams = new SqlParameter("@stackframes", SqlDbType.Structured) { Value = tableTypes.StackFrames };
                using (var reader = ExecuteStoredProcedureReader(projectName, "pr_upsert_frames", new []{framesParam, stackFrameParams}))
                {
                    ;
                }
            }
            catch (SqlException e)
            {
                throw;
            }
        }

        private FrameDto ConvertToTableType(IEnumerable<Frame> frames)
        {
            var frameTable = new DataTable("tt_frame");
            frameTable.Columns.Add("@pos_hi", typeof(int));
            frameTable.Columns.Add("@pos_lo", typeof(int));
            frameTable.Columns.Add("@thread_id", typeof(int));
            frameTable.Columns.Add("@rax", typeof(long));
            frameTable.Columns.Add("@rbx", typeof(long));
            frameTable.Columns.Add("@rcx", typeof(long));
            frameTable.Columns.Add("@rdx", typeof(long));
            frameTable.Columns.Add("@opcode", typeof(byte[]));
            frameTable.Columns.Add("@opcode_mnemonic", typeof(string));
            frameTable.Columns.Add("@disassembly_note", typeof(string));
            
            var stackFrameTable = new DataTable("tt_stackframe");
            stackFrameTable.Columns.Add("@pos_hi", typeof(int));
            stackFrameTable.Columns.Add("@pos_lo", typeof(int));
            stackFrameTable.Columns.Add("@thread_id", typeof(int));
            stackFrameTable.Columns.Add("@depth", typeof(int));
            stackFrameTable.Columns.Add("@stack_pointer", typeof(long));
            stackFrameTable.Columns.Add("@return_address", typeof(long));
            stackFrameTable.Columns.Add("@module", typeof(string));
            stackFrameTable.Columns.Add("@function", typeof(string));
            stackFrameTable.Columns.Add("@offset", typeof(long));

            foreach (var frame in frames)
            {
                frameTable.Rows.Add(
                    frame.Position.High,
                    frame.Position.Low,
                    frame.ThreadId,
                    frame.RegisterSet.Rax,
                    frame.RegisterSet.Rbx,
                    frame.RegisterSet.Rcx,
                    frame.RegisterSet.Rdx,
                    frame.OpCode,
                    frame.OpcodeMnemonic,
                    frame.DisassemblyNote);

                for (var index = 0; index < frame.StackTrace.NumFrames; index++)
                {
                    var stackFrame = frame.StackTrace.StackFrames.ElementAt(index);
                    stackFrameTable.Rows.Add(
                        frame.Position.High,
                        frame.Position.Low,
                        frame.ThreadId,
                        index,
                        stackFrame.Module,
                        stackFrame.FunctionName,
                        stackFrame.Offset
                    );
                }
            }

            return new FrameDto
            {
                Frames = frameTable,
                StackFrames = stackFrameTable
            };
        }
    }
}