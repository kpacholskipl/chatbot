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

        public List<Conversation> GetListConversations() => ConversationHelper.GetFromDataSet(GetConversationsData());
        public List<Conversation> GetConversationsByUser(int id) => ConversationHelper.GetFromDataSet(GetConversationsData($"user_id = {id}"));
        public List<Conversation> GetConversationsByCategory(int id) => ConversationHelper.GetFromDataSet(GetConversationsData($"category_id = {id}"));
        public DataSet GetConversations() => GetConversationsData();
        public Conversation GetConversation(int id)
        {
            Conversation conversation =  ConversationHelper.GetFromDataSet(GetConversationsData($"id = {id}")).FirstOrDefault();
            if (conversation != null)
            {
                conversation.Items = new ConversationItemService().GetListConversationItemsByConversationId(conversation.Id);
            }
            return conversation;
        }
        public bool CreateConversation(Conversation Conversation)
        {
            SqlCommand cmd = new SqlCommand("Insert into Conversations (user_id, category_id, title) VALUES (@userId, @categoryId, @title)");
            cmd = ConversationHelper.AddParametrsToSqlCommand(cmd, Conversation, true);
            return new DatabaseHelper().InsertCommand(cmd);
        }
        public Conversation CreateAndGetConversation(Conversation Conversation)
        {
            SqlCommand cmd = new SqlCommand("Insert into Conversations (user_id, category_id, title) VALUES (@userId, @categoryId, @title);SELECT SCOPE_IDENTITY()");
            cmd = ConversationHelper.AddParametrsToSqlCommand(cmd, Conversation, true);
            int id = new DatabaseHelper().InsertScalar(cmd);
            return GetConversation(id);
        }

        public bool UpdateConversation(Conversation Conversation)
        {
            SqlCommand cmd = new SqlCommand("Update Conversations SET category_id = @category_id, title = @title WHERE id = @id");
            cmd = ConversationHelper.AddParametrsToSqlCommand(cmd, Conversation);
            cmd.Parameters.AddWithValue("id", Conversation.Id);
            return new DatabaseHelper().UpdateCommand(cmd);
        }
        public bool DeleteConversation (Conversation Conversation)
        {
            return new DatabaseHelper().DeleteQuery($"Delete from conversations where id = {Conversation.Id}");
        }
        
    }
}