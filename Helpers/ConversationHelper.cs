using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using ChatBot.Models;

namespace ChatBot.Helpers
{
    public class ConversationHelper
    {
        public static List<Conversation> GetFromDataSet(DataSet ds)
        {
           List<Conversation> Conversations = new List<Conversation>();
          
          //  foreach (DataRow row in ds.Tables["Conversations"].Rows)
            //{
              //  int id = Convert.ToInt32(row["id"]);
                //string name = row["name"].ToString();

                //Conversation Conversation = new Conversation(id, name);
                //Conversations.Add(Conversation);
           // }

            return Conversations;
        }
        public static SqlCommand AddParametrsToSqlCommand(SqlCommand cmd, Conversation Conversation)
        {
            //cmd.Parameters.AddWithValue("@ConversationId", Conversation.ConversationId);
            //cmd.Parameters.AddWithValue("@email", Conversation.Email);
            //cmd.Parameters.AddWithValue("@password", Conversation.Password);
            //cmd.Parameters.AddWithValue("@role", Conversation.Name);
            //cmd.Parameters.AddWithValue("@name", Conversation.Name);

            return cmd;
        }
    }
}