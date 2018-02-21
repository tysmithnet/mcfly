using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace McFly.Server.Data
{
    public class FrameAccess : DataAccess
    {
        public void AddNote(string content)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            using (var command = sqlConnection.CreateCommand())
            {
                sqlConnection.Open();
                command.CommandText = "pr_add_note";
                command.ExecuteNonQuery();
                command.Parameters.AddWithValue("@content", content);
                command.ExecuteNonQuery();
            }
        }

        public void AddNote(string content, int keyMajor, int keyMinor, int threadId)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            using (var command = sqlConnection.CreateCommand())
            {
                sqlConnection.Open();
                command.CommandText = "pr_add_note";
                command.ExecuteNonQuery();
                command.Parameters.AddWithValue("@content", content);
                command.Parameters.AddWithValue("@key_major", keyMajor);
                command.Parameters.AddWithValue("@key_minor", keyMinor);
                command.Parameters.AddWithValue("@thread_id", threadId);
                command.ExecuteNonQuery();
            }
        }
    }
}
