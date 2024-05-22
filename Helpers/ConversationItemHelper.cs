using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using ChatBot.Models;

namespace ChatBot.Helpers
{
    public class ConversationItemHelper
    {
        public static List<ConversationItem> GetFromDataSet(DataSet ds)
        {
           List<ConversationItem> conversationItems = new();

            Console.WriteLine(ds.Tables);
             foreach (DataRow row in ds.Tables["conversation_items"].Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                
                int order = Convert.ToInt32(row["order"]);
                int conversationId = Convert.ToInt32(row["conversation_id"]);
                string message = row["message"].ToString();

                ConversationItem ConversationItem = new ConversationItem(conversationId, order, message)
                {
                    Id = id
                };
                conversationItems.Add(ConversationItem);
            }

            return conversationItems;
        }
        public static SqlCommand AddParametrsToSqlCommand(SqlCommand cmd, ConversationItem ConversationItem)
        {
            cmd.Parameters.AddWithValue("@conversationId", ConversationItem.ConversationId);
            cmd.Parameters.AddWithValue("@message", ConversationItem.Message);
            cmd.Parameters.AddWithValue("@order", ConversationItem.Order);

            return cmd;
        }
    }
}