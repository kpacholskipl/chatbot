using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using ChatBot.Models;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace ChatBot.Helpers
{
    public class ConversationHelper
    {
        public static List<Conversation> GetFromDataSet(DataSet ds)
        {
           List<Conversation> Conversations = new List<Conversation>();
          
        foreach (DataRow row in ds.Tables["Conversations"].Rows)
            {
                string createdAt = row["created_at"].ToString();
                string updatedAt = row["updated_at"].ToString();
                int id = Convert.ToInt32(row["id"]);
                int userId = Convert.ToInt32(row["user_id"]);
                int categoryId = Convert.ToInt32(row["category_id"]);
                string title = row["title"].ToString();

                Conversation Conversation = new Conversation(id, userId, categoryId, title)
                {
                    CreatedAt = createdAt,
                    UpdatedAt = updatedAt,
                };
                Conversations.Add(Conversation);
            }

            return Conversations;
        }
        public static SqlCommand AddParametrsToSqlCommand(SqlCommand cmd, Conversation Conversation, bool isCreate = false)
        {
            cmd.Parameters.AddWithValue("@categoryId", Conversation.CategoryId);
            cmd.Parameters.AddWithValue("@title", Conversation.Title);
            if (isCreate)
            {
                cmd.Parameters.AddWithValue("@userId", Conversation.UserId);
            }

            return cmd;
        }
    }
}