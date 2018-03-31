// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tsmithnet
// Created          : 02-20-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-12-2018
// ***********************************************************************
// <copyright file="NoteAccess.cs" company="McFly.Server.Data">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Data.SqlClient;
using McFly.Core;

namespace McFly.Server.Data
{
    /// <summary>
    ///     INoteAccess implementation that uses SQL Server
    /// </summary>
    /// <seealso cref="McFly.Server.Data.DataAccess" />
    /// <seealso cref="McFly.Server.Data.INoteAccess" />
    [Export(typeof(INoteAccess))]
    public class NoteAccess : DataAccess, INoteAccess
    {
        /// <summary>
        ///     Adds a note to a thread position
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="text">The text.</param>
        public void AddNote(string projectName, Position position, IEnumerable<int> threadIds, string text)
        {
            ExecuteStoredProcedureNonQuery(projectName, "pr_add_note", CreateParameters(position, threadIds, text));
        }

        private IEnumerable<SqlParameter> CreateParameters(Position position, IEnumerable<int> threadIds, string text)
        {
            DataTable threadIdsTable = CreateThreadIdsTable(threadIds);
            var posHi = new SqlParameter("@pos_hi", SqlDbType.Int) {Value = position.High};
            var posLo = new SqlParameter("@pos_lo", SqlDbType.Int) {Value = position.Low};
            var tid = new SqlParameter("@thread_ids", SqlDbType.Structured) {Value = threadIdsTable};
            var txt = new SqlParameter(@"text", SqlDbType.Text) {Value = text};

            return new[] {posHi, posLo, tid, txt};
        }

        private DataTable CreateThreadIdsTable(IEnumerable<int> threadIds)
        {
            var dataTable = new DataTable("tt_int");
            dataTable.Columns.Add("@id", typeof(int));
            dataTable.Columns.Add("@value0", typeof(int));

            foreach (var threadId in threadIds)
            {
                dataTable.Rows.Add(null, threadId);
            }

            return dataTable;
        }
    }
}