using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace McFly.Server.Data
{
    public class NoteAccess : DataAccess, INoteAccess
    {
        public void AddNote(string content)
        {
            var parameters = new Dictionary<string, object>()
            {
                ["@content"] = content
            };
            try
            {
                using (var reader = ExecuteStoredProcedureReader("pr_add_note", parameters))
                {
                    ;
                }
            }
            catch (SqlException e)
            {
                throw;
            }
        }

        public void AddNote(string content, int keyMajor, int keyMinor, int threadIndex)
        {
            var parameters = new Dictionary<string, object>()
            {
                ["@content"] = content,
                ["@key_major"] = keyMajor,
                ["@key_minor"] = keyMinor,
                ["@thread_index"] = threadIndex,
            };
            try
            {
                using (var reader = ExecuteStoredProcedureReader("pr_add_note", parameters))
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
