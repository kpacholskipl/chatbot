using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ChatBot.Helpers;
using ChatBot.Models;

namespace ChatBot.Services
{
    public class ConversationService
    {
        private DataSet GetConversationsData(string where = "")
        {
            string query = "Select * from Conversations";
            if (where != "")
                query += $" WHERE {where}";
            return new DatabaseHelper().SelectQuery(query, "Conversations");
        }

        public List<Conversation> GetConversations() => ConversationHelper.GetFromDataSet(GetConversationsData());
        public Conversation GetConversation(int id) => ConversationHelper.GetFromDataSet(GetConversationsData($"id = {id}")).FirstOrDefault();
        public Conversation Login(string email, string password) => ConversationHelper.GetFromDataSet(GetConversationsData($"email = '{email}' AND password = '{password}'")).FirstOrDefault();

        public bool CreateConversation(Conversation Conversation)
        {
            SqlCommand cmd = new SqlCommand("Insert into Conversations (subscription_id, email, password,role,name) VALUES (@subscriptionId,@email,@password,@role,@name)");
            cmd = ConversationHelper.AddParametrsToSqlCommand(cmd, Conversation);
            return new DatabaseHelper().InsertCommand(cmd);
        }
        public bool UpdateConversation(Conversation Conversation)
        {
            SqlCommand cmd = new SqlCommand("Update Conversations SET subscription_id = @subscriptionId, email = @email, password = @password, role = @role,name = @name, api_key = @apiKey WHERE id = @id");
            cmd = ConversationHelper.AddParametrsToSqlCommand(cmd, Conversation);
            cmd.Parameters.AddWithValue("id", Conversation.Id);
            return new DatabaseHelper().UpdateCommand(cmd);
        }
        public bool DeleteConversation (Conversation Conversation)
        {
            return new DatabaseHelper().DeleteQuery($"Delete from Conversations where id = {Conversation.Id}");
        }
    }
}